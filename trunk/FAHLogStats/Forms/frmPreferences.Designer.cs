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

namespace FAHLogStats.Forms
{
    partial class frmPreferences
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
            this.grpUpdateData = new System.Windows.Forms.GroupBox();
            this.txtCollectMinutes = new System.Windows.Forms.TextBox();
            this.lbl2SchedExplain = new System.Windows.Forms.Label();
            this.chkScheduled = new System.Windows.Forms.CheckBox();
            this.chkAppStart = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbl1Preview = new System.Windows.Forms.Label();
            this.lbl1Style = new System.Windows.Forms.Label();
            this.pnl1CSSSample = new System.Windows.Forms.Panel();
            this.wbCssSample = new System.Windows.Forms.WebBrowser();
            this.StyleList = new System.Windows.Forms.ListBox();
            this.grpHTMLOutput = new System.Windows.Forms.GroupBox();
            this.txtWebGenMinutes = new System.Windows.Forms.TextBox();
            this.lbl2MinutesToGen = new System.Windows.Forms.Label();
            this.btnBrowseWebFolder = new System.Windows.Forms.Button();
            this.txtWebSiteBase = new System.Windows.Forms.TextBox();
            this.lbl2WebSiteDir = new System.Windows.Forms.Label();
            this.chkWebSiteGenerator = new System.Windows.Forms.CheckBox();
            this.locateWebFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVisStyles = new System.Windows.Forms.TabPage();
            this.tabSchdTasks = new System.Windows.Forms.TabPage();
            this.tabWeb = new System.Windows.Forms.TabPage();
            this.grpWebStats = new System.Windows.Forms.GroupBox();
            this.lbl3EOCUserID = new System.Windows.Forms.Label();
            this.lbl3StanfordUserID = new System.Windows.Forms.Label();
            this.linkTeam = new System.Windows.Forms.LinkLabel();
            this.txtEOCUserID = new System.Windows.Forms.TextBox();
            this.txtStanfordTeamID = new System.Windows.Forms.TextBox();
            this.lbl3StanfordTeamID = new System.Windows.Forms.Label();
            this.linkStanford = new System.Windows.Forms.LinkLabel();
            this.txtStanfordUserID = new System.Windows.Forms.TextBox();
            this.linkEOC = new System.Windows.Forms.LinkLabel();
            this.grpWebProxy = new System.Windows.Forms.GroupBox();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.chkUseProxyAuth = new System.Windows.Forms.CheckBox();
            this.txtProxyPass = new System.Windows.Forms.TextBox();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.lbl3ProxyPass = new System.Windows.Forms.Label();
            this.txtProxyServer = new System.Windows.Forms.TextBox();
            this.lbl3ProxyUser = new System.Windows.Forms.Label();
            this.lbl3Port = new System.Windows.Forms.Label();
            this.lbl3Proxy = new System.Windows.Forms.Label();
            this.lbl2AutoCollect = new System.Windows.Forms.Label();
            this.grpUpdateData.SuspendLayout();
            this.pnl1CSSSample.SuspendLayout();
            this.grpHTMLOutput.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabVisStyles.SuspendLayout();
            this.tabSchdTasks.SuspendLayout();
            this.tabWeb.SuspendLayout();
            this.grpWebStats.SuspendLayout();
            this.grpWebProxy.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUpdateData
            // 
            this.grpUpdateData.Controls.Add(this.lbl2AutoCollect);
            this.grpUpdateData.Controls.Add(this.txtCollectMinutes);
            this.grpUpdateData.Controls.Add(this.lbl2SchedExplain);
            this.grpUpdateData.Controls.Add(this.chkScheduled);
            this.grpUpdateData.Controls.Add(this.chkAppStart);
            this.grpUpdateData.Location = new System.Drawing.Point(6, 6);
            this.grpUpdateData.Name = "grpUpdateData";
            this.grpUpdateData.Size = new System.Drawing.Size(485, 71);
            this.grpUpdateData.TabIndex = 0;
            this.grpUpdateData.TabStop = false;
            this.grpUpdateData.Text = "Update Data";
            // 
            // txtCollectMinutes
            // 
            this.txtCollectMinutes.Location = new System.Drawing.Point(294, 39);
            this.txtCollectMinutes.MaxLength = 3;
            this.txtCollectMinutes.Name = "txtCollectMinutes";
            this.txtCollectMinutes.Size = new System.Drawing.Size(48, 20);
            this.txtCollectMinutes.TabIndex = 3;
            this.txtCollectMinutes.Text = "15";
            this.txtCollectMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCollectMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutes_KeyPress);
            this.txtCollectMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinutes_Validating);
            // 
            // lbl2SchedExplain
            // 
            this.lbl2SchedExplain.Location = new System.Drawing.Point(343, 42);
            this.lbl2SchedExplain.Name = "lbl2SchedExplain";
            this.lbl2SchedExplain.Size = new System.Drawing.Size(147, 17);
            this.lbl2SchedExplain.TabIndex = 4;
            this.lbl2SchedExplain.Text = "minutes while running";
            // 
            // chkScheduled
            // 
            this.chkScheduled.Checked = true;
            this.chkScheduled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScheduled.Location = new System.Drawing.Point(244, 41);
            this.chkScheduled.Name = "chkScheduled";
            this.chkScheduled.Size = new System.Drawing.Size(58, 18);
            this.chkScheduled.TabIndex = 2;
            this.chkScheduled.Text = "Every";
            this.chkScheduled.UseVisualStyleBackColor = true;
            this.chkScheduled.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkAppStart
            // 
            this.chkAppStart.Checked = true;
            this.chkAppStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAppStart.Location = new System.Drawing.Point(10, 41);
            this.chkAppStart.Name = "chkAppStart";
            this.chkAppStart.Size = new System.Drawing.Size(243, 18);
            this.chkAppStart.TabIndex = 1;
            this.chkAppStart.Text = "When a configuration file is loaded";
            this.chkAppStart.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(447, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(366, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbl1Preview
            // 
            this.lbl1Preview.Location = new System.Drawing.Point(129, 6);
            this.lbl1Preview.Name = "lbl1Preview";
            this.lbl1Preview.Size = new System.Drawing.Size(67, 23);
            this.lbl1Preview.TabIndex = 2;
            this.lbl1Preview.Text = "Preview";
            // 
            // lbl1Style
            // 
            this.lbl1Style.Location = new System.Drawing.Point(3, 6);
            this.lbl1Style.Name = "lbl1Style";
            this.lbl1Style.Size = new System.Drawing.Size(84, 23);
            this.lbl1Style.TabIndex = 0;
            this.lbl1Style.Text = "Style Sheet";
            // 
            // pnl1CSSSample
            // 
            this.pnl1CSSSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl1CSSSample.Controls.Add(this.wbCssSample);
            this.pnl1CSSSample.Location = new System.Drawing.Point(132, 31);
            this.pnl1CSSSample.Name = "pnl1CSSSample";
            this.pnl1CSSSample.Size = new System.Drawing.Size(358, 212);
            this.pnl1CSSSample.TabIndex = 1;
            // 
            // wbCssSample
            // 
            this.wbCssSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbCssSample.Location = new System.Drawing.Point(0, 0);
            this.wbCssSample.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbCssSample.Name = "wbCssSample";
            this.wbCssSample.Size = new System.Drawing.Size(354, 208);
            this.wbCssSample.TabIndex = 0;
            // 
            // StyleList
            // 
            this.StyleList.FormattingEnabled = true;
            this.StyleList.Location = new System.Drawing.Point(6, 31);
            this.StyleList.Name = "StyleList";
            this.StyleList.Size = new System.Drawing.Size(120, 212);
            this.StyleList.Sorted = true;
            this.StyleList.TabIndex = 1;
            this.StyleList.SelectedIndexChanged += new System.EventHandler(this.StyleList_SelectedIndexChanged);
            // 
            // grpHTMLOutput
            // 
            this.grpHTMLOutput.Controls.Add(this.txtWebGenMinutes);
            this.grpHTMLOutput.Controls.Add(this.lbl2MinutesToGen);
            this.grpHTMLOutput.Controls.Add(this.btnBrowseWebFolder);
            this.grpHTMLOutput.Controls.Add(this.txtWebSiteBase);
            this.grpHTMLOutput.Controls.Add(this.lbl2WebSiteDir);
            this.grpHTMLOutput.Controls.Add(this.chkWebSiteGenerator);
            this.grpHTMLOutput.Location = new System.Drawing.Point(6, 83);
            this.grpHTMLOutput.Name = "grpHTMLOutput";
            this.grpHTMLOutput.Size = new System.Drawing.Size(485, 76);
            this.grpHTMLOutput.TabIndex = 1;
            this.grpHTMLOutput.TabStop = false;
            this.grpHTMLOutput.Text = "HTML Output";
            // 
            // txtWebGenMinutes
            // 
            this.txtWebGenMinutes.Enabled = false;
            this.txtWebGenMinutes.Location = new System.Drawing.Point(166, 17);
            this.txtWebGenMinutes.MaxLength = 3;
            this.txtWebGenMinutes.Name = "txtWebGenMinutes";
            this.txtWebGenMinutes.ReadOnly = true;
            this.txtWebGenMinutes.Size = new System.Drawing.Size(48, 20);
            this.txtWebGenMinutes.TabIndex = 1;
            this.txtWebGenMinutes.Text = "15";
            this.txtWebGenMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWebGenMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutes_KeyPress);
            this.txtWebGenMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinutes_Validating);
            // 
            // lbl2MinutesToGen
            // 
            this.lbl2MinutesToGen.AutoSize = true;
            this.lbl2MinutesToGen.Location = new System.Drawing.Point(217, 21);
            this.lbl2MinutesToGen.Name = "lbl2MinutesToGen";
            this.lbl2MinutesToGen.Size = new System.Drawing.Size(51, 15);
            this.lbl2MinutesToGen.TabIndex = 2;
            this.lbl2MinutesToGen.Text = "minutes";
            // 
            // btnBrowseWebFolder
            // 
            this.btnBrowseWebFolder.Enabled = false;
            this.btnBrowseWebFolder.Location = new System.Drawing.Point(445, 43);
            this.btnBrowseWebFolder.Name = "btnBrowseWebFolder";
            this.btnBrowseWebFolder.Size = new System.Drawing.Size(24, 23);
            this.btnBrowseWebFolder.TabIndex = 5;
            this.btnBrowseWebFolder.Text = "...";
            this.btnBrowseWebFolder.UseVisualStyleBackColor = true;
            this.btnBrowseWebFolder.Click += new System.EventHandler(this.btnBrowseWebFolder_Click);
            // 
            // txtWebSiteBase
            // 
            this.txtWebSiteBase.Enabled = false;
            this.txtWebSiteBase.Location = new System.Drawing.Point(112, 45);
            this.txtWebSiteBase.Name = "txtWebSiteBase";
            this.txtWebSiteBase.ReadOnly = true;
            this.txtWebSiteBase.Size = new System.Drawing.Size(327, 20);
            this.txtWebSiteBase.TabIndex = 4;
            this.txtWebSiteBase.Text = "C:\\INetPub\\WWWRoot\\MyFolding";
            // 
            // lbl2WebSiteDir
            // 
            this.lbl2WebSiteDir.AutoSize = true;
            this.lbl2WebSiteDir.Location = new System.Drawing.Point(26, 48);
            this.lbl2WebSiteDir.Name = "lbl2WebSiteDir";
            this.lbl2WebSiteDir.Size = new System.Drawing.Size(89, 15);
            this.lbl2WebSiteDir.TabIndex = 3;
            this.lbl2WebSiteDir.Text = "In the directory:";
            // 
            // chkWebSiteGenerator
            // 
            this.chkWebSiteGenerator.AutoSize = true;
            this.chkWebSiteGenerator.Location = new System.Drawing.Point(7, 20);
            this.chkWebSiteGenerator.Name = "chkWebSiteGenerator";
            this.chkWebSiteGenerator.Size = new System.Drawing.Size(158, 19);
            this.chkWebSiteGenerator.TabIndex = 0;
            this.chkWebSiteGenerator.Text = "Create a Web Site, every";
            this.chkWebSiteGenerator.UseVisualStyleBackColor = true;
            this.chkWebSiteGenerator.CheckedChanged += new System.EventHandler(this.chkWebSiteGenerator_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabVisStyles);
            this.tabControl1.Controls.Add(this.tabSchdTasks);
            this.tabControl1.Controls.Add(this.tabWeb);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(509, 276);
            this.tabControl1.TabIndex = 5;
            // 
            // tabVisStyles
            // 
            this.tabVisStyles.BackColor = System.Drawing.SystemColors.Control;
            this.tabVisStyles.Controls.Add(this.pnl1CSSSample);
            this.tabVisStyles.Controls.Add(this.lbl1Preview);
            this.tabVisStyles.Controls.Add(this.StyleList);
            this.tabVisStyles.Controls.Add(this.lbl1Style);
            this.tabVisStyles.Location = new System.Drawing.Point(4, 22);
            this.tabVisStyles.Name = "tabVisStyles";
            this.tabVisStyles.Size = new System.Drawing.Size(501, 250);
            this.tabVisStyles.TabIndex = 3;
            this.tabVisStyles.Text = "Visual Styles";
            // 
            // tabSchdTasks
            // 
            this.tabSchdTasks.BackColor = System.Drawing.SystemColors.Control;
            this.tabSchdTasks.Controls.Add(this.grpUpdateData);
            this.tabSchdTasks.Controls.Add(this.grpHTMLOutput);
            this.tabSchdTasks.Location = new System.Drawing.Point(4, 22);
            this.tabSchdTasks.Name = "tabSchdTasks";
            this.tabSchdTasks.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabSchdTasks.Size = new System.Drawing.Size(501, 250);
            this.tabSchdTasks.TabIndex = 2;
            this.tabSchdTasks.Text = "Scheduled Tasks";
            // 
            // tabWeb
            // 
            this.tabWeb.BackColor = System.Drawing.SystemColors.Control;
            this.tabWeb.Controls.Add(this.grpWebStats);
            this.tabWeb.Controls.Add(this.grpWebProxy);
            this.tabWeb.Location = new System.Drawing.Point(4, 22);
            this.tabWeb.Name = "tabWeb";
            this.tabWeb.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabWeb.Size = new System.Drawing.Size(501, 250);
            this.tabWeb.TabIndex = 1;
            this.tabWeb.Text = "Web Settings";
            // 
            // grpWebStats
            // 
            this.grpWebStats.Controls.Add(this.lbl3EOCUserID);
            this.grpWebStats.Controls.Add(this.lbl3StanfordUserID);
            this.grpWebStats.Controls.Add(this.linkTeam);
            this.grpWebStats.Controls.Add(this.txtEOCUserID);
            this.grpWebStats.Controls.Add(this.txtStanfordTeamID);
            this.grpWebStats.Controls.Add(this.lbl3StanfordTeamID);
            this.grpWebStats.Controls.Add(this.linkStanford);
            this.grpWebStats.Controls.Add(this.txtStanfordUserID);
            this.grpWebStats.Controls.Add(this.linkEOC);
            this.grpWebStats.Location = new System.Drawing.Point(6, 9);
            this.grpWebStats.Name = "grpWebStats";
            this.grpWebStats.Size = new System.Drawing.Size(486, 102);
            this.grpWebStats.TabIndex = 9;
            this.grpWebStats.TabStop = false;
            this.grpWebStats.Text = "Web Statistics";
            // 
            // lbl3EOCUserID
            // 
            this.lbl3EOCUserID.AutoSize = true;
            this.lbl3EOCUserID.Location = new System.Drawing.Point(2, 20);
            this.lbl3EOCUserID.Name = "lbl3EOCUserID";
            this.lbl3EOCUserID.Size = new System.Drawing.Size(173, 15);
            this.lbl3EOCUserID.TabIndex = 4;
            this.lbl3EOCUserID.Text = "Extreme Overclocking User ID:";
            // 
            // lbl3StanfordUserID
            // 
            this.lbl3StanfordUserID.AutoSize = true;
            this.lbl3StanfordUserID.Location = new System.Drawing.Point(2, 46);
            this.lbl3StanfordUserID.Name = "lbl3StanfordUserID";
            this.lbl3StanfordUserID.Size = new System.Drawing.Size(100, 15);
            this.lbl3StanfordUserID.TabIndex = 6;
            this.lbl3StanfordUserID.Text = "Stanford User ID:";
            // 
            // linkTeam
            // 
            this.linkTeam.Location = new System.Drawing.Point(338, 72);
            this.linkTeam.Name = "linkTeam";
            this.linkTeam.Size = new System.Drawing.Size(70, 19);
            this.linkTeam.TabIndex = 8;
            this.linkTeam.TabStop = true;
            this.linkTeam.Text = "Test Team ID";
            this.linkTeam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTeam_LinkClicked);
            // 
            // txtEOCUserID
            // 
            this.txtEOCUserID.Location = new System.Drawing.Point(194, 17);
            this.txtEOCUserID.Name = "txtEOCUserID";
            this.txtEOCUserID.Size = new System.Drawing.Size(138, 20);
            this.txtEOCUserID.TabIndex = 5;
            // 
            // txtStanfordTeamID
            // 
            this.txtStanfordTeamID.Location = new System.Drawing.Point(194, 69);
            this.txtStanfordTeamID.Name = "txtStanfordTeamID";
            this.txtStanfordTeamID.Size = new System.Drawing.Size(138, 20);
            this.txtStanfordTeamID.TabIndex = 7;
            // 
            // lbl3StanfordTeamID
            // 
            this.lbl3StanfordTeamID.AutoSize = true;
            this.lbl3StanfordTeamID.Location = new System.Drawing.Point(2, 72);
            this.lbl3StanfordTeamID.Name = "lbl3StanfordTeamID";
            this.lbl3StanfordTeamID.Size = new System.Drawing.Size(106, 15);
            this.lbl3StanfordTeamID.TabIndex = 6;
            this.lbl3StanfordTeamID.Text = "Stanford Team ID:";
            // 
            // linkStanford
            // 
            this.linkStanford.Location = new System.Drawing.Point(338, 46);
            this.linkStanford.Name = "linkStanford";
            this.linkStanford.Size = new System.Drawing.Size(83, 19);
            this.linkStanford.TabIndex = 8;
            this.linkStanford.TabStop = true;
            this.linkStanford.Text = "Test Stanford ID";
            this.linkStanford.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStanford_LinkClicked);
            // 
            // txtStanfordUserID
            // 
            this.txtStanfordUserID.Location = new System.Drawing.Point(194, 43);
            this.txtStanfordUserID.Name = "txtStanfordUserID";
            this.txtStanfordUserID.Size = new System.Drawing.Size(138, 20);
            this.txtStanfordUserID.TabIndex = 7;
            // 
            // linkEOC
            // 
            this.linkEOC.Location = new System.Drawing.Point(338, 20);
            this.linkEOC.Name = "linkEOC";
            this.linkEOC.Size = new System.Drawing.Size(64, 19);
            this.linkEOC.TabIndex = 8;
            this.linkEOC.TabStop = true;
            this.linkEOC.Text = "Test EOC ID";
            this.linkEOC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEOC_LinkClicked);
            // 
            // grpWebProxy
            // 
            this.grpWebProxy.Controls.Add(this.chkUseProxy);
            this.grpWebProxy.Controls.Add(this.chkUseProxyAuth);
            this.grpWebProxy.Controls.Add(this.txtProxyPass);
            this.grpWebProxy.Controls.Add(this.txtProxyUser);
            this.grpWebProxy.Controls.Add(this.txtProxyPort);
            this.grpWebProxy.Controls.Add(this.lbl3ProxyPass);
            this.grpWebProxy.Controls.Add(this.txtProxyServer);
            this.grpWebProxy.Controls.Add(this.lbl3ProxyUser);
            this.grpWebProxy.Controls.Add(this.lbl3Port);
            this.grpWebProxy.Controls.Add(this.lbl3Proxy);
            this.grpWebProxy.Location = new System.Drawing.Point(6, 117);
            this.grpWebProxy.Name = "grpWebProxy";
            this.grpWebProxy.Size = new System.Drawing.Size(489, 122);
            this.grpWebProxy.TabIndex = 9;
            this.grpWebProxy.TabStop = false;
            this.grpWebProxy.Text = "Web Proxy Settings";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(6, 19);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(129, 19);
            this.chkUseProxy.TabIndex = 8;
            this.chkUseProxy.Text = "Use a Proxy Server";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // chkUseProxyAuth
            // 
            this.chkUseProxyAuth.AutoSize = true;
            this.chkUseProxyAuth.Enabled = false;
            this.chkUseProxyAuth.Location = new System.Drawing.Point(25, 68);
            this.chkUseProxyAuth.Name = "chkUseProxyAuth";
            this.chkUseProxyAuth.Size = new System.Drawing.Size(225, 19);
            this.chkUseProxyAuth.TabIndex = 8;
            this.chkUseProxyAuth.Text = "Authenticate to the Web Proxy Server";
            this.chkUseProxyAuth.UseVisualStyleBackColor = true;
            this.chkUseProxyAuth.CheckedChanged += new System.EventHandler(this.chkUseProxyAuth_CheckedChanged);
            // 
            // txtProxyPass
            // 
            this.txtProxyPass.Enabled = false;
            this.txtProxyPass.Location = new System.Drawing.Point(327, 91);
            this.txtProxyPass.Name = "txtProxyPass";
            this.txtProxyPass.ReadOnly = true;
            this.txtProxyPass.Size = new System.Drawing.Size(155, 20);
            this.txtProxyPass.TabIndex = 7;
            this.txtProxyPass.UseSystemPasswordChar = true;
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Enabled = false;
            this.txtProxyUser.Location = new System.Drawing.Point(104, 91);
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.ReadOnly = true;
            this.txtProxyUser.Size = new System.Drawing.Size(155, 20);
            this.txtProxyUser.TabIndex = 7;
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Enabled = false;
            this.txtProxyPort.Location = new System.Drawing.Point(389, 42);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.ReadOnly = true;
            this.txtProxyPort.Size = new System.Drawing.Size(94, 20);
            this.txtProxyPort.TabIndex = 7;
            // 
            // lbl3ProxyPass
            // 
            this.lbl3ProxyPass.AutoSize = true;
            this.lbl3ProxyPass.Location = new System.Drawing.Point(265, 94);
            this.lbl3ProxyPass.Name = "lbl3ProxyPass";
            this.lbl3ProxyPass.Size = new System.Drawing.Size(64, 15);
            this.lbl3ProxyPass.TabIndex = 6;
            this.lbl3ProxyPass.Text = "Password:";
            // 
            // txtProxyServer
            // 
            this.txtProxyServer.Enabled = false;
            this.txtProxyServer.Location = new System.Drawing.Point(98, 42);
            this.txtProxyServer.Name = "txtProxyServer";
            this.txtProxyServer.ReadOnly = true;
            this.txtProxyServer.Size = new System.Drawing.Size(250, 20);
            this.txtProxyServer.TabIndex = 7;
            // 
            // lbl3ProxyUser
            // 
            this.lbl3ProxyUser.AutoSize = true;
            this.lbl3ProxyUser.Location = new System.Drawing.Point(40, 94);
            this.lbl3ProxyUser.Name = "lbl3ProxyUser";
            this.lbl3ProxyUser.Size = new System.Drawing.Size(68, 15);
            this.lbl3ProxyUser.TabIndex = 6;
            this.lbl3ProxyUser.Text = "Username:";
            // 
            // lbl3Port
            // 
            this.lbl3Port.AutoSize = true;
            this.lbl3Port.Location = new System.Drawing.Point(354, 45);
            this.lbl3Port.Name = "lbl3Port";
            this.lbl3Port.Size = new System.Drawing.Size(32, 15);
            this.lbl3Port.TabIndex = 6;
            this.lbl3Port.Text = "Port:";
            // 
            // lbl3Proxy
            // 
            this.lbl3Proxy.AutoSize = true;
            this.lbl3Proxy.Location = new System.Drawing.Point(22, 45);
            this.lbl3Proxy.Name = "lbl3Proxy";
            this.lbl3Proxy.Size = new System.Drawing.Size(78, 15);
            this.lbl3Proxy.TabIndex = 6;
            this.lbl3Proxy.Text = "Proxy Server:";
            // 
            // lbl2AutoCollect
            // 
            this.lbl2AutoCollect.AutoSize = true;
            this.lbl2AutoCollect.Location = new System.Drawing.Point(7, 19);
            this.lbl2AutoCollect.Name = "lbl2AutoCollect";
            this.lbl2AutoCollect.Size = new System.Drawing.Size(179, 15);
            this.lbl2AutoCollect.TabIndex = 5;
            this.lbl2AutoCollect.Text = "Automatically collect client data:";
            // 
            // frmPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 326);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Shown += new System.EventHandler(this.frmPreferences_Shown);
            this.grpUpdateData.ResumeLayout(false);
            this.grpUpdateData.PerformLayout();
            this.pnl1CSSSample.ResumeLayout(false);
            this.grpHTMLOutput.ResumeLayout(false);
            this.grpHTMLOutput.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabVisStyles.ResumeLayout(false);
            this.tabSchdTasks.ResumeLayout(false);
            this.tabWeb.ResumeLayout(false);
            this.grpWebStats.ResumeLayout(false);
            this.grpWebStats.PerformLayout();
            this.grpWebProxy.ResumeLayout(false);
            this.grpWebProxy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUpdateData;
        private System.Windows.Forms.Label lbl2SchedExplain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnl1CSSSample;
        private System.Windows.Forms.ListBox StyleList;
        private System.Windows.Forms.WebBrowser wbCssSample;
        private System.Windows.Forms.Label lbl1Style;
        private System.Windows.Forms.Label lbl1Preview;
        private System.Windows.Forms.GroupBox grpHTMLOutput;
        private System.Windows.Forms.Label lbl2WebSiteDir;
        private System.Windows.Forms.Button btnBrowseWebFolder;
        private System.Windows.Forms.Label lbl2MinutesToGen;
        private System.Windows.Forms.FolderBrowserDialog locateWebFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWeb;
        private System.Windows.Forms.TabPage tabVisStyles;
        private System.Windows.Forms.TabPage tabSchdTasks;
        private System.Windows.Forms.TextBox txtStanfordUserID;
        private System.Windows.Forms.TextBox txtEOCUserID;
        private System.Windows.Forms.Label lbl3StanfordUserID;
        private System.Windows.Forms.Label lbl3EOCUserID;
        private System.Windows.Forms.LinkLabel linkEOC;
        private System.Windows.Forms.LinkLabel linkStanford;
        private System.Windows.Forms.LinkLabel linkTeam;
        private System.Windows.Forms.TextBox txtStanfordTeamID;
        private System.Windows.Forms.Label lbl3StanfordTeamID;
        private System.Windows.Forms.TextBox txtCollectMinutes;
        private System.Windows.Forms.CheckBox chkScheduled;
        private System.Windows.Forms.CheckBox chkAppStart;
        private System.Windows.Forms.TextBox txtWebGenMinutes;
        private System.Windows.Forms.CheckBox chkWebSiteGenerator;
        private System.Windows.Forms.TextBox txtWebSiteBase;
        private System.Windows.Forms.GroupBox grpWebStats;
        private System.Windows.Forms.GroupBox grpWebProxy;
        private System.Windows.Forms.TextBox txtProxyServer;
        private System.Windows.Forms.Label lbl3Proxy;
        private System.Windows.Forms.TextBox txtProxyPass;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label lbl3ProxyPass;
        private System.Windows.Forms.Label lbl3ProxyUser;
        private System.Windows.Forms.Label lbl3Port;
        private System.Windows.Forms.CheckBox chkUseProxyAuth;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.Label lbl2AutoCollect;
    }
}