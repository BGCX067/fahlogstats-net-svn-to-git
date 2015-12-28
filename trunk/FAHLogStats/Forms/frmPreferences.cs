/*
 * FAHLogStats.NET - User Preferences Form
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

using FAHLogStats.Preferences;

namespace FAHLogStats.Forms
{
    public partial class frmPreferences : Form
    {

        public PreferenceSet Prefs;

        public frmPreferences()
        {
            InitializeComponent();

            #region Second Tab (forces width)

            // Layout the second tab (forces width)
            grpUpdateData.Left = 6;
            grpUpdateData.Top = 6;

            lbl2AutoCollect.Top = 24;
            lbl2AutoCollect.Left = 6;
            lbl2AutoCollect.Height = Convert.ToInt32(TextRenderer.MeasureText(lbl2AutoCollect.Text, lbl2AutoCollect.Font).Height + 2);
            lbl2AutoCollect.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl2AutoCollect.Text, lbl2AutoCollect.Font).Width + 2);

            chkAppStart.Top = lbl2AutoCollect.Top + lbl2AutoCollect.Height + 6;
            chkAppStart.Left = 32;
            chkAppStart.Width = 24 + Convert.ToInt32(TextRenderer.MeasureText(chkAppStart.Text, chkAppStart.Font).Width + 2);
            chkAppStart.Height = Convert.ToInt32(TextRenderer.MeasureText(chkAppStart.Text, chkAppStart.Font).Height + 2);

            chkScheduled.Top = chkAppStart.Top;
            chkScheduled.Left = chkAppStart.Left + chkAppStart.Width + 30;
            chkScheduled.Height = chkAppStart.Height;
            chkScheduled.Width = 20 + Convert.ToInt32(TextRenderer.MeasureText(chkScheduled.Text, chkScheduled.Font).Width);

            txtCollectMinutes.Top = chkScheduled.Top - 2;
            txtCollectMinutes.Left = chkScheduled.Left + chkScheduled.Width;
            txtCollectMinutes.Width = Convert.ToInt32(TextRenderer.MeasureText("999", txtCollectMinutes.Font).Width + 2);
            txtCollectMinutes.Height = Convert.ToInt32(TextRenderer.MeasureText("999", txtCollectMinutes.Font).Height + 6);

            lbl2SchedExplain.Top = chkScheduled.Top + 1;
            lbl2SchedExplain.Left = txtCollectMinutes.Left + txtCollectMinutes.Width + 2;
            lbl2SchedExplain.Height = lbl2AutoCollect.Height;
            lbl2SchedExplain.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl2SchedExplain.Text, lbl2SchedExplain.Font).Width + 2);

            grpUpdateData.Width = lbl2SchedExplain.Left + lbl2SchedExplain.Width + 12;
            grpUpdateData.Height = txtCollectMinutes.Top + txtCollectMinutes.Height + 12;

            grpHTMLOutput.Top = grpUpdateData.Top + grpUpdateData.Height + 12;
            grpHTMLOutput.Width = grpUpdateData.Width;
            grpHTMLOutput.Left = 6;

            chkWebSiteGenerator.Top = 24;
            chkWebSiteGenerator.Left = 12;
            chkWebSiteGenerator.Height = Convert.ToInt32(TextRenderer.MeasureText(chkWebSiteGenerator.Text, chkWebSiteGenerator.Font).Height + 2);
            chkWebSiteGenerator.Width = 22 + Convert.ToInt32(TextRenderer.MeasureText(chkWebSiteGenerator.Text, chkWebSiteGenerator.Font).Width + 2);

            txtWebGenMinutes.Height = txtCollectMinutes.Height;
            txtWebGenMinutes.Width = txtCollectMinutes.Height;
            txtWebGenMinutes.Left = chkWebSiteGenerator.Left + chkWebSiteGenerator.Width;
            txtWebGenMinutes.Top = chkWebSiteGenerator.Top - 2;

            lbl2MinutesToGen.Left = txtWebGenMinutes.Left + txtWebGenMinutes.Width + 2;
            lbl2MinutesToGen.Top = chkWebSiteGenerator.Top;
            lbl2MinutesToGen.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl2MinutesToGen.Text, lbl2MinutesToGen.Font).Width + 2);
            lbl2MinutesToGen.Height = Convert.ToInt32(TextRenderer.MeasureText(lbl2MinutesToGen.Text, lbl2MinutesToGen.Font).Height + 2);

            txtWebSiteBase.Top = txtWebGenMinutes.Top + txtWebGenMinutes.Height + 6;
            
            lbl2WebSiteDir.Left = chkWebSiteGenerator.Left + 16;
            lbl2WebSiteDir.Top = txtWebSiteBase.Top + 2;
            lbl2WebSiteDir.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl2WebSiteDir.Text, lbl2WebSiteDir.Font).Width + 2);
            lbl2WebSiteDir.Height = Convert.ToInt32(TextRenderer.MeasureText(lbl2WebSiteDir.Text, lbl2WebSiteDir.Font).Height + 2);

            btnBrowseWebFolder.Width = Convert.ToInt32(TextRenderer.MeasureText(btnBrowseWebFolder.Text, btnBrowseWebFolder.Font).Width + 16);
            btnBrowseWebFolder.Top = txtWebSiteBase.Top;
            btnBrowseWebFolder.Height = txtWebSiteBase.Height;
            btnBrowseWebFolder.Left = grpHTMLOutput.Width - 12 - btnBrowseWebFolder.Width;

            txtWebSiteBase.Left = lbl2WebSiteDir.Left + lbl2WebSiteDir.Width + 6;
            txtWebSiteBase.Width = btnBrowseWebFolder.Left - txtWebSiteBase.Left - 6;
            txtWebSiteBase.Height = Convert.ToInt32(TextRenderer.MeasureText("C:\\ABCDEFGgjklpqy", txtWebSiteBase.Font).Width + 2);

            grpHTMLOutput.Height = txtWebSiteBase.Top + txtWebSiteBase.Height + 12;
#endregion

            #region Third Tab (forces height)
            // Layout the third tab (forces height)
            grpWebStats.Left = 6;
            grpWebStats.Top = 6;

            lbl3EOCUserID.Left = 6;
            lbl3StanfordUserID.Left = 6;
            lbl3StanfordTeamID.Left = 6;

            lbl3EOCUserID.Width = TextRenderer.MeasureText(lbl3EOCUserID.Text, lbl3EOCUserID.Font).Width + 2;
            lbl3StanfordUserID.Width = lbl3EOCUserID.Width;
            lbl3StanfordTeamID.Width = lbl3EOCUserID.Width;

            lbl3EOCUserID.Height = TextRenderer.MeasureText(lbl3EOCUserID.Text, lbl3EOCUserID.Font).Height + 2;
            lbl3StanfordUserID.Height = lbl3EOCUserID.Height;
            lbl3StanfordTeamID.Height = lbl3EOCUserID.Height;

            txtEOCUserID.Left = lbl3EOCUserID.Left + lbl3EOCUserID.Width + 6;
            txtStanfordUserID.Left = txtEOCUserID.Left;
            txtStanfordTeamID.Left = txtEOCUserID.Left;

            txtEOCUserID.Height = TextRenderer.MeasureText("ABCDltgypq", txtEOCUserID.Font).Height + 2;
            txtStanfordUserID.Height = txtEOCUserID.Height;
            txtStanfordTeamID.Height = txtEOCUserID.Height;

            txtEOCUserID.Top = 21;
            txtStanfordUserID.Top = txtEOCUserID.Top + txtEOCUserID.Height + 6;
            txtStanfordTeamID.Top = txtStanfordUserID.Top + txtStanfordUserID.Height + 6;

            txtEOCUserID.Width = TextRenderer.MeasureText("WWWWWWWWWWWW", txtEOCUserID.Font).Width + 2;
            txtStanfordUserID.Width = txtEOCUserID.Width;
            txtStanfordTeamID.Width = txtEOCUserID.Width;

            lbl3EOCUserID.Top = txtEOCUserID.Top + 2;
            lbl3StanfordUserID.Top = txtStanfordUserID.Top + 2;
            lbl3StanfordTeamID.Top = txtStanfordTeamID.Top + 2;

            linkEOC.Left = txtEOCUserID.Left + txtEOCUserID.Width + 12;
            linkStanford.Left = linkEOC.Left;
            linkTeam.Left = linkStanford.Left;

            linkEOC.Top = lbl3EOCUserID.Top;
            linkStanford.Top = lbl3StanfordUserID.Top;
            linkTeam.Top = lbl3StanfordTeamID.Top;

            linkEOC.Width = TextRenderer.MeasureText(linkEOC.Text, linkEOC.Font).Width + 2;
            linkStanford.Width = TextRenderer.MeasureText(linkStanford.Text, linkStanford.Font).Width + 2;
            linkTeam.Width = TextRenderer.MeasureText(linkTeam.Text, linkTeam.Font).Width + 2;

            grpWebStats.Width = grpUpdateData.Width;
            grpWebStats.Height = txtStanfordTeamID.Top + txtStanfordTeamID.Height + 12;

            grpWebProxy.Top = grpWebStats.Top + grpWebStats.Height + 6;
            grpWebProxy.Left = grpWebStats.Left;
            grpWebProxy.Width = grpWebStats.Width;

            chkUseProxy.Top = 24;
            chkUseProxy.Left = 6;
            chkUseProxy.Height = TextRenderer.MeasureText(chkUseProxy.Text, chkUseProxy.Font).Height + 2;
            chkUseProxy.Width = TextRenderer.MeasureText(chkUseProxy.Text, chkUseProxy.Font).Width + 2;

            // Layout the proxy and port line

            lbl3Proxy.Top = chkUseProxy.Top + chkUseProxy.Height + 6;
            lbl3Proxy.Left = chkUseProxy.Left + 20;
            lbl3Proxy.Width = TextRenderer.MeasureText(lbl3Proxy.Text, lbl3Proxy.Font).Height + 2;
            lbl3Proxy.Height = TextRenderer.MeasureText(lbl3Proxy.Text, lbl3Proxy.Font).Height + 2;

            txtProxyServer.Top = lbl3Proxy.Top - 2;
            txtProxyServer.Height = TextRenderer.MeasureText("ABCDltgypq", txtProxyServer.Font).Height + 2;
            txtProxyServer.Left = lbl3Proxy.Left + lbl3Proxy.Width + 6;
            
            txtProxyPort.Top = txtProxyServer.Top;
            txtProxyPort.Height = txtProxyServer.Height;
            txtProxyPort.Width = TextRenderer.MeasureText("99999999", txtProxyUser.Font).Width + 2;
            txtProxyPort.Left = grpWebProxy.Width - txtProxyPort.Width - 6;

            lbl3Port.Top = lbl3Proxy.Top;
            lbl3Port.Height = lbl3Proxy.Height;
            lbl3Port.Width = TextRenderer.MeasureText(lbl3Port.Text, lbl3Port.Font).Width + 2;
            lbl3Port.Left = txtProxyPort.Left - lbl3Port.Width - 6;

            txtProxyServer.Width = lbl3Port.Left - txtProxyServer.Left - 6;

            chkUseProxyAuth.Top = txtProxyServer.Top + txtProxyServer.Height + 6;
            chkUseProxyAuth.Left = lbl3Proxy.Left;
            chkUseProxyAuth.Width = 20 + TextRenderer.MeasureText(chkUseProxyAuth.Text, chkUseProxyAuth.Font).Width + 2;
            chkUseProxyAuth.Height = TextRenderer.MeasureText(chkUseProxyAuth.Text, chkUseProxyAuth.Font).Height + 2;

            // Layout the username and password line

            lbl3ProxyUser.Width = TextRenderer.MeasureText(lbl3ProxyUser.Text, lbl3ProxyUser.Font).Width + 2;
            lbl3ProxyUser.Height = TextRenderer.MeasureText(lbl3ProxyUser.Text, lbl3ProxyUser.Font).Height + 2;
            lbl3ProxyUser.Left = chkUseProxyAuth.Left + 20;
            lbl3ProxyUser.Top = chkUseProxyAuth.Top + chkUseProxyAuth.Height + 6;
            
            lbl3ProxyPass.Width = TextRenderer.MeasureText(lbl3ProxyPass.Text, lbl3ProxyPass.Font).Width + 2;
            lbl3ProxyPass.Height = TextRenderer.MeasureText(lbl3ProxyPass.Text, lbl3ProxyPass.Font).Height + 2;
            lbl3ProxyPass.Top = lbl3ProxyUser.Top;

            Int32 SpaceLeft = grpWebProxy.Width - (lbl3ProxyPass.Width + lbl3ProxyUser.Width + lbl3ProxyUser.Left) - 18;

            txtProxyUser.Left = lbl3ProxyUser.Left + lbl3ProxyUser.Width + 6;
            txtProxyUser.Top = lbl3ProxyUser.Top - 2;
            txtProxyUser.Height = TextRenderer.MeasureText(txtProxyUser.Text, txtProxyUser.Font).Height + 2;
            txtProxyUser.Width = Convert.ToInt32(Math.Ceiling(SpaceLeft / 2d));

            txtProxyPass.Width = SpaceLeft - txtProxyUser.Width;
            txtProxyPass.Height = TextRenderer.MeasureText(txtProxyPass.Text, txtProxyPass.Font).Height + 2;
            txtProxyPass.Left = grpWebProxy.Width - txtProxyPass.Width - 6;
            txtProxyPass.Top = lbl3ProxyPass.Top - 2;

            lbl3ProxyPass.Left = txtProxyUser.Left + txtProxyUser.Width + 6;
            grpWebProxy.Height = txtProxyUser.Top + txtProxyUser.Height + 12;

            #endregion

            #region Dialog box layout
            // Layout the other controls
            tabControl1.Left = 12;
            tabControl1.Top = 12;
            tabControl1.Width = grpUpdateData.Width + 24;
            tabControl1.Height = grpWebProxy.Top + grpWebProxy.Height + 24;

            btnCancel.Top = tabControl1.Top + tabControl1.Height + 6;
            btnCancel.Left = tabControl1.Left + tabControl1.Width - btnCancel.Width;

            btnOK.Top = btnCancel.Top;
            btnOK.Left = btnCancel.Left - 6 - btnOK.Width;

            this.Height = btnCancel.Top + btnCancel.Height + 36;
            this.Width = btnCancel.Left + btnCancel.Width + 18;
            #endregion

            #region First Tab Layout
            // Layout the first tab
            lbl1Style.Top = 6;
            lbl1Style.Left = 6;
            lbl1Style.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl1Style.Text, lbl1Style.Font).Width + 2);
            lbl1Style.Height = Convert.ToInt32(TextRenderer.MeasureText(lbl1Style.Text, lbl1Style.Font).Height + 2);

            lbl1Preview.Top = 6;
            lbl1Preview.Left = 150;
            lbl1Preview.Width = Convert.ToInt32(TextRenderer.MeasureText(lbl1Preview.Text, lbl1Preview.Font).Width + 2);
            lbl1Preview.Height = Convert.ToInt32(TextRenderer.MeasureText(lbl1Preview.Text, lbl1Preview.Font).Height + 2);

            StyleList.Left = 6;
            StyleList.Top = lbl1Style.Top + lbl1Style.Height + 6;
            StyleList.Width = 138;
            StyleList.Height = (grpWebProxy.Top + grpWebProxy.Height) - StyleList.Top - 12;

            pnl1CSSSample.Top = StyleList.Top;
            pnl1CSSSample.Height = StyleList.Height;
            pnl1CSSSample.Left = lbl1Preview.Left;
            pnl1CSSSample.Width = tabControl1.Width - pnl1CSSSample.Left - 12;
            #endregion

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScheduled.Checked)
            {
                txtCollectMinutes.ReadOnly = false;
            }
            else
            {
                txtCollectMinutes.ReadOnly = true;
            }
        }

        private void txtMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMinutes_Validating(object sender, CancelEventArgs e)
        {
            int Minutes = 0;
            try
            {
                Minutes = Convert.ToInt16(txtCollectMinutes.Text);
            }
            catch
            {
                e.Cancel = true;
            }
            if ((Minutes > 180) || (Minutes < 1))
            {
                e.Cancel = true;
            }
            if (e.Cancel)
            {
                Microsoft.VisualBasic.Interaction.Beep();
            }
        }

        private void frmPreferences_Shown(object sender, EventArgs e)
        {
            Prefs = PreferenceSet.Instance;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1) + "CSS");
            StyleList.Items.Clear();
            foreach (System.IO.FileInfo fi in di.GetFiles())
            {
                StyleList.Items.Add(fi.Name.ToString().ToLower().Replace(".css", ""));
            }

            // Visual Style tab
            StyleList.SelectedItem = Prefs.CSSFileName.ToLower().Replace(".css", "");

            // Scheduled Tasks tab
            txtWebGenMinutes.Text = Prefs.GenerateInterval.ToString();
            chkWebSiteGenerator.Checked = Prefs.GenerateWeb;
            chkAppStart.Checked = Prefs.SyncOnLoad;
            chkScheduled.Checked = Prefs.SyncOnSchedule;
            txtCollectMinutes.Text = Prefs.SyncTimeMinutes.ToString();
            txtWebSiteBase.Text = Prefs.WebRoot;

            // Web
            txtEOCUserID.Text = Prefs.EOCUserID.ToString();
            txtStanfordUserID.Text = Prefs.StanfordID;
            txtStanfordTeamID.Text = Prefs.TeamID.ToString();
            chkUseProxy.Checked = Prefs.UseProxy;
            chkUseProxyAuth.Checked = Prefs.UseProxyAuth;
            txtProxyServer.Text = Prefs.ProxyServer;
            txtProxyPort.Text = Prefs.ProxyPort.ToString();
            txtProxyUser.Text = Prefs.ProxyUser;
            txtProxyPass.Text = Prefs.ProxyPass;
        }

        private void StyleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sStylesheet = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1) + "CSS\\" + StyleList.SelectedItem + ".css";
            StringBuilder sb = new StringBuilder();

            sb.Append("<HTML><HEAD><TITLE>Test CSS File</TITLE>");
            sb.Append("<LINK REL=\"Stylesheet\" TYPE=\"text/css\" href=\"file:///" + sStylesheet + "\" />");
            sb.Append("</HEAD><BODY>");

            sb.Append("<table class=\"Instance\">");
            sb.Append("<tr>");
            sb.Append("<td class=\"Heading\">Heading</td>");
            sb.Append("<td class=\"Blank\" width=\"100%\"></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td class=\"LeftCol\">Left Col</td>");
            sb.Append("<td class=\"RightCol\">Right Column</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td class=\"AltLeftCol\">Left Col</td>");
            sb.Append("<td class=\"AltRightCol\">Right Column</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td class=\"LeftCol\">Left Col</td>");
            sb.Append("<td class=\"RightCol\">Right Column</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td class=\"AltLeftCol\">Left Col</td>");
            sb.Append("<td class=\"AltRightCol\">Right Column</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(String.Format("<td class=\"Plain\" colspan=\"2\" align=\"center\">Last updated {0} at {1}</td>", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</BODY></HTML>");

            wbCssSample.DocumentText = sb.ToString();
        }

        private void chkWebSiteGenerator_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWebSiteGenerator.Checked)
            {
                txtWebGenMinutes.Enabled = true;
                txtWebGenMinutes.ReadOnly = false;
                txtWebSiteBase.Enabled = true;
                txtWebSiteBase.ReadOnly = false;
                btnBrowseWebFolder.Enabled = true;
            }
            else
            {
                txtWebGenMinutes.Enabled = false;
                txtWebGenMinutes.ReadOnly = true;
                txtWebSiteBase.Enabled = false;
                txtWebSiteBase.ReadOnly = true;
                btnBrowseWebFolder.Enabled = false;
            }
        }

        private void btnBrowseWebFolder_Click(object sender, EventArgs e)
        {
            if (txtWebSiteBase.Text != String.Empty)
                locateWebFolder.SelectedPath = txtWebSiteBase.Text;
            if (locateWebFolder.ShowDialog() == DialogResult.OK)
            {
                txtWebSiteBase.Text = locateWebFolder.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Visual Styles tab
            Prefs.CSSFileName = StyleList.SelectedItem + ".css";

            // Scheduled Tasks tab
            Prefs.GenerateInterval = Int32.Parse(txtWebGenMinutes.Text);
            Prefs.GenerateWeb = chkWebSiteGenerator.Checked;
            Prefs.SyncOnLoad = chkAppStart.Checked;
            Prefs.SyncOnSchedule = chkScheduled.Checked;
            Prefs.SyncTimeMinutes = Int32.Parse(txtCollectMinutes.Text);
            Prefs.WebRoot = txtWebSiteBase.Text;

            // Web Settings tab
            Prefs.EOCUserID = Int32.Parse(txtEOCUserID.Text);
            Prefs.StanfordID = txtStanfordUserID.Text;
            Prefs.TeamID = Int32.Parse(txtStanfordTeamID.Text);
            Prefs.UseProxy = chkUseProxy.Checked;
            Prefs.UseProxyAuth = chkUseProxyAuth.Checked;
            Prefs.ProxyServer = txtProxyServer.Text;
            Prefs.ProxyPort = Int32.Parse(txtProxyPort.Text);
            Prefs.ProxyUser = txtProxyUser.Text;
            Prefs.ProxyPass = txtProxyPass.Text;

            Prefs.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Prefs.Discard();
        }

        private void linkEOC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PreferenceSet.EOCUserBaseURL + txtEOCUserID.Text);
        }

        private void linkStanford_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PreferenceSet.StanfordBaseURL + txtStanfordUserID.Text);
        }

        private void linkTeam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PreferenceSet.EOCTeamBaseURL + txtStanfordTeamID.Text);
        }

        private void EnableProxy()
        {
            txtProxyServer.Enabled = true;
            txtProxyPort.Enabled = true;
            txtProxyServer.ReadOnly = false;
            txtProxyPort.ReadOnly = false;
            chkUseProxyAuth.Enabled = true;
        }

        private void DisableProxy()
        {
            txtProxyServer.Enabled = false;
            txtProxyPort.Enabled = false;
            txtProxyServer.ReadOnly = true;
            txtProxyPort.ReadOnly = true;
            chkUseProxyAuth.Enabled = false;
            DisableProxyAuth();
        }

        private void EnableProxyAuth()
        {
            txtProxyUser.Enabled = true;
            txtProxyUser.ReadOnly = false;
            txtProxyPass.Enabled = true;
            txtProxyPass.ReadOnly = false;
        }

        private void DisableProxyAuth()
        {
            txtProxyUser.Enabled = false;
            txtProxyUser.ReadOnly = true;
            txtProxyPass.Enabled = false;
            txtProxyPass.ReadOnly = true;
        }

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseProxy.Checked)
            {
                EnableProxy();
                if (chkUseProxyAuth.Checked)
                    EnableProxyAuth();
            }
            else
            {
                DisableProxy();
            }
        }

        private void chkUseProxyAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseProxyAuth.Checked)
                EnableProxyAuth();
            else
                DisableProxyAuth();
        }
    }
}