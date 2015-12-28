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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FAHLogStats.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            System.Reflection.Assembly asmCurrent = System.Reflection.Assembly.GetExecutingAssembly();
            lblVersion.Text = "Version " + asmCurrent.GetName().Version.ToString();

            // Layout the dialog
            lblProduct.Top = 12;
            lblProduct.Left = 12;
            lblProduct.Height = Convert.ToInt32(TextRenderer.MeasureText(lblProduct.Text, lblProduct.Font).Height + 2);

            lblVersion.Top = lblProduct.Top + lblProduct.Height - 1;
            lblVersion.Left = 12;
            lblVersion.Height = Convert.ToInt32(TextRenderer.MeasureText(lblVersion.Text, lblVersion.Font).Height + 2);
            
            lblCopyrights.Top = lblVersion.Top + lblVersion.Height + 10;
            lblCopyrights.Left = 12;
            lblCopyrights.Height = Convert.ToInt32(TextRenderer.MeasureText(lblCopyrights.Text, lblCopyrights.Font).Height + 2);
            
            lblLinkOrig.Top = lblCopyrights.Top + lblCopyrights.Height + 10;
            lblLinkOrig.Left = 15;
            lblLinkOrig.Height = Convert.ToInt32(TextRenderer.MeasureText(lblLinkOrig.Text, lblLinkOrig.Font).Height + 2);
            
            lblGPL.Top = lblLinkOrig.Top + lblLinkOrig.Height + 10;
            lblGPL.Left = 12;
            lblGPL.Height = Convert.ToInt32(TextRenderer.MeasureText(lblGPL.Text, lblGPL.Font).Height + 2);
            lblGPL.Width = Convert.ToInt32(TextRenderer.MeasureText(lblGPL.Text, lblGPL.Font).Width + 2);
            
            btnClose.Top = lblGPL.Top + lblGPL.Height - btnClose.Height;
            btnClose.Left = lblGPL.Left + lblGPL.Width - btnClose.Width;
            
            pictureBox1.Top = 12;
            pictureBox1.Left = lblGPL.Left + lblGPL.Width - pictureBox1.Width;

            this.Height = btnClose.Top + btnClose.Height + 12 + (this.Height - this.ClientSize.Height);
            this.Width = btnClose.Left + btnClose.Width + 12 + (this.Width - this.ClientSize.Width);
            this.CenterToParent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gnu.org/licenses/gpl.txt");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://fahstats.sourceforge.net/");
        }

    }
}