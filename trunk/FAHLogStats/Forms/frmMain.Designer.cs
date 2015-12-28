/*
 * FAHLogStats.NET - Main UI Form
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
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Overview");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Summary");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("EOC User Statistics");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("EOC Team Statistics");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Stanford Statistics");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Statistics", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Monitored Computers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.WebMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuWebRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.HostMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHostAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHostRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHostEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHostDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHostViewLog = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelHosts = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelPPW = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.treeHosts = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.webContent = new System.Windows.Forms.WebBrowser();
            this.bgWorkTimer = new System.Windows.Forms.Timer(this.components);
            this.saveConfigDialog = new System.Windows.Forms.SaveFileDialog();
            this.openConfigDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNotifyRst = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotifyMin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotifyMax = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotifySep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNotifyQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearBalloonTimer = new System.Windows.Forms.Timer(this.components);
            this.toolUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.webGenTimer = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.WebMenu.SuspendLayout();
            this.HostMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.AppMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlTree.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebMenu
            // 
            this.WebMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWebRefresh});
            this.WebMenu.Name = "WebMenu";
            this.WebMenu.Size = new System.Drawing.Size(128, 28);
            // 
            // mnuWebRefresh
            // 
            this.mnuWebRefresh.Name = "mnuWebRefresh";
            this.mnuWebRefresh.Size = new System.Drawing.Size(127, 24);
            this.mnuWebRefresh.Text = "&Refresh";
            this.mnuWebRefresh.Click += new System.EventHandler(this.mnuWebRefresh_Click);
            // 
            // HostMenu
            // 
            this.HostMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHostAdd,
            this.mnuHostRefresh,
            this.mnuHostEdit,
            this.mnuHostDelete,
            this.mnuHostViewLog});
            this.HostMenu.Name = "HostMenu";
            this.HostMenu.Size = new System.Drawing.Size(140, 124);
            // 
            // mnuHostAdd
            // 
            this.mnuHostAdd.Name = "mnuHostAdd";
            this.mnuHostAdd.Size = new System.Drawing.Size(139, 24);
            this.mnuHostAdd.Text = "&Add";
            this.mnuHostAdd.Click += new System.EventHandler(this.hostAdd_Click);
            // 
            // mnuHostRefresh
            // 
            this.mnuHostRefresh.Name = "mnuHostRefresh";
            this.mnuHostRefresh.Size = new System.Drawing.Size(139, 24);
            this.mnuHostRefresh.Text = "&Refresh";
            this.mnuHostRefresh.Click += new System.EventHandler(this.hostRefresh_Click);
            // 
            // mnuHostEdit
            // 
            this.mnuHostEdit.Name = "mnuHostEdit";
            this.mnuHostEdit.Size = new System.Drawing.Size(139, 24);
            this.mnuHostEdit.Text = "&Edit";
            this.mnuHostEdit.Click += new System.EventHandler(this.hostEdit_Click);
            // 
            // mnuHostDelete
            // 
            this.mnuHostDelete.Name = "mnuHostDelete";
            this.mnuHostDelete.Size = new System.Drawing.Size(139, 24);
            this.mnuHostDelete.Text = "&Delete";
            this.mnuHostDelete.Click += new System.EventHandler(this.hostDelete_Click);
            // 
            // mnuHostViewLog
            // 
            this.mnuHostViewLog.Name = "mnuHostViewLog";
            this.mnuHostViewLog.Size = new System.Drawing.Size(139, 24);
            this.mnuHostViewLog.Text = "&View Log";
            this.mnuHostViewLog.Click += new System.EventHandler(this.hostViewLog_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeft,
            this.statusLabelHosts,
            this.statusLabelPPW,
            this.statusLabelRight});
            this.statusStrip.Location = new System.Drawing.Point(0, 535);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1023, 29);
            this.statusStrip.TabIndex = 1;
            // 
            // statusLabelLeft
            // 
            this.statusLabelLeft.AutoSize = false;
            this.statusLabelLeft.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelLeft.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelLeft.Name = "statusLabelLeft";
            this.statusLabelLeft.Size = new System.Drawing.Size(861, 24);
            this.statusLabelLeft.Spring = true;
            this.statusLabelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelHosts
            // 
            this.statusLabelHosts.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelHosts.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelHosts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelHosts.Name = "statusLabelHosts";
            this.statusLabelHosts.Size = new System.Drawing.Size(21, 24);
            this.statusLabelHosts.Text = "0";
            this.statusLabelHosts.ToolTipText = "Number of Hosts";
            // 
            // statusLabelPPW
            // 
            this.statusLabelPPW.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelPPW.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelPPW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelPPW.Name = "statusLabelPPW";
            this.statusLabelPPW.Size = new System.Drawing.Size(21, 24);
            this.statusLabelPPW.Text = "0";
            this.statusLabelPPW.ToolTipText = "Points Per Week";
            // 
            // statusLabelRight
            // 
            this.statusLabelRight.AutoSize = false;
            this.statusLabelRight.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelRight.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelRight.Name = "statusLabelRight";
            this.statusLabelRight.Size = new System.Drawing.Size(100, 24);
            this.statusLabelRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(64, 17);
            this.statusInfo.Text = "Status Info";
            // 
            // AppMenu
            // 
            this.AppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.AppMenu.Location = new System.Drawing.Point(0, 0);
            this.AppMenu.Name = "AppMenu";
            this.AppMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.AppMenu.Size = new System.Drawing.Size(1023, 28);
            this.AppMenu.TabIndex = 0;
            this.AppMenu.Text = "App Menu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveas,
            this.mnuFileSep1,
            this.mnuFileRecent,
            this.mnuFileSep2,
            this.mnuFileQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(44, 24);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Image = global::FAHLogStats.Properties.Resources.New;
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFileNew.Size = new System.Drawing.Size(314, 24);
            this.mnuFileNew.Text = "&New Configuration";
            this.mnuFileNew.ToolTipText = "Create a new configuration file";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Image = global::FAHLogStats.Properties.Resources.Open;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(314, 24);
            this.mnuFileOpen.Text = "&Open Configuration";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = global::FAHLogStats.Properties.Resources.Save;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(314, 24);
            this.mnuFileSave.Text = "&Save Configuration";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveas
            // 
            this.mnuFileSaveas.Image = global::FAHLogStats.Properties.Resources.SaveAs;
            this.mnuFileSaveas.Name = "mnuFileSaveas";
            this.mnuFileSaveas.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveas.Size = new System.Drawing.Size(314, 24);
            this.mnuFileSaveas.Text = "Save Configuration &As";
            this.mnuFileSaveas.Click += new System.EventHandler(this.mnuFileSaveas_Click);
            // 
            // mnuFileSep1
            // 
            this.mnuFileSep1.Name = "mnuFileSep1";
            this.mnuFileSep1.Size = new System.Drawing.Size(311, 6);
            // 
            // mnuFileRecent
            // 
            this.mnuFileRecent.Name = "mnuFileRecent";
            this.mnuFileRecent.Size = new System.Drawing.Size(314, 24);
            this.mnuFileRecent.Text = "Recent &Files";
            // 
            // mnuFileSep2
            // 
            this.mnuFileSep2.Name = "mnuFileSep2";
            this.mnuFileSep2.Size = new System.Drawing.Size(311, 6);
            // 
            // mnuFileQuit
            // 
            this.mnuFileQuit.Image = global::FAHLogStats.Properties.Resources.Quit;
            this.mnuFileQuit.Name = "mnuFileQuit";
            this.mnuFileQuit.Size = new System.Drawing.Size(314, 24);
            this.mnuFileQuit.Text = "&Quit";
            this.mnuFileQuit.Click += new System.EventHandler(this.mnuFileQuit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCopy,
            this.mnuEditSep1,
            this.mnuEditPreferences});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(47, 24);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Image = global::FAHLogStats.Properties.Resources.Copy;
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.Size = new System.Drawing.Size(154, 24);
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // mnuEditSep1
            // 
            this.mnuEditSep1.Name = "mnuEditSep1";
            this.mnuEditSep1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuEditPreferences
            // 
            this.mnuEditPreferences.Name = "mnuEditPreferences";
            this.mnuEditPreferences.Size = new System.Drawing.Size(154, 24);
            this.mnuEditPreferences.Text = "&Preferences";
            this.mnuEditPreferences.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpContents,
            this.mnuHelpIndex,
            this.mnuHelpSep1,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(53, 24);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpContents
            // 
            this.mnuHelpContents.Image = global::FAHLogStats.Properties.Resources.HelpContents;
            this.mnuHelpContents.Name = "mnuHelpContents";
            this.mnuHelpContents.Size = new System.Drawing.Size(136, 24);
            this.mnuHelpContents.Text = "&Contents";
            this.mnuHelpContents.Click += new System.EventHandler(this.mnuHelpContents_Click);
            // 
            // mnuHelpIndex
            // 
            this.mnuHelpIndex.Name = "mnuHelpIndex";
            this.mnuHelpIndex.Size = new System.Drawing.Size(136, 24);
            this.mnuHelpIndex.Text = "&Index";
            this.mnuHelpIndex.Click += new System.EventHandler(this.mnuHelpIndex_Click);
            // 
            // mnuHelpSep1
            // 
            this.mnuHelpSep1.Name = "mnuHelpSep1";
            this.mnuHelpSep1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Image = global::FAHLogStats.Properties.Resources.About;
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(136, 24);
            this.mnuHelpAbout.Text = "&About";
            this.mnuHelpAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlTree);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlContent);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1023, 507);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlTree
            // 
            this.pnlTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTree.Controls.Add(this.treeHosts);
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(200, 507);
            this.pnlTree.TabIndex = 0;
            // 
            // treeHosts
            // 
            this.treeHosts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeHosts.Location = new System.Drawing.Point(0, 0);
            this.treeHosts.Margin = new System.Windows.Forms.Padding(4);
            this.treeHosts.Name = "treeHosts";
            treeNode22.Name = "Overview";
            treeNode22.Tag = "HostMenu";
            treeNode22.Text = "Overview";
            treeNode23.Name = "Summary";
            treeNode23.Tag = "HostMenu";
            treeNode23.Text = "Summary";
            treeNode24.Name = "EOCUserStatistics";
            treeNode24.Tag = "WebMenu";
            treeNode24.Text = "EOC User Statistics";
            treeNode25.Name = "EOCTeamStatistics";
            treeNode25.Text = "EOC Team Statistics";
            treeNode26.Name = "StanfordStats";
            treeNode26.Tag = "WebMenu";
            treeNode26.Text = "Stanford Statistics";
            treeNode27.Name = "Statistics";
            treeNode27.Tag = "WebMenu";
            treeNode27.Text = "Statistics";
            treeNode28.Name = "Hosts";
            treeNode28.Tag = "HostMenu";
            treeNode28.Text = "Monitored Computers";
            this.treeHosts.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode27,
            treeNode28});
            this.treeHosts.ShowLines = false;
            this.treeHosts.Size = new System.Drawing.Size(196, 503);
            this.treeHosts.TabIndex = 0;
            this.treeHosts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeHosts_AfterSelect);
            this.treeHosts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeHosts_MouseUp);
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContent.Controls.Add(this.webContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(818, 507);
            this.pnlContent.TabIndex = 0;
            // 
            // webContent
            // 
            this.webContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webContent.Location = new System.Drawing.Point(0, 0);
            this.webContent.Margin = new System.Windows.Forms.Padding(4);
            this.webContent.MinimumSize = new System.Drawing.Size(27, 25);
            this.webContent.Name = "webContent";
            this.webContent.Size = new System.Drawing.Size(814, 503);
            this.webContent.TabIndex = 0;
            // 
            // bgWorkTimer
            // 
            this.bgWorkTimer.Interval = 600000;
            this.bgWorkTimer.Tick += new System.EventHandler(this.bgWorkTimer_Tick);
            // 
            // saveConfigDialog
            // 
            this.saveConfigDialog.DefaultExt = "f@h";
            this.saveConfigDialog.Filter = "FAHLogStats Configuration Files|*.f@h";
            // 
            // openConfigDialog
            // 
            this.openConfigDialog.DefaultExt = "f@h";
            this.openConfigDialog.Filter = "FAHLogStats Configuration Files|*.f@h";
            this.openConfigDialog.RestoreDirectory = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Folding@Home Log Stats";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNotifyRst,
            this.mnuNotifyMin,
            this.mnuNotifyMax,
            this.mnuNotifySep1,
            this.mnuNotifyQuit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(143, 106);
            // 
            // mnuNotifyRst
            // 
            this.mnuNotifyRst.Image = global::FAHLogStats.Properties.Resources.Restore;
            this.mnuNotifyRst.Name = "mnuNotifyRst";
            this.mnuNotifyRst.Size = new System.Drawing.Size(142, 24);
            this.mnuNotifyRst.Text = "&Restore";
            this.mnuNotifyRst.Click += new System.EventHandler(this.mnuNotifyRst_Click);
            // 
            // mnuNotifyMin
            // 
            this.mnuNotifyMin.Image = global::FAHLogStats.Properties.Resources.Minimize;
            this.mnuNotifyMin.Name = "mnuNotifyMin";
            this.mnuNotifyMin.Size = new System.Drawing.Size(142, 24);
            this.mnuNotifyMin.Text = "Mi&nimize";
            this.mnuNotifyMin.Click += new System.EventHandler(this.mnuNotifyMin_Click);
            // 
            // mnuNotifyMax
            // 
            this.mnuNotifyMax.Image = global::FAHLogStats.Properties.Resources.Maximize;
            this.mnuNotifyMax.Name = "mnuNotifyMax";
            this.mnuNotifyMax.Size = new System.Drawing.Size(142, 24);
            this.mnuNotifyMax.Text = "&Maximize";
            this.mnuNotifyMax.Click += new System.EventHandler(this.mnuNotifyMax_Click);
            // 
            // mnuNotifySep1
            // 
            this.mnuNotifySep1.Name = "mnuNotifySep1";
            this.mnuNotifySep1.Size = new System.Drawing.Size(139, 6);
            // 
            // mnuNotifyQuit
            // 
            this.mnuNotifyQuit.Image = global::FAHLogStats.Properties.Resources.Quit;
            this.mnuNotifyQuit.Name = "mnuNotifyQuit";
            this.mnuNotifyQuit.Size = new System.Drawing.Size(142, 24);
            this.mnuNotifyQuit.Text = "&Quit";
            this.mnuNotifyQuit.Click += new System.EventHandler(this.mnuNotifyQuit_Click);
            // 
            // toolUpdateTimer
            // 
            this.toolUpdateTimer.Enabled = true;
            this.toolUpdateTimer.Interval = 5000;
            this.toolUpdateTimer.Tick += new System.EventHandler(this.toolUpdateTimer_Tick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // webGenTimer
            // 
            this.webGenTimer.Interval = 900000;
            this.webGenTimer.Tick += new System.EventHandler(this.webGenTimer_Tick);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "Help\\FAHLogStats.Net.chm";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 564);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.AppMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AppMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Folding@Home Log Stats";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.WebMenu.ResumeLayout(false);
            this.HostMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.AppMenu.ResumeLayout(false);
            this.AppMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlTree.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.MenuStrip AppMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeHosts;
        private System.Windows.Forms.ContextMenuStrip WebMenu;
        private System.Windows.Forms.ContextMenuStrip HostMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuWebRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuHostAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuHostEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuHostDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuHostViewLog;
        private System.Windows.Forms.WebBrowser webContent;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer bgWorkTimer;
        private System.Windows.Forms.SaveFileDialog saveConfigDialog;
        private System.Windows.Forms.OpenFileDialog openConfigDialog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer ClearBalloonTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveas;
        private System.Windows.Forms.ToolStripSeparator mnuFileSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileQuit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripSeparator mnuEditSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPreferences;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuHostRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuFileRecent;
        private System.Windows.Forms.ToolStripSeparator mnuFileSep2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelHosts;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelPPW;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
        private System.Windows.Forms.Timer toolUpdateTimer;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripSeparator mnuNotifySep1;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyQuit;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyMin;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyRst;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyMax;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpContents;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpIndex;
        private System.Windows.Forms.ToolStripSeparator mnuHelpSep1;
        private System.Windows.Forms.Timer webGenTimer;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}

