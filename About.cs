//=============================================================================
// System  : JavaScript Compressor
// File    : About.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 03/05/2006
// Note    : Copyright 2003-2006, Eric Woodruff, All rights reserved
// Compiler: Visual C#
//
// The About Box for the demo
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
//=============================================================================

using System;
using System.Windows.Forms;

namespace JSCompress
{
	/// <summary>
	/// The About Box for the demo
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel lnkEMail;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
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
				if(components != null)
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
            this.label1 = new System.Windows.Forms.Label();
            this.lnkEMail = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interactive JavaScript Compressor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkEMail
            // 
            this.lnkEMail.Location = new System.Drawing.Point(8, 32);
            this.lnkEMail.Name = "lnkEMail";
            this.lnkEMail.Size = new System.Drawing.Size(280, 32);
            this.lnkEMail.TabIndex = 2;
            this.lnkEMail.TabStop = true;
            this.lnkEMail.Text = "Eric@EWoodruff.us";
            this.lnkEMail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkEMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEMail_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(96, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            // 
            // About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(296, 129);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkEMail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About JSCompress";
            this.ResumeLayout(false);

        }
		#endregion

        private void lnkEMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            lnkEMail.LinkVisited = true;
            System.Diagnostics.Process.Start("mailto:Eric@EWoodruff.us");
        }
	}
}
