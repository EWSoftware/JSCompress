//=============================================================================
// System  : JavaScript Compressor
// File    : AssemblyInfo.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 10/03/2010
// Note    : Copyright 2003-2010, Eric Woodruff, All rights reserved
// Compiler: Visual C#
//
// Assembly information.
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
// 2.1.0.0  10/03/2010  EFW  Rebuilt for use with .NET 4.0, fixed some bugs
//=============================================================================

using System;
using System.Reflection;
using System.Runtime.InteropServices;

//
// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyProduct("JavaScript Compressor")]
[assembly: AssemblyTitle("JavaScript Compressor - Command Line")]
[assembly: AssemblyDescription("Use the JavaScript compressor from the command line")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Eric Woodruff")]
[assembly: AssemblyCopyright("Copyright \xA9 2003-2010, Eric Woodruff, All Rights Reserved")]
[assembly: AssemblyTrademark("Eric Woodruff, All Rights Reserved")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers
// by using the '*' as shown below:

[assembly: AssemblyVersion("2.1.0.0")]
