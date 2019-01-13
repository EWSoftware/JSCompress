//=============================================================================
// System  : JavaScript Compressor
// File    : JSCompress.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 03/04/2007
// Note    : Copyright 2003-2007, Eric Woodruff, All rights reserved
// Compiler: Visual C#
//
// This form provides an interactive interface to the JavaScript compressor
// class.
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
// 2.0.0.2  03/04/2007  EFW  Fixed a few bugs in variable name compression
//=============================================================================

using System;
using System.Windows.Forms;

namespace JSCompress
{
	/// <summary>
	/// This form provides an interactive interface to the JavaScript
	/// compressor class.
	/// </summary>
	public class JSCompress : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.TextBox txtCompressed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOriginalSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCompressedSize;
        private System.Windows.Forms.Label lblBytesSaved;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPercentSaved;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip ttTips;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkRemoveLFs;
        private System.Windows.Forms.CheckBox chkCompressVariables;
        private System.Windows.Forms.CheckBox chkVarCompTest;
        private System.ComponentModel.IContainer components;

		public JSCompress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSCompress));
            this.txtScript = new System.Windows.Forms.TextBox();
            this.txtCompressed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOriginalSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCompressedSize = new System.Windows.Forms.Label();
            this.lblBytesSaved = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPercentSaved = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.ttTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnAbout = new System.Windows.Forms.Button();
            this.chkRemoveLFs = new System.Windows.Forms.CheckBox();
            this.chkCompressVariables = new System.Windows.Forms.CheckBox();
            this.chkVarCompTest = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.AcceptsReturn = true;
            this.txtScript.AcceptsTab = true;
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScript.Location = new System.Drawing.Point(8, 32);
            this.txtScript.MaxLength = 0;
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(976, 292);
            this.txtScript.TabIndex = 1;
            this.txtScript.WordWrap = false;
            // 
            // txtCompressed
            // 
            this.txtCompressed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompressed.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompressed.Location = new System.Drawing.Point(8, 396);
            this.txtCompressed.MaxLength = 0;
            this.txtCompressed.Multiline = true;
            this.txtCompressed.Name = "txtCompressed";
            this.txtCompressed.ReadOnly = true;
            this.txtCompressed.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCompressed.Size = new System.Drawing.Size(976, 176);
            this.txtCompressed.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Original Script";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(8, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Co&mpressed Script";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.Location = new System.Drawing.Point(369, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Original Script Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOriginalSize
            // 
            this.lblOriginalSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblOriginalSize.Location = new System.Drawing.Point(529, 580);
            this.lblOriginalSize.Name = "lblOriginalSize";
            this.lblOriginalSize.Size = new System.Drawing.Size(72, 23);
            this.lblOriginalSize.TabIndex = 12;
            this.lblOriginalSize.Text = "0";
            this.lblOriginalSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.Location = new System.Drawing.Point(624, 580);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Compressed Script Size:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompressedSize
            // 
            this.lblCompressedSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCompressedSize.Location = new System.Drawing.Point(801, 580);
            this.lblCompressedSize.Name = "lblCompressedSize";
            this.lblCompressedSize.Size = new System.Drawing.Size(72, 23);
            this.lblCompressedSize.TabIndex = 14;
            this.lblCompressedSize.Text = "0";
            this.lblCompressedSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBytesSaved
            // 
            this.lblBytesSaved.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBytesSaved.Location = new System.Drawing.Point(529, 604);
            this.lblBytesSaved.Name = "lblBytesSaved";
            this.lblBytesSaved.Size = new System.Drawing.Size(72, 23);
            this.lblBytesSaved.TabIndex = 16;
            this.lblBytesSaved.Text = "0";
            this.lblBytesSaved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.Location = new System.Drawing.Point(413, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Bytes Saved:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPercentSaved
            // 
            this.lblPercentSaved.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPercentSaved.Location = new System.Drawing.Point(801, 604);
            this.lblPercentSaved.Name = "lblPercentSaved";
            this.lblPercentSaved.Size = new System.Drawing.Size(72, 23);
            this.lblPercentSaved.TabIndex = 18;
            this.lblPercentSaved.Text = "0.00 %";
            this.lblPercentSaved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.Location = new System.Drawing.Point(666, 604);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 23);
            this.label10.TabIndex = 17;
            this.label10.Text = "% Space Saved:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCompress
            // 
            this.btnCompress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompress.Location = new System.Drawing.Point(8, 332);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(96, 32);
            this.btnCompress.TabIndex = 2;
            this.btnCompress.Text = "&Compress";
            this.ttTips.SetToolTip(this.btnCompress, "Compress the script");
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(888, 628);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 32);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "E&xit";
            this.ttTips.SetToolTip(this.btnExit, "Exit this application");
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblElapsedTime.Location = new System.Drawing.Point(315, 580);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(48, 23);
            this.lblElapsedTime.TabIndex = 10;
            this.lblElapsedTime.Text = "0.00";
            this.lblElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.Location = new System.Drawing.Point(110, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Compression Time (seconds):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(112, 332);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "C&lear";
            this.ttTips.SetToolTip(this.btnClear, "Clear all script");
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.Location = new System.Drawing.Point(8, 628);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(96, 32);
            this.btnAbout.TabIndex = 19;
            this.btnAbout.Text = "A&bout";
            this.ttTips.SetToolTip(this.btnAbout, "About this application");
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkRemoveLFs
            // 
            this.chkRemoveLFs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRemoveLFs.Checked = true;
            this.chkRemoveLFs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveLFs.Location = new System.Drawing.Point(242, 332);
            this.chkRemoveLFs.Name = "chkRemoveLFs";
            this.chkRemoveLFs.Size = new System.Drawing.Size(259, 24);
            this.chkRemoveLFs.TabIndex = 4;
            this.chkRemoveLFs.Text = "&Remove line feeds where possible";
            this.ttTips.SetToolTip(this.chkRemoveLFs, "Check this to remove line feeds");
            // 
            // chkCompressVariables
            // 
            this.chkCompressVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCompressVariables.Location = new System.Drawing.Point(542, 332);
            this.chkCompressVariables.Name = "chkCompressVariables";
            this.chkCompressVariables.Size = new System.Drawing.Size(216, 24);
            this.chkCompressVariables.TabIndex = 5;
            this.chkCompressVariables.Text = "Compress &variable names";
            this.ttTips.SetToolTip(this.chkCompressVariables, "Check this to remove line feeds");
            // 
            // chkVarCompTest
            // 
            this.chkVarCompTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVarCompTest.Location = new System.Drawing.Point(242, 362);
            this.chkVarCompTest.Name = "chkVarCompTest";
            this.chkVarCompTest.Size = new System.Drawing.Size(447, 24);
            this.chkVarCompTest.TabIndex = 7;
            this.chkVarCompTest.Text = "&Test only variable name compression (script is not compressed)";
            this.ttTips.SetToolTip(this.chkVarCompTest, "Check this to remove line feeds");
            // 
            // JSCompress
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(992, 667);
            this.Controls.Add(this.chkVarCompTest);
            this.Controls.Add(this.chkCompressVariables);
            this.Controls.Add(this.chkRemoveLFs);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.lblPercentSaved);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblBytesSaved);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCompressedSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblOriginalSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompressed);
            this.Controls.Add(this.txtScript);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(792, 464);
            this.Name = "JSCompress";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JavaScript Compressor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new JSCompress());
		}

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            this.txtScript.Text = this.txtCompressed.Text = String.Empty;
            this.lblElapsedTime.Text = "0.00";
            this.lblOriginalSize.Text = this.lblCompressedSize.Text =
                this.lblBytesSaved.Text = "0";
            this.lblPercentSaved.Text = "0.00%";
            this.txtScript.Focus();
        }

        private void btnCompress_Click(object sender, System.EventArgs e)
        {
            DateTime dtStartTime;
            TimeSpan tsElapsed;
            long lOriginalSize, lCompressedSize, lBytesSaved;

            // Compress the script
            JSCompressor jsc = new JSCompressor(chkRemoveLFs.Checked,
                chkCompressVariables.Checked);

            // If checked only test variable name compression.  The script
            // itself will not be compressed with the exception of comment
            // removal.
            if(chkVarCompTest.Checked)
                jsc.TestVariableNameCompression = true;

            dtStartTime = DateTime.Now;
            this.txtCompressed.Text = jsc.Compress(this.txtScript.Text);
            tsElapsed = DateTime.Now - dtStartTime;

            // Display stats
            lOriginalSize = txtScript.Text.Length;
            lCompressedSize = txtCompressed.Text.Length;
            lBytesSaved = lOriginalSize - lCompressedSize;

            this.lblElapsedTime.Text = String.Format("{0:F2}", tsElapsed.TotalSeconds);
            this.lblOriginalSize.Text = lOriginalSize.ToString();
            this.lblCompressedSize.Text = lCompressedSize.ToString();
            this.lblBytesSaved.Text = lBytesSaved.ToString();
            this.lblPercentSaved.Text = String.Format("{0:P}",
                (lBytesSaved < 1) ? 0.0 : (double)lBytesSaved / (double)lOriginalSize);
        }

        private void btnAbout_Click(object sender, System.EventArgs e)
        {
            About dlgAbout = new About();
            dlgAbout.ShowDialog(this);
        }
	}
}
