//=============================================================================
// System  : JavaScript Compressor
// File    : JSCompressCL.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 03/04/2007
// Note    : Copyright 2003-2007, Eric Woodruff, All rights reserved
// Compiler: Visual C#
//
// This provides a command line tool that can be used to compress JavaScript
// files.  It can be specified as the pre-build command of a project to
// compress script files and move them to the application's runtime folder.
// See the help method for command line options.
//
// This code may be used in compiled form in any way you desire.  This
// file may be redistributed unmodified by any means PROVIDING it is not
// sold for profit without the author's written consent, and providing
// that this notice and the author's name and all copyright notices
// remain intact.
//
// This code is provided "as is" with no warranty either express or
// implied.  The author accepts no liability for any damage or loss of
// business that this product may cause.
//
// Version     Date     Who  Comments
// ============================================================================
// 1.0.0.0  07/21/2002  EFW  Created the code
// 2.0.0.0  03/04/2006  EFW  Rebuilt and tested with VS 2005 and .NET 2.0 and
//                           added support for compressing variable names.
// 2.0.0.1  06/26/2006  EFW  Modified to support conditional compilation blocks
//                           and added sub-folder recursion option.
// 2.0.0.2  03/04/2007  EFW  Fixed a few bugs in variable name compression
//=============================================================================

using System;
using System.Globalization;
using System.IO;
using System.Reflection;

using JSCompress;

namespace JSCompressCL
{
	/// <summary>
	/// This is a command line JavaScript compressor
	/// </summary>
	class JSCompressCL
	{
        //=====================================================================
        // Private data members

        // The compressor
        private static JSCompressor jsc;

        // The output folder
        static string strOutFolder = String.Empty;

        // Suppress compression if debug build
        static bool bDebug;

        // Suppress stats if true
        static bool bQuiet;

        // Force compression in debug build
        static bool bForceComp;

        // Recurse sub-folders if true
        static bool bRecurseSubFolders;

        //=====================================================================
        // Methods, etc.

		/// <summary>
		/// JavaScript compressor - Command line version.
		/// </summary>
		/// <param name="args">The command line arguments.  See Help()</param>
        /// <returns>Zero on success, one on error</returns>
		[STAThread]
		static int Main(string[] args)
		{
            bool bSuccess = true;
            string strOpt;

            Console.WriteLine(@"JavaScript Compressor version {0}
Copyright (c) 2003-2006, Eric Woodruff, All rights reserved
E-Mail: Eric@EWoodruff.us",
                Assembly.GetExecutingAssembly().GetName().Version.ToString());

            if(args.GetUpperBound(0) < 0)
            {
                Help();
                return 1;
            }

            // Create compressor.  Default to line feed removal mode.
            jsc = new JSCompressor(true);

            foreach(string strArg in args)
            {
                strOpt = strArg.ToLower(CultureInfo.InvariantCulture);

                switch(strOpt)
                {
                    case "/?":      // Show help
                        Help();
                        break;

                    case "/q":      // Shut up about the stats
                        bQuiet = true;
                        break;

                    case "/d":      // LF removal enabled (default)
                        jsc.LineFeedRemoval = true;
                        break;

                    case "/k":      // LF removal disabled
                        jsc.LineFeedRemoval = false;
                        break;

                    case "/v":      // Compress variable names
                        jsc.CompressVariableNames = true;
                        break;

                    case "/t":      // Variable name compression test
                        jsc.TestVariableNameCompression = true;
                        break;

                    case "/f":      // Force compression in debug mode
                        bForceComp = true;
                        break;

                    case "/r":      // Recurse sub-folders on each filespec too
                        bRecurseSubFolders = true;
                        break;

                    default:
                        // If using the VS.NET pre-build command macro
                        // $(ConfigurationName), it may not match "Debug" or
                        // "Release" exactly so accept anything that starts
                        // with those keywords.  For the "/Out" option, the
                        // folder to use follows the ":".
                        if(strOpt.Length >= 6 && strOpt.Substring(0, 6) == "/debug")
                        {
                            // Debug build, suppress compression
                            Console.WriteLine("DEBUG BUILD - Script compression disabled unless forced (/f)\n");
                            bDebug = true;
                        }
                        else if(strOpt.Length >= 8 && strOpt.Substring(0, 8) == "/release")
                        {
                            Console.WriteLine("RELEASE BUILD - Script compression enabled\n");
                            bDebug = false;
                        }
                        else if(strOpt.Length > 3 && strOpt.Substring(0, 3) == "/o:")
                        {
                            // Set output folder or compress files
                            strOutFolder = strArg.Substring(3);
                            if(strOutFolder.EndsWith("\\") == false)
                                strOutFolder += "\\";
                        }
                        else
                            bSuccess = CompressFileSpec(strArg);
                        break;
                }

                if(!bSuccess)
                    break;
            }

            // For debugging
#if DEBUG
            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
#endif
            return (bSuccess) ? 0 : 1;
		}

        /// <summary>
        /// Compress the specified file or files
        /// </summary>
        /// <param name="strFileSpec">The file or files to compress</param>
        /// <returns>True on success, false on error</returns>
        static bool CompressFileSpec(string strFileSpec)
        {
            string strFolder, strMask, tempOut;
            int nPos;
            bool bSuccess = true;

            try
            {
                // Split the mask from the folder
                nPos = strFileSpec.LastIndexOf("\\");
                if(nPos != -1)
                {
                    strMask = strFileSpec.Substring(nPos + 1);
                    strFolder = strFileSpec.Substring(0, nPos + 1);
                }
                else
                {
                    strMask = strFileSpec;
                    strFolder = @".\";
                }

                // Make sure the output path exists
                if(!Directory.Exists(strOutFolder))
                    Directory.CreateDirectory(strOutFolder);

                // If it's a single file, compress it and leave
                if(strMask.IndexOf('*') == -1 && strMask.IndexOf('?') == -1)
                {
                    if(File.Exists(strFileSpec) == true)
                        return CompressFile(strFolder, strMask);

                    // It's probably a folder with no mask specified
                    strFolder += strMask;
                    strMask = "*";
                }

                // Compress all files in the folder
                DirectoryInfo di = new DirectoryInfo(strFolder);

                FileInfo[] fi = di.GetFiles(strMask);

                foreach(FileInfo fiTemp in fi)
                {
                    bSuccess = CompressFile(fiTemp.DirectoryName, fiTemp.Name);
                    if(bSuccess == false)
                        break;
                }

                if(bRecurseSubFolders)
                {
                    DirectoryInfo[] subFolders = di.GetDirectories();

                    foreach(DirectoryInfo folder in subFolders)
                    {
                        tempOut = strOutFolder;
                        strOutFolder += folder.Name + @"\";
                        CompressFileSpec(folder.FullName + @"\" + strMask);
                        strOutFolder = tempOut;
                    }
                }

                return bSuccess;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Unable to process {0}.\n" +
                    "Additional Information: {1}", strFileSpec, e.Message);
                return false;
            }
        }

        /// <summary>
        /// Compress the specified file
        /// </summary>
        /// <param name="strFilename">The file to compress"</param>
        /// <returns>True on success, false on error</returns>
        static bool CompressFile(string strFolder, string strFilename)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            DateTime dtStartTime;
            TimeSpan tsElapsed;
            long lOriginalSize, lCompressedSize, lBytesSaved;
            string strOriginal, strCompressed, strInFile, strOutFile;

            try
            {
                if(strFolder.EndsWith("\\") == false)
                    strFolder += "\\";

                strInFile = strFolder + strFilename;
                strOutFile = strOutFolder + strFilename;

                // Skip compression if this is a debug build and the output
                // file is the same or older than the source indicating that
                // it hasn't changed.  This saves recreating the file every
                // time the project is built in debug mode.  Release build
                // always causes compression so that the script is current
                // and compressed for the release build.
                if(bDebug == true && File.Exists(strOutFile) &&
                  File.GetLastWriteTime(strOutFile) >
                  File.GetLastWriteTime(strInFile))
                {
                    if(bQuiet == false)
                        Console.WriteLine("{0} is up to date", strInFile);

                    return true;
                }

                sr = new StreamReader(strInFile);
                strOriginal = sr.ReadToEnd();

                dtStartTime = DateTime.Now;

                // Supress compression if debug build and not forced
                if(bDebug == false || bForceComp == true)
                    strCompressed = jsc.Compress(strOriginal);
                else
                    strCompressed = strOriginal;

                tsElapsed = DateTime.Now - dtStartTime;

                sw = new StreamWriter(strOutFile);
                sw.Write(strCompressed);

                lOriginalSize = strOriginal.Length;
                lCompressedSize = strCompressed.Length;
                lBytesSaved = lOriginalSize - lCompressedSize;

                if(!bQuiet)
                    Console.WriteLine(@"Compressed {0} to {1}
          Compression Time: {2:F2} seconds
      Original Script Size: {3} bytes
    Compressed Script Size: {4} bytes
               Bytes Saved: {5} bytes
             % Space Saved: {6:P}", strInFile, strOutFile,
                    tsElapsed.TotalSeconds, lOriginalSize, lCompressedSize, lBytesSaved,
                    (lBytesSaved < 1) ? 0.0 : (double)lBytesSaved / (double)lOriginalSize);

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: Unable to process {0}.\n" +
                    "Additional Information: {1}", strFilename, e.Message);
                return false;
            }
            finally
            {
                if(sr != null)
                    sr.Close();

                if(sw != null)
                    sw.Close();
            }
        }

        /// <summary>
        /// Show command line help
        /// </summary>
        static void Help()
        {
            Console.WriteLine(@"Syntax:
  JSCompressCL [/options] filespec [[/options] filespec ...]

Options and filespecs are processed from left to right as encountered.
    /?          Show help
    /q          Don't display compression statistics
    /debug      Debug build, compression is suppressed
    /release    Release build, compression enabled (default)
    /k          (Keep) No line feeds are removed
    /d          (Delete) Line feed removal enabled (default)
    /v          Compress variable and parameter names
    /t          Variable name compression only (for testing)
    /f          Force compression in debug build
    /r          Recurse sub-folders in the filespec too
    /o:<dir>    Specify output folder (default is current folder)
    filespec    One or more files to compress, wildcards accepted");
        }
	}
}
