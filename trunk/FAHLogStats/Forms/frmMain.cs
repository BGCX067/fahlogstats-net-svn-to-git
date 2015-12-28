/*
 * FAHLogStats.NET - Main UI Form
 * Copyright (C) 2006 David Rawling

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
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using FAHLogStats.Instances;
using FAHLogStats.Proteins;
using FAHLogStats.Preferences;
using FAHLogStats.Instrumentation;

using JWC;

using NLog;

using Microsoft.Win32;

namespace FAHLogStats.Forms
{
    public partial class frmMain : Form
    {
        #region Private Variables
        /// <summary>
        /// Conversion factor - minutes to milli-seconds
        /// </summary>
        const int MinToMillisec = 60000;
        /// <summary>
        /// Collection of host instances
        /// </summary>
        private FoldingInstanceCollection HostInstances = new FoldingInstanceCollection();
        /// <summary>
        /// Helper object to save form state
        /// </summary>
        private FormState _formState;
        /// <summary>
        /// Internal filename
        /// </summary>
        String ConfigFilename = "";
        /// <summary>
        /// Internal variable storing whether New, Open, Quit should prompt for saving the config first
        /// </summary>
        Boolean ChangedAfterSave = false;
        /// <summary>
        /// Private variable for the MRU Menu
        /// </summary>
        protected MruStripMenu mruMenu;
        /// <summary>
        /// Registry location for MRU File List
        /// </summary>
        static string mruRegKey = PreferenceSet.Instance.RegDataPath;
        /// <summary>
        /// Private PPW counter for tooltip
        /// </summary>
        private Double TotalPPW;
        /// <summary>
        /// Private Good Host counter for tooltip
        /// </summary>
        private Int32 GoodHosts;
        /// <summary>
        /// Private storage for right-clicked node - solves dumb .NET inability to correctly
        /// handle right-click on a not-selected node
        /// </summary>
        private TreeNode rightClickedNode;
        /// <summary>
        /// Private variable holding knowledge of whether this is the first time
        /// the form is shown
        /// </summary>
        private Boolean isAlreadyShown = false;
        /// <summary>
        /// Holds the state of the window before it is hidden (minimise to tray behaviour)
        /// </summary>
        private FormWindowState originalState;
        /// <summary>
        /// Private variable indicating whether a refresh is needed
        /// </summary>
        private Boolean refreshNeeded;
        /// <summary>
        /// Log management (log writer)
        /// </summary>
        private Logger ClassLogger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Form Constructor / functionality

        /// <summary>
        /// Main form constructor
        /// </summary>
        public frmMain()
        {                             
            InitializeComponent();

            // All the work is performed by the constructor. We just save the object
            // until end of the form life to ensure that the save happens at the right
            // time
            _formState = new FormState(this, "frmMain");

            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(mruRegKey);
                if (regKey != null)
                    regKey.Close();

                mruMenu = new MruStripMenu(mnuFileRecent, new MruStripMenu.ClickedHandler(LoadMRUFile), mruRegKey + "\\MRU");

            }
            catch (Exception Ex)
            {
                mnuFileRecent.Enabled = false;
                mnuFileRecent.Text = "Error: Recent Files not Available";
                ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
            }
            ProteinCollection.Instance.NFOUpdated += new NFOUpdatedEventHandler(Instance_NFOUpdated);

            if (Environment.OSVersion.Version.Major >= 6)
            {
                // Vista-ize the UI
                treeHosts.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            }
            else
            {
                // XP-ize the UI
                treeHosts.Font = new Font("Verdana", 8F, FontStyle.Regular);
            }

        }

        /// <summary>
        /// Loads the appropriate file on initialisation - ie when showing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Shown(object sender, EventArgs e)
        {
            String sFilename = "";

            if (isAlreadyShown) return;
            isAlreadyShown = true;

            if (Program.cmdArgs.Length > 0)
            {
                // Filename on command line - probably from Explorer
                sFilename = Program.cmdArgs[0];
            }
            else
            {
                // Load last filename
                if (mruMenu.NumEntries > 0)
                    sFilename = mruMenu.GetFileAt(0);
            }

            if (sFilename != "")
                try
                {
                    LoadFile(sFilename);
                }
                catch (Exception Ex)
                {
                    // OK now this could be anything (even permissions), but we'll just chuck a dialog up.
                    ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                }
        }

        /// <summary>
        /// Hides the taskbar icon if the app is minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                originalState = this.WindowState;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.ShowInTaskbar = false;
            }
        }

        #endregion

        #region File Menu Click Handlers

        /// <summary>
        /// Create a new host configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if (CanContinueDestructiveOp(sender, e))
            {
                // Re-initialise the list of host instances
                HostInstances = new FoldingInstanceCollection();
                // and the config filename - this is a new one now
                ConfigFilename = "";
                // Empty the tree
                ClearTree();
                // Technically there are now no changes after a save
                ChangedAfterSave = false;
                // Disable the timer, we have no hosts
                bgWorkTimer.Enabled = false;
                // Refresh the current item in the tree
                refreshNeeded = true;
            }
        }

        /// <summary>
        /// Open an existing (saved) host configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (CanContinueDestructiveOp(sender, e))
            {
                openConfigDialog.RestoreDirectory = true;
                if (openConfigDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFile(openConfigDialog.FileName);
                    mruMenu.AddFile(ConfigFilename);
                    mruMenu.SaveToRegistry();
                    refreshNeeded = true;
                }
            }
        }

        /// <summary>
        /// Save the current host configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (ConfigFilename == String.Empty)
            {
                mnuFileSaveas_Click(sender, e);
            }
            else
            {
                HostInstances.ToXml(ConfigFilename);
                mruMenu.AddFile(ConfigFilename);
                mruMenu.SaveToRegistry();
                ChangedAfterSave = false;
            }
        }

        /// <summary>
        /// Save the current host configuration as a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileSaveas_Click(object sender, EventArgs e)
        {
            if (saveConfigDialog.ShowDialog() == DialogResult.OK)
            {
                ConfigFilename = saveConfigDialog.FileName;
                mnuFileSave_Click(sender, e);
            }
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileQuit_Click(object sender, EventArgs e)
        {
            if (CanContinueDestructiveOp(sender, e))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Event handler for clicks on a MRU file
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sFilename"></param>
        private void LoadMRUFile(int number, String sFilename)
        {
            LoadFile(sFilename);
        }

        #endregion

        #region Edit Menu Click Handlers

        /// <summary>
        /// Copy ... something ... to the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don't know what to copy!\n\nLog your suggestions as a bug.");
        }

        /// <summary>
        /// Displays and handles the User Preferences dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferences prefDialog = new frmPreferences();
            if (prefDialog.ShowDialog() == DialogResult.OK)
            {
                setTimerState();
            }
            refreshNeeded = true;
        }

        #endregion

        #region Help Menu Click Handlers

        /// <summary>
        /// Show the About dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout newAbout = new frmAbout();
            newAbout.ShowDialog();
        }

        /// <summary>
        /// Show the help file at the contents tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHelpContents_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        /// <summary>
        /// Show the help file at the index tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHelpIndex_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, helpProvider.HelpNamespace);
        }

        #endregion

        #region Tree Helper Routines

        /// <summary>
        /// Empty all hosts from the tree
        /// </summary>
        private void ClearTree()
        {
            TreeNodeCollection MonitoredComputers = treeHosts.Nodes[3].Nodes;
            foreach (TreeNode tn in MonitoredComputers)
            {
                MonitoredComputers.Remove(tn);
            }
        }

        /// <summary>
        /// Given the host collection, add each host to the tree
        /// </summary>
        private void loadTreeFromCollection()
        {
            ClearTree();

            foreach (Base newHostNode in HostInstances.Values)
            {
                AddHostNode(newHostNode.Name);
            }
        }

        /// <summary>
        /// Add the new host to the tree
        /// </summary>
        /// <param name="sHostname">Name of the new host</param>
        private void AddHostNode(String sHostname)
        {
            System.Windows.Forms.TreeNode newHostNode = new TreeNode(sHostname);
            newHostNode.Name = sHostname;
            newHostNode.Tag = "HostMenu";
            newHostNode.EnsureVisible();
            newHostNode.Text = sHostname;
            treeHosts.Nodes[3].Nodes.Add(newHostNode);

            setTimerState();
        }

        /// <summary>
        /// Processes a new selection in the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeHosts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Base oSelectedInstance;
            switch (e.Node.Name)
            {
                case "Overview":
                    webContent.DocumentText = XMLGen.OverviewXml("WinOverview.xslt", HostInstances);
                    break;
                case "Summary":
                    webContent.DocumentText = XMLGen.SummaryXml("WinSummary.xslt", HostInstances);
                    break;
                case "Statistics":
                    break;
                case "Hosts":
                    break;
                case "EOCUserStatistics":
                    webContent.Url = new Uri(PreferenceSet.Instance.EOCUserURL);
                    break;
                case "EOCTeamStatistics":
                    webContent.Url = new Uri(PreferenceSet.Instance.EOCTeamURL);
                    break;
                case "StanfordStats":
                    webContent.Url = new Uri(PreferenceSet.Instance.StanfordUserURL);
                    break;
                default:
                    if (HostInstances.TryGetValue(e.Node.Name, out oSelectedInstance))
                        webContent.DocumentText = Instances.XMLGen.InstanceXml("WinInstance.xslt", oSelectedInstance);
                    break;
            }
        }

        /// <summary>
        /// Displays the correct menu based on the item that was right-clicked. Works
        /// around the fact that a right click on a non-selected item doesn't automatically
        /// perform a select operation on that item before calling the menu. So what would
        /// happen is you'd get the context menu for the item, but the _selected_ item wouldn't
        /// match the menu. This is only a problem when there are different context menus
        /// for a single tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeHosts_MouseUp(object sender, MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeHosts.GetNodeAt(p);
                if (node != null)
                {
                    // Save the node the user has clicked.
                    rightClickedNode = node;

                    // Find the appropriate ContextMenu depending on the selected node.
                    switch (Convert.ToString(node.Tag))
                    {
                        case "WebMenu":
                            WebMenu.Show(treeHosts, p);
                            break;
                        case "HostMenu":
                            if (node.Name == "Hosts")
                            {
                                mnuHostEdit.Enabled = false;
                                mnuHostDelete.Enabled = false;
                                mnuHostViewLog.Enabled = false;
                            }
                            else
                            {
                                mnuHostEdit.Enabled = true;
                                mnuHostDelete.Enabled = true;
                                mnuHostViewLog.Enabled = true;
                            }
                            HostMenu.Show(treeHosts, p);
                            break;
                    }
                }
            }
        }

        #endregion

        #region Host Context Menu Click Handlers

        /// <summary>
        /// Add a new host to the configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostAdd_Click(object sender, EventArgs e)
        {
            frmHost newHost = new frmHost();
            newHost.radioLocal.Checked = true;
            if (newHost.ShowDialog() == DialogResult.OK)
            {
                AddHostNode(newHost.txtName.Text);
                ChangedAfterSave = true;
                if (newHost.radioLocal.Checked)
                {
                    FAHLogStats.Instances.PathInstance xHost = new FAHLogStats.Instances.PathInstance();
                    xHost.Name = newHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = newHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = newHost.txtUnitFileName.Text;
                    xHost.Path = newHost.txtLocalPath.Text;
                    HostInstances.Add(xHost.Name, (Base)xHost);
                    HostInstances[xHost.Name].Retrieve();
                }
                else if (newHost.radioHTTP.Checked)
                {
                    FAHLogStats.Instances.HTTPInstance xHost = new FAHLogStats.Instances.HTTPInstance();
                    xHost.Name = newHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = newHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = newHost.txtUnitFileName.Text;
                    xHost.URL = newHost.txtWebURL.Text;
                    xHost.Username = newHost.txtWebUser.Text;
                    xHost.Password = newHost.txtWebPass.Text;
                    HostInstances.Add(xHost.Name, (Base)xHost);
                    HostInstances[xHost.Name].Retrieve();
                }
                else if (newHost.radioFTP.Checked)
                {
                    FAHLogStats.Instances.FTPInstance xHost = new FAHLogStats.Instances.FTPInstance();
                    xHost.Name = newHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = newHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = newHost.txtUnitFileName.Text;
                    xHost.Server = newHost.txtFTPServer.Text;
                    xHost.Path = newHost.txtFTPPath.Text;
                    xHost.Username = newHost.txtFTPUser.Text;
                    xHost.Password = newHost.txtFTPPass.Text;
                    HostInstances.Add(xHost.Name, (Base)xHost);
                    HostInstances[xHost.Name].Retrieve();
                }
                refreshNeeded = true;
            }
        }

        /// <summary>
        /// Edits an existing host configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostEdit_Click(object sender, EventArgs e)
        {
            frmHost editHost = new frmHost();
            editHost.txtName.Enabled = false;
            editHost.txtName.ReadOnly = true;
            Base Instance = HostInstances[rightClickedNode.Name];

            editHost.txtName.Text = rightClickedNode.Name;
            editHost.txtLogFileName.Text = Instance.RemoteFAHLogFilename;
            editHost.txtUnitFileName.Text = Instance.RemoteUnitInfoFilename;
            if (Instance.GetType().ToString() == "FAHLogStats.Instances.PathInstance")
            {
                editHost.radioLocal.Select();
                editHost.txtLocalPath.Text = ((PathInstance)Instance).Path;
            }
            else if (Instance.GetType().ToString() == "FAHLogStats.Instances.FTPInstance")
            {
                editHost.radioFTP.Select();
                editHost.txtFTPServer.Text = ((FTPInstance)Instance).Server;
                editHost.txtFTPPath.Text = ((FTPInstance)Instance).Path;
                editHost.txtFTPUser.Text = ((FTPInstance)Instance).Username;
                editHost.txtFTPPass.Text = ((FTPInstance)Instance).Password;
            }
            else if (Instance.GetType().ToString() == "FAHLogStats.Instances.HTTPInstance")
            {
                editHost.radioHTTP.Select();
                editHost.txtWebURL.Text = ((HTTPInstance)Instance).URL;
                editHost.txtWebUser.Text = ((HTTPInstance)Instance).Username;
                editHost.txtWebPass.Text = ((HTTPInstance)Instance).Password;
            }
            else
                throw new NotImplementedException("The instance type was not located as expected");

            if (editHost.ShowDialog() == DialogResult.OK)
            {
                ChangedAfterSave = true;
                if (editHost.radioLocal.Checked)
                {
                    FAHLogStats.Instances.PathInstance xHost = new FAHLogStats.Instances.PathInstance();
                    xHost.Name = editHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = editHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = editHost.txtUnitFileName.Text;
                    xHost.Path = editHost.txtLocalPath.Text;
                    HostInstances[xHost.Name] = (Base)xHost;
                    HostInstances[xHost.Name].Retrieve();
                }
                else if (editHost.radioHTTP.Checked)
                {
                    FAHLogStats.Instances.HTTPInstance xHost = new FAHLogStats.Instances.HTTPInstance();
                    xHost.Name = editHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = editHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = editHost.txtUnitFileName.Text;
                    xHost.URL = editHost.txtWebURL.Text;
                    xHost.Username = editHost.txtWebUser.Text;
                    xHost.Password = editHost.txtWebPass.Text;
                    HostInstances[xHost.Name] = (Base)xHost;
                    HostInstances[xHost.Name].Retrieve();
                }
                else if (editHost.radioFTP.Checked)
                {
                    FAHLogStats.Instances.FTPInstance xHost = new FAHLogStats.Instances.FTPInstance();
                    xHost.Name = editHost.txtName.Text;
                    xHost.RemoteFAHLogFilename = editHost.txtLogFileName.Text;
                    xHost.RemoteUnitInfoFilename = editHost.txtUnitFileName.Text;
                    xHost.Server = editHost.txtFTPServer.Text;
                    xHost.Path = editHost.txtFTPPath.Text;
                    xHost.Username = editHost.txtFTPUser.Text;
                    xHost.Password = editHost.txtFTPPass.Text;
                    HostInstances[xHost.Name] = (Base)xHost;
                    HostInstances[xHost.Name].Retrieve();
                }
                refreshNeeded = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        delegate void htmlRefreshCallback(object sender, EventArgs e);

        /// <summary>
        /// Refreshes the currently selected page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostRefresh_Click(object sender, EventArgs e)
        {
            htmlRefresh(sender, e);
        }

        /// <summary>
        /// Removes a host from the configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostDelete_Click(object sender, EventArgs e)
        {
            HostInstances.Remove(rightClickedNode.Name);
            treeHosts.Nodes.Remove(rightClickedNode);
            ChangedAfterSave = true;
        }

        /// <summary>
        /// Shows the logfile (FAHlog.txt) for the selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(HostInstances[rightClickedNode.Name].BaseDirectory + "\\FAHlog.txt");
            }
            catch
            {
                // Meh, if it doesn't exist do nothing (probably should figure out if it was valid, and if so, show a dialog)
            }
        }

        /// <summary>
        /// Forces the html pane to refresh itself
        /// </summary>
        private void htmlRefresh(object sender, EventArgs e)
        {
            refreshNeeded = false;
            if (treeHosts.InvokeRequired)
            {
                htmlRefreshCallback tFunc = new htmlRefreshCallback(htmlRefresh);
                this.Invoke(tFunc, new object[] { sender, e });
            }
            else
            {
                TreeNode tmp = treeHosts.SelectedNode;
                treeHosts.SelectedNode = null;
                treeHosts.SelectedNode = tmp;
            }
        }

        #endregion

        #region Web Context Menu Click Handlers

        /// <summary>
        /// Refreshes the currently selected Web Stats page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuWebRefresh_Click(object sender, EventArgs e)
        {
            webContent.Refresh(WebBrowserRefreshOption.Completely);
        }

        #endregion

        #region Background Work Routines

        /// <summary>
        /// Disable and enable the background work timers
        /// </summary>
        private void setTimerState()
        {
            // Disable timers if no hosts
            if (HostInstances.Count < 1)
            {
                bgWorkTimer.Stop();
                toolUpdateTimer.Stop();
                webGenTimer.Stop();
                refreshTimer.Stop();
                
                return;
            }

            // Start the status bar timer and the web refresh timer
            toolUpdateTimer.Start();
            refreshTimer.Start();

            // Enable the data retrieval timer
            if (PreferenceSet.Instance.SyncOnSchedule)
            {
                bgWorkTimer.Interval = Convert.ToInt32(PreferenceSet.Instance.SyncTimeMinutes) * MinToMillisec;
                bgWorkTimer.Start();
            }
            else
            {
                bgWorkTimer.Stop();
            }

            // Enable the web generation timer
            if (PreferenceSet.Instance.GenerateWeb)
            {
                webGenTimer.Interval = Convert.ToInt32(PreferenceSet.Instance.GenerateInterval) * MinToMillisec;
                webGenTimer.Start();
            }
            else
            {
                webGenTimer.Stop();
            }
        }

        /// <summary>
        /// When the host refresh timer expires, refresh all the hosts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgWorkTimer_Tick(object sender, EventArgs e)
        {
            // Fire off the background work thread, if it's not already running AND
            // there are sufficient free threads (HOW!??!)

            //if (!bgWorkThread.IsBusy)
            //    bgWorkThread.RunWorkerAsync();

            foreach (KeyValuePair<String, Base> Instance in HostInstances)
            {
                QueueNewRetrieval(Instance.Value);
            }
        }

        /// <summary>
        /// Stick an item on the background thread queue to retrieve the
        /// info for a given Instance
        /// </summary>
        /// <param name="Instance"></param>
        private void QueueNewRetrieval(Base Instance)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(RetrieveInstance), Instance);
        }

        /// <summary>
        /// Executes the appropriate Retrieve method for the passed Instance
        /// </summary>
        /// <param name="Instance"></param>
        private void RetrieveInstance(Object Instance)
        {
            Base TheInstance = (Base)Instance;
            TheInstance.Retrieve();
            refreshNeeded = true;
        }

        /// <summary>
        /// Cycle through the collection of instances and calculate totals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolUpdateTimer_Tick(object sender, EventArgs e)
        {
            Double newTotalPPW = 0;
            Int32 newGoodHosts = 0;
            foreach (KeyValuePair<String, Base> kvp in HostInstances)
            {
                newTotalPPW += kvp.Value.UnitInfo.PPD * 7;
                if (kvp.Value.LastRetrievalTime > DateTime.Now.Subtract(new TimeSpan(0, PreferenceSet.Instance.SyncTimeMinutes * 3, 0)))
                    newGoodHosts++;
            }
            if ((GoodHosts != newGoodHosts) || (TotalPPW != newTotalPPW))
                refreshNeeded = true;

            GoodHosts = newGoodHosts;
            TotalPPW = newTotalPPW;

            notifyIcon.Text = String.Format("{0} Clients Working\n{1} Clients Unknown\n{2:###,###,##0.00} PPW (Est)",
                            GoodHosts,
                            HostInstances.Count - GoodHosts,
                            TotalPPW);
        }

        /// <summary>
        /// Forces a screen refresh when the Stanford info is updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Instance_NFOUpdated(object sender, NFOUpdatedEventArgs e)
        {
            refreshNeeded = true;
        }

        /// <summary>
        /// Refresh the HTML page, status bar and so forth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Stop();

            if (refreshNeeded)
                htmlRefresh(sender, e);

            if (GoodHosts == 1)
                statusLabelHosts.Text = String.Format("{0} Host", GoodHosts);
            else
                statusLabelHosts.Text = String.Format("{0} Hosts", GoodHosts);
            statusLabelPPW.Text = String.Format("{0:###,###,##0.00} PPW", TotalPPW);

            refreshTimer.Start();
        }

        /// <summary>
        /// Generates the website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webGenTimer_Tick(object sender, EventArgs e)
        {
            webGenTimer.Stop();
            System.IO.StreamWriter sw;
                
            // Create the web folder (just in case)
            if (!System.IO.Directory.Exists(PreferenceSet.Instance.WebRoot))
                System.IO.Directory.CreateDirectory(PreferenceSet.Instance.WebRoot);

            // Copy the CSS file to the output directory
            String sAppPath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            if (System.IO.File.Exists(sAppPath + "\\CSS\\" + PreferenceSet.Instance.CSSFileName))
                System.IO.File.Copy(sAppPath + "\\CSS\\" + PreferenceSet.Instance.CSSFileName, PreferenceSet.Instance.WebRoot + "\\" + PreferenceSet.Instance.CSSFileName, true);

            // Generate the index page
            sw = new System.IO.StreamWriter(PreferenceSet.Instance.WebRoot + "\\" + "index.html", false);
            sw.Write(Instances.XMLGen.OverviewXml("WebOverview.xslt", HostInstances));
            sw.Close();

            // Generate the summary page
            sw = new System.IO.StreamWriter(PreferenceSet.Instance.WebRoot + "\\" + "summary.html", false);
            sw.Write(Instances.XMLGen.SummaryXml("WebSummary.xslt", HostInstances));
            sw.Close();

            // Generate a page per instance
            foreach (KeyValuePair<String, Base> kvp in HostInstances)
            {
                sw = new System.IO.StreamWriter(PreferenceSet.Instance.WebRoot + "\\" + kvp.Value.Name + ".html", false);
                sw.Write(Instances.XMLGen.InstanceXml("WebInstance.xslt", kvp.Value));
                sw.Close();
            }

            webGenTimer.Start();
        }

        #endregion

        #region System Tray Icon Routines

        /// <summary>
        /// Action the double-clicked notification icon (min/restore)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = originalState;
            }
            else
            {
                originalState = this.WindowState;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

        #region Helper Routines

        /// <summary>
        /// Test current application status for changes; ask for confirmation if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Whether or not a destructive operation can be performed</returns>
        private Boolean CanContinueDestructiveOp(object sender, EventArgs e)
        {
            if (ChangedAfterSave)
            {
                DialogResult qResult = MessageBox.Show("There are changes to the configuration that have not been saved. Would you like to save these changes?\n\nYes - Continue and save the changes\nNo - Continue and do not save the changes\nCancel - Do not continue", "Warning", MessageBoxButtons.YesNoCancel);
                switch (qResult)
                {
                    case DialogResult.Yes:
                        mnuFileSave_Click(sender, e);
                        if (ChangedAfterSave)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Loads a configuration file into memory
        /// </summary>
        /// <param name="sFileName"></param>
        private void LoadFile(String sFileName)
        {
            mnuFileNew_Click(null, null);
            ConfigFilename = sFileName;
            HostInstances.FromXml(sFileName);

            loadTreeFromCollection();

            if (PreferenceSet.Instance.SyncOnLoad)
            {
                foreach (KeyValuePair<String, Base> Instance in HostInstances)
                {
                    try
                    {
                        Instance.Value.ProcessExisting();
                        QueueNewRetrieval(Instance.Value);
                    }
                    catch (Exception Ex)
                    {
                        ClassLogger.LogException(LogLevel.Warn, String.Format("{0} threw exception {1}.", Debug.FunctionName, Ex.Message), null);
                    }
                    Application.DoEvents();
                }
            }
            setTimerState();
        }

        #endregion

        #region Notify Icon Menu handlers

        /// <summary>
        /// Minimizes the app (from notification icon)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNotifyMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Restores the app (from notification icon)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNotifyRst_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Maximizes the app (from notification icon)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNotifyMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Quit the app via the notification area right-click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNotifyQuit_Click(object sender, EventArgs e)
        {
            this.mnuFileQuit_Click(sender, e);
        }

        #endregion

    }
}