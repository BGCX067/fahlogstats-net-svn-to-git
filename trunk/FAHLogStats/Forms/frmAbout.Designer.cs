/*
 * FAHLogStats.NET - About Form
 * Copyright (C) 2006-2007 David Rawling

 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; version 2
 * of the License. See the included file GPLv2.TXT.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

namespace FAHLogStats.Forms
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyrights = new System.Windows.Forms.Label();
            this.lblLinkOrig = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGPL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(10, 7);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(520, 32);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "FAHLogStats.NET";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(11, 37);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(518, 28);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "[Version]";
            // 
            // lblCopyrights
            // 
            this.lblCopyrights.Location = new System.Drawing.Point(12, 70);
            this.lblCopyrights.Name = "lblCopyrights";
            this.lblCopyrights.Size = new System.Drawing.Size(518, 97);
            this.lblCopyrights.TabIndex = 3;
            this.lblCopyrights.Text = resources.GetString("lblCopyrights.Text");
            // 
            // lblLinkOrig
            // 
            this.lblLinkOrig.LinkArea = new System.Windows.Forms.LinkArea(32, 11);
            this.lblLinkOrig.Location = new System.Drawing.Point(14, 173);
            this.lblLinkOrig.Name = "lblLinkOrig";
            this.lblLinkOrig.Size = new System.Drawing.Size(515, 31);
            this.lblLinkOrig.TabIndex = 5;
            this.lblLinkOrig.TabStop = true;
            this.lblLinkOrig.Text = "FAHLogStats.NET was inspired by FAHLogStats.";
            this.lblLinkOrig.UseCompatibleTextRendering = true;
            this.lblLinkOrig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(454, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FAHLogStats.Properties.Resources.FAHLogStatsOrigASm;
            this.pictureBox1.InitialImage = global::FAHLogStats.Properties.Resources.FAHLogStatsOrigA;
            this.pictureBox1.Location = new System.Drawing.Point(365, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblGPL
            // 
            this.lblGPL.Location = new System.Drawing.Point(12, 202);
            this.lblGPL.Name = "lblGPL";
            this.lblGPL.Size = new System.Drawing.Size(518, 218);
            this.lblGPL.TabIndex = 6;
            this.lblGPL.Text = resources.GetString("lblGPL.Text");
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblGPL);
            this.Controls.Add(this.lblLinkOrig);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCopyrights);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About FAHLogStats.NET";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyrights;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblLinkOrig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblGPL;

    }
}