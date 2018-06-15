using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Drawing;

namespace SqlCeComparer
{
    public partial class MainScreen : Form
    {

        public MainScreen()
        {
            InitializeComponent();
        }

        #region Configuration Tab
        private void OldConfigBrowse_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openConfigSdf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string OldConfigPaht = openConfigSdf.InitialDirectory;
                OldConfigTxt.Text = OldConfigPaht + openConfigSdf.FileName;
            }

        }

        private void NewConfigBrowse_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openConfigSdf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string NewConfigPath = openConfigSdf.InitialDirectory;
                NewConfigTxt.Text = NewConfigPath + openConfigSdf.FileName;
            }

        }

        private void CheckChangesButton_Click(object sender, EventArgs e)
        {
            ModuleDiff();
            configDiff();
        }

        private void OpenWinMerge_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:/Program Files (x86)/WinMerge"))
            {
                ModuleDiff();
                configDiff();
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "C:/Program Files (x86)/WinMerge/WinMergeU.exe";
                startInfo.Arguments = " C:/CleverWare/Temp/TestingOldConfig.txt C:/CleverWare/Temp/TestingNewConfig.txt";
                process.StartInfo = startInfo;
                process.Start();
            }
            else
            {
                System.Diagnostics.Process.Start("http://winmerge.org/downloads/?lang=en");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://winmerge.org/downloads/?lang=en");
        }
        #endregion

        #region Edit/Check Tab
        private void EditConfigBtn_Click(object sender, EventArgs e)
        {
            VehicleTypeListBox.Items.Clear();
            OtaAdapterTxt.Text = "";
            OtaServerTxt.Text = "";
            RemoteServerTxt.Text = "";
            LocalAdapterTxt.Text = "";
            TypeGpsTxt.Text = "";
            TimeSyncTxt.Text = "";
            RemoteValidateTxt.Text = "";
            StopDwellTxt.Text = "";
            SqlCeConnection conn = null;
            DialogResult result = openConfigSdf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string OldConfigPaht = openConfigSdf.InitialDirectory;
                EditConfigTxt.Text = OldConfigPaht + openConfigSdf.FileName;
            }
            conn = new SqlCeConnection("Data Source =  " + EditConfigTxt.Text);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select distinct VehicleType from ConfigurationValues";
            var SqlReturn = cmd.ExecuteReader();
            var vehicleType = new List<string>();
            while (SqlReturn.Read())
            {
                vehicleType.Add(Convert.ToString(SqlReturn["VehicleType"]));

            }
            foreach (var types in vehicleType)
            {

                VehicleTypeListBox.Items.Add(types);
            }
        }

        private void CheckValuesBtn_Click(object sender, EventArgs e)
        {
            //Get VehicleTypes For Edit
            var typesToEdit = new List<string>();
            var arg = new List<string>();
            foreach (var value in VehicleTypeListBox.CheckedItems)
            {
                typesToEdit.Add(value as string);

            }
            foreach (var vehicleType in typesToEdit)
            {

                List<string> _configNameList = new List<string> { @"OtaLocalAdapterName","OtaServerAddress",
                "RemoteServerHost","LocalNetworkInterface","TypeGPS","TimeSyncType","RemoteValidationOn","ServicedStopDwellTime"  };
                List<string> configReturnValue = new List<string> { };

                {
                    foreach (string type in _configNameList)
                    {
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "CleverDBAccessor.exe",
                                Arguments = "list -d " + EditConfigTxt.Text + " -e " + type + " -t " + vehicleType,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true

                            }
                        };
                        //Output Data to correct txt boxes
                        proc.Start();
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            string line = proc.StandardOutput.ReadLine();
                            string cleanReturn = (String.Join(" ", line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)));
                            configReturnValue.Add(cleanReturn);
                            var returnList = new List<string>();
                            char[] delimiterChars = { ' ' };
                            string[] splitReturn = (cleanReturn.Split(delimiterChars));
                            foreach (string s in splitReturn)
                            {
                                returnList.Add(s);
                            }
                            foreach (string v in returnList)
                            {
                                if (v == "OtaLocalAdapterName")
                                {
                                    OtaAdapterTxt.Text = returnList[2];
                                }
                                if (v == "OtaServerAddress")
                                {
                                    OtaServerTxt.Text = returnList[2];
                                }
                                if (v == "RemoteServerHost")
                                {
                                    RemoteServerTxt.Text = returnList[2];
                                }
                                if (v == "LocalNetworkInterface")
                                {
                                    LocalAdapterTxt.Text = returnList[2];
                                }
                                if (v == "TypeGPS")
                                {
                                    TypeGpsTxt.Text = returnList[2];
                                }
                                if (v == "TimeSyncType")
                                {
                                    TimeSyncTxt.Text = returnList[2];
                                }
                                if (v == "RemoteValidationOn")
                                {
                                    RemoteValidateTxt.Text = returnList[2];
                                }
                                if (v == "ServicedStopDwellTime")
                                {
                                    StopDwellTxt.Text = returnList[2];
                                }
                            }

                        }
                    }

                }
                //var displayValue = new List<string>();
                // foreach (var value in configReturnValue)
                // {
                //     checkedListBox1.Items.Add(value);

                // }

            }
        }

        //help boxes for data entry fields
        private void OtaLocalPicHlp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OtaLocalAdapterName: Name of the Local Adapter OTA (DCC) will use. Example: (IVN4 LAN would be set to Intel(R) 82574L)");
        }

        private void otaserverhelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OtaServerAddress: The IP address of the OTA(DCC) server.");
        }

        private void buslinkadapterhelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LocalNetworkInterface: The Local Adapter Buslink will use.");
        }

        private void buslinkserverhelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RemoteServerHost: The IP of the Buslink Server");
        }

        private void gpstypehelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TypeGPS: The type of GPS the system will use. (Train Simulator = 5)");
        }

        private void timesynchelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TimeSyncType: Sync time to this source: 0=None, 1=Ota, 2=Gps, 3=Buslink");
        }

        private void remotevalhelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RemoteValidationOn: Whether or not perform remote validation on logons. (false = 0 true = 1)");
        }

        private void dwelltimehelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ServicedStopDwellTime: The number of seconds a marine vehicle must be within the stop window to consider the stop serviced.");
        }

        private void UpdateDB_Click(object sender, EventArgs e)
        {
            List<string> updateReturn = new List<string>();
            var typesToEdit = new List<string>();
            foreach (var value in VehicleTypeListBox.CheckedItems)
            {
                typesToEdit.Add(value as string);

            }

            foreach (var vehicleType in typesToEdit)
            {
                string val = "";
                List<string> _configNameList = new List<string> { @"OtaLocalAdapterName","OtaServerAddress",
                    "RemoteServerHost","LocalNetworkInterface","TypeGPS","TimeSyncType","RemoteValidationOn","ServicedStopDwellTime"  };
                List<string> configReturnValue = new List<string> { };

                {
                    foreach (string type in _configNameList)

                    {
                        if (type == "OtaLocalAdapterName")
                        {
                            val = OtaAdapterTxt.Text;
                        }
                        if (type == "OtaServerAddress")
                        {
                            val = OtaServerTxt.Text;
                        }
                        if (type == "RemoteServerHost")
                        {
                            val = RemoteServerTxt.Text;
                        }
                        if (type == "LocalNetworkInterface")
                        {
                            val = LocalAdapterTxt.Text;
                        }
                        if (type == "TypeGPS")
                        {
                            val = TypeGpsTxt.Text;
                        }
                        if (type == "TimeSyncType")
                        {
                            val = TimeSyncTxt.Text;
                        }
                        if (type == "RemoteValidationOn")
                        {
                            val = RemoteValidateTxt.Text;
                        }
                        if (type == "ServicedStopDwellTime")
                        {
                            val = StopDwellTxt.Text;
                        }
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "CleverDBAccessor.exe",
                                Arguments = "update -d " + EditConfigTxt.Text + " -e " + type + " -t " + vehicleType + " -v " + val,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true

                            }
                        };
                        //Output Data to correct txt boxes
                        proc.Start();

                        while (!proc.StandardOutput.EndOfStream)
                        {
                            string line = proc.StandardOutput.ReadLine();
                            if (line.Contains("Number of Rows Affected:"))
                            {
                                updateReturn.Add("Vehicle Type: " + vehicleType + " Entry: " + type + " Update Success!");
                            }
                        }
                    }

                }

            }
            updateReturnTxt.Text = string.Join(Environment.NewLine, updateReturn);

        }
        #endregion

        #region Private methods
        //Diff Configuration Values from Old DB to New DB
        private void configDiff()
        {
            SqlCeConnection conn = null;
            SqlCeConnection conn2 = null;
            try
            {
                System.IO.Directory.CreateDirectory("C:/CleverWare/Temp");
                conn = new SqlCeConnection("Data Source =  " + OldConfigTxt.Text);
                conn.Open();

                conn2 = new SqlCeConnection("Data Source =  " + NewConfigTxt.Text);
                conn2.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                SqlCeCommand cmd2 = conn2.CreateCommand();
                cmd.CommandText = @"SELECT m.Name, cv.VehicleType, cn.Name as Name2, cv.Value, cn.DataType, cv.Scope, cv.ScopeInstance, cn.IsEditable, cn.IsVisible 
                                    FROM ConfigurationNames cn Left Join ConfigurationValues cv on cn.id=cv.configurationid 
                                    Left Join Module m on m.id = cn.moduleid order by m.Name, cv.VehicleType, cn.Name";
                cmd2.CommandText = @"SELECT m.Name, cv.VehicleType, cn.Name as Name2, cv.Value, cn.DataType, cv.Scope, cv.ScopeInstance, cn.IsEditable, cn.IsVisible 
                                    FROM ConfigurationNames cn Left Join ConfigurationValues cv on cn.id=cv.configurationid 
                                    Left Join Module m on m.id = cn.moduleid order by m.Name, cv.VehicleType, cn.Name";
                var SqlReturn = cmd.ExecuteReader();
                var SqlReturn2 = cmd2.ExecuteReader();
                var oldConfigList = new List<string>();
                var newConfigList = new List<string>();
                var returnlist = new List<string>();
                var fileold = new StreamWriter("C:/CleverWare/Temp/TestingOldConfig.txt");
                fileold.Close();
                var filenew = new StreamWriter("C:/CleverWare/Temp/TestingNewConfig.txt");
                filenew.Close();
                while (SqlReturn.Read())
                {
                    string name = Convert.ToString(SqlReturn["Name"]);
                    string vehicleType = Convert.ToString(SqlReturn["VehicleType"]);
                    string cname = Convert.ToString(SqlReturn["Name2"]);
                    string value = Convert.ToString(SqlReturn["Value"]);
                    string DataType = Convert.ToString(SqlReturn["DataType"]);
                    string Scope = Convert.ToString(SqlReturn["Scope"]);
                    string ScopeInstance = Convert.ToString(SqlReturn["ScopeInstance"]);
                    string isEditable = Convert.ToString(SqlReturn["isEditable"]);
                    string isVisible = Convert.ToString(SqlReturn["isVisible"]);
                    newConfigList.Add(String.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                        name, vehicleType, cname, value, DataType, Scope, ScopeInstance,
                                        isEditable, isVisible));
                    using (var writer = new StreamWriter("C:/CleverWare/Temp/TestingOldConfig.txt", true))
                    {
                        writer.WriteLine(String.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                        name, vehicleType, cname, value, DataType, Scope, ScopeInstance,
                                        isEditable, isVisible));
                    }


                }
                while (SqlReturn2.Read())
                {
                    string name = Convert.ToString(SqlReturn2["Name"]);
                    string vehicleType = Convert.ToString(SqlReturn2["VehicleType"]);
                    string cname = Convert.ToString(SqlReturn2["Name2"]);
                    string value = Convert.ToString(SqlReturn2["Value"]);
                    string DataType = Convert.ToString(SqlReturn2["DataType"]);
                    string Scope = Convert.ToString(SqlReturn2["Scope"]);
                    string ScopeInstance = Convert.ToString(SqlReturn2["ScopeInstance"]);
                    string isEditable = Convert.ToString(SqlReturn2["isEditable"]);
                    string isVisible = Convert.ToString(SqlReturn2["isVisible"]);
                    newConfigList.Add(String.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                        name, vehicleType, cname, value, DataType, Scope, ScopeInstance,
                                        isEditable, isVisible));
                    using (var writer = new StreamWriter("C:/CleverWare/Temp/TestingNewConfig.txt", true))
                    {
                        writer.WriteLine(String.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                        name, vehicleType, cname, value, DataType, Scope, ScopeInstance,
                                        isEditable, isVisible));
                    }

                }

                var file1Lines = File.ReadAllLines("C:/CleverWare/Temp/TestingOldConfig.txt");
                var file2Lines = File.ReadAllLines("C:/CleverWare/Temp/TestingNewConfig.txt");
                IEnumerable<String> inFirstNotInSecond = file1Lines.Except(file2Lines);
                IEnumerable<String> inSecondNotInFirst = file2Lines.Except(file1Lines);
                //IEnumerable<String>ReadLines 
                var MissingFiles = inFirstNotInSecond.Concat(inSecondNotInFirst);
                InOldTxtBox.Text = string.Join(Environment.NewLine, (inFirstNotInSecond));
                InNewTxtBox.Text = string.Join(Environment.NewLine, (inSecondNotInFirst));
                textBox6.Text = string.Join(Environment.NewLine, MissingFiles);

            }
            catch (Exception e)
            {
                InOldTxtBox.Text = ("Config Error: " + Convert.ToString(e));
            }
            finally
            {
                conn.Close();
                conn2.Close();
            }
        }

        //Diff Modules in Old DB to New DB
        private void ModuleDiff()
        {
            SqlCeConnection conn = null;
            SqlCeConnection conn2 = null;
            try
            {
                if (OldConfigTxt.Text == "")
                {
                    DialogResult MessageResult;
                    MessageResult = MessageBox.Show("Select Old Configuration .sdf", "No File Selected", MessageBoxButtons.OKCancel);

                    if (MessageResult == DialogResult.OK)
                    {
                        OldConfigBrowse.PerformClick();
                    }
                    else if (MessageResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                if (NewConfigTxt.Text == "")
                {
                    DialogResult MessageResult;
                    MessageResult = MessageBox.Show("Select New Configuration .sdf", "No File Selected", MessageBoxButtons.OKCancel);

                    if (MessageResult == DialogResult.OK)
                    {
                        NewConfigBrowse.PerformClick();
                    }
                    else if (MessageResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                conn = new SqlCeConnection("Data Source =  " + OldConfigTxt.Text);
                conn.Open();

                conn2 = new SqlCeConnection("Data Source =  " + NewConfigTxt.Text);
                conn2.Open();

                SqlCeCommand cmd = conn.CreateCommand();
                SqlCeCommand cmd2 = conn2.CreateCommand();
                cmd.CommandText = "SELECT name, enabled FROM module WHERE enabled = 1 ORDER by name";
                cmd2.CommandText = "SELECT name, enabled FROM module WHERE enabled = 1 ORDER by name";
                textBox1.Text = string.Empty;
                var SqlReturn = cmd.ExecuteReader();
                var SqlReturn2 = cmd2.ExecuteReader();
                var oldModuleList = new List<string>();
                var newModuleList = new List<string>();
                while (SqlReturn.Read())
                {
                    oldModuleList.Add(Convert.ToString(SqlReturn["Name"]));

                }
                while (SqlReturn2.Read())
                {
                    newModuleList.Add(Convert.ToString(SqlReturn2["Name"]));
                }
                textBox1.Text = string.Join(Environment.NewLine, oldModuleList);
                textBox2.Text = string.Join(Environment.NewLine, newModuleList);
                var inOldList = newModuleList.Except(oldModuleList).ToList();
                var inNewList = oldModuleList.Except(newModuleList).ToList();
                var MissingModules = inOldList.Concat(inNewList);
                bool isEmpty = !MissingModules.Any();
                if (isEmpty)
                {
                    textBox3.Text = "No changes in Module tables";

                }
                else
                {
                    textBox3.Text = string.Join(Environment.NewLine, MissingModules);
                }
            }
            catch (Exception e)
            {
                InOldTxtBox.Text = (" Module Error: " + Convert.ToString(e));
            }
            finally
            {
                conn.Close();
                conn2.Close();
            }
        }
        #endregion

        #region Form
        private void btnBrowseA_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDatabaseA.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            }
        }

        private void btnBrowseB_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDatabaseB.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (!CheckFileExists(txtDatabaseA.Text)) return;
            if (!CheckFileExists(txtDatabaseB.Text)) return;

            try
            {
                CompareUtil util = new CompareUtil(txtDatabaseA.Text, txtDatabaseB.Text);
                util.LoadSchemas();

                Dictionary<string, Tuple<TableSchema, TableSchema, bool>> schemaMatches = util.GetTableSchemaMatches();
                DisplayTableSchemas(schemaMatches);

                if (chkCompareData.Checked)
                {
                    util.LoadData();
                    CompareData(schemaMatches, util);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error comparing databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTableSchemas(Dictionary<string, Tuple<TableSchema, TableSchema, bool>> schemaMatches)
        {
            //Display table information
            lvSchemaTables.Items.Clear();
            foreach (var match in schemaMatches)
            {
                ListViewItem item = lvSchemaTables.Items.Add(match.Key);
                item.Tag = match;
                TableSchema tsA = match.Value.Item1;
                TableSchema tsB = match.Value.Item2;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsA != null)));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsB != null)));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(match.Value.Item3)));

                var colCount = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, tsA.Columns.Count.ToString()));
                if (tsA.Columns.Count != tsB.Columns.Count) colCount.Text += $", {tsB.Columns.Count}";

                var idxCount = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, tsA.Indexes.Count.ToString()));
                if (tsA.Indexes.Count != tsB.Indexes.Count) idxCount.Text += $", {tsB.Indexes.Count}";

                if (!match.Value.Item3) item.BackColor = Color.HotPink;
            }

            if (lvSchemaTables.Items.Count > 0)
            {
                lvSchemaTables.Items[0].Selected = true;
                lvSchemaTables.Focus();
            }
        }

        private void CompareData(Dictionary<string, Tuple<TableSchema, TableSchema, bool>> schemaMatches, CompareUtil util)
        {
            DataSet dataSetA = util.DbInfoA.MyDataSet;
            DataSet dataSetB = util.DbInfoB.MyDataSet;
            if (dataSetA == null || dataSetB == null) return;

            //Display table information
            lvDataTables.Items.Clear();
            foreach (var match in schemaMatches)
            {
                ListViewItem item = lvDataTables.Items.Add(match.Key);
                item.Tag = match;
                TableSchema tsA = match.Value.Item1;
                TableSchema tsB = match.Value.Item2;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsA != null)));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsB != null)));
                var cntA = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                var cntB = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                var equalCol = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));

                DataTable dtA = null;
                if (tsA != null)
                {
                    dtA = dataSetA.Tables[match.Key];
                    cntA.Text = dtA.Rows.Count.ToString();
                }

                DataTable dtB = null;
                if (tsB != null)
                {
                    dtB = dataSetB.Tables[match.Key];
                    cntB.Text = dtB.Rows.Count.ToString();
                }

                bool areEqual = CompareUtil.DataComparer.Equals(dtA, dtB);
                equalCol.Text = YesNo(areEqual);
                if (!areEqual) item.BackColor = System.Drawing.Color.HotPink;
            }

            if (lvDataTables.Items.Count > 0)
            {
                lvDataTables.Items[0].Selected = true;
                lvDataTables.Focus();
            }


            ////Display table Schema compare information
            //foreach (var match in schemaMatches)
            //{
            //    ListViewItem item = lvSchemaTables.Items.Add(match.Key);
            //    item.Tag = match;
            //    TableSchema tsA = match.Value.Item1;
            //    TableSchema tsB = match.Value.Item2;
            //    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsA != null)));
            //    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(tsB != null)));
            //    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, YesNo(match.Value.Item3)));
            //    var cnt = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, tsA.Columns.Count.ToString()));

            //    if (tsA.Columns.Count != tsB.Columns.Count) cnt.Text += $", {tsB.Columns.Count}";
            //    if (!match.Value.Item3) item.BackColor = System.Drawing.Color.HotPink;
            //}

            //if (lvSchemaTables.Items.Count > 0)
            //{
            //    lvSchemaTables.Items[0].Selected = true;
            //    lvSchemaTables.Focus();
            //}
        }

        private string YesNo(bool value)
        {
            return value ? "Yes" : "**No**";
        }
        #endregion

        #region Schema tab
        private bool CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show(this, $"The file {filePath} does not exist", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void lvSchemaTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSchemaColumns.Items.Clear();
            lvSchemaIndexes.Items.Clear();

            if (lvSchemaTables.SelectedItems.Count > 0)
            {
                var match = (KeyValuePair<string, Tuple<TableSchema, TableSchema, bool>>)lvSchemaTables.SelectedItems[0].Tag;
                lblSchemaTableName.Text = match.Key;

                TableSchema tsA = match.Value.Item1;
                TableSchema tsB = match.Value.Item2;

                DisplayColumnSchemas(tsA, tsB);
                DisplayIndexSchemas(tsA, tsB);
            }
        }

        private void DisplayColumnSchemas(TableSchema tsA, TableSchema tsB)
        {
            List<string> columnNamesA = tsA.Columns.Select(x => x.ColumnName).ToList();
            List<string> columnNamesB = tsB.Columns.Select(x => x.ColumnName).ToList();
            List<string> columnNames = columnNamesA.Union(columnNamesB).OrderBy(x => x).ToList();

            bool foundDiff = false;
            foreach (var columnName in columnNames)
            {
                ColumnSchema schemaA = tsA.Columns.FirstOrDefault(x => x.ColumnName == columnName);
                ColumnSchema schemaB = tsB.Columns.FirstOrDefault(x => x.ColumnName == columnName);
                bool areEqual = CompareUtil.ColumnSchemaComparer.Equals(schemaA, schemaB);

                if ((chkSchemaShowIdentical.Checked && areEqual) || (chkSchemaShowDiff.Checked && !areEqual))
                {
                    ListViewItem item = lvSchemaColumns.Items.Add(columnName);

                    var s1A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s2A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s3A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s4A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var diffSubItem = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
                    var s1B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s2B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s3B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s4B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));

                    if (schemaA != null)
                    {
                        s1A.Text = schemaA.OrdinalPosition.ToString();
                        s2A.Text = schemaA.DataType;
                        s3A.Text = schemaA.MaxLength.ToString();
                        s4A.Text = schemaA.IsNullable.ToString();
                    }

                    if (schemaB != null)
                    {
                        s1B.Text = schemaB.OrdinalPosition.ToString();
                        s2B.Text = schemaB.DataType;
                        s3B.Text = schemaB.MaxLength.ToString();
                        s4B.Text = schemaB.IsNullable.ToString();
                    }

                    if (!areEqual)
                    {
                        item.BackColor = Color.HotPink;
                        foundDiff = true;
                    }
                }
            }

            tpSchemaColumns.Text = "Columns";
            if (foundDiff)
            {
                tpSchemaColumns.Text += " *";
                //PaintTab(tpSchemaColumns, Color.HotPink);
            }
        }

        private void DisplayIndexSchemas(TableSchema tsA, TableSchema tsB)
        {
            List<string> indexNamesA = tsA.Indexes.Select(x => x.IndexName).ToList();
            List<string> indexNamesB = tsB.Indexes.Select(x => x.IndexName).ToList();
            List<string> indexNames = indexNamesA.Union(indexNamesB).OrderBy(x => x).ToList();

            throw new Exception("This is not correct yet index name is not enough...need to include ordinal position too");
            bool foundDiff = false;
            foreach (var indexName in indexNames)
            {
                IndexSchema schemaA = tsA.Indexes.FirstOrDefault(x => x.IndexName == indexName);
                IndexSchema schemaB = tsB.Indexes.FirstOrDefault(x => x.IndexName == indexName);
                bool areEqual = CompareUtil.IndexSchemaComparer.Equals(schemaA, schemaB);

                if ((chkSchemaShowIdentical.Checked && areEqual) || (chkSchemaShowDiff.Checked && !areEqual))
                {
                    ListViewItem item = lvSchemaIndexes.Items.Add(indexName);

                    var s1A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s2A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s3A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var diffSubItem = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
                    var s1B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s2B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
                    var s3B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));

                    if (schemaA != null)
                    {
                        s1A.Text = schemaA.OrdinalPosition.ToString();
                        s2A.Text = schemaA.ColumnName;
                        s3A.Text = schemaA.Attributes;
                    }

                    if (schemaB != null)
                    {
                        s1B.Text = schemaB.OrdinalPosition.ToString();
                        s2B.Text = schemaB.ColumnName;
                        s3B.Text = schemaB.Attributes;
                    }

                    if (!areEqual)
                    {
                        item.BackColor = Color.HotPink;
                        foundDiff = true;
                    }
                }
            }

            tpSchemaIndexes.Text = "Indexes";
            if (foundDiff)
            {
                tpSchemaIndexes.Text += " *";
                //PaintTab(tpSchemaColumns, Color.HotPink);
            }
        }

        /// <summary>
        /// Not working yet
        /// </summary>
        private void PaintTab(TabPage tab, Color color)
        {
            Graphics g = tab.CreateGraphics();
            g.FillRectangle(new SolidBrush(color), tab.Bounds);

            Rectangle paddedBounds = tab.Bounds;
            int yOffset = (tcSchemaResults.SelectedTab == tab) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(g, tab.Text, tcSchemaResults.Font, paddedBounds, tab.ForeColor);
        }

        #endregion

        #region Data tab
        private void lvDataTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lvDataRows.Items.Clear();

            //if (lvSchemaTables.SelectedItems.Count > 0)
            //{
            //    var match = (KeyValuePair<string, Tuple<TableSchema, TableSchema, bool>>)lvSchemaTables.SelectedItems[0].Tag;
            //    lblSchemaTableName.Text = match.Key;

            //    TableSchema tsA = match.Value.Item1;
            //    TableSchema tsB = match.Value.Item2;

            //    List<string> columnNamesA = tsA.Columns.Select(x => x.ColumnName).ToList();
            //    List<string> columnNamesB = tsB.Columns.Select(x => x.ColumnName).ToList();
            //    List<string> columnNames = columnNamesA.Union(columnNamesB).OrderBy(x => x).ToList();

            //    foreach (var columnName in columnNames)
            //    {
            //        ColumnSchema schemaA = tsA.Columns.FirstOrDefault(x => x.ColumnName == columnName);
            //        ColumnSchema schemaB = tsB.Columns.FirstOrDefault(x => x.ColumnName == columnName);
            //        bool areEqual = CompareUtil.ColumnSchemaComparaer.Equals(schemaA, schemaB);

            //        if ((chkSchemaShowIdenticalCols.Checked && areEqual) || (chkSchemaShowDiffCols.Checked && !areEqual))
            //        {
            //            ListViewItem item = lvSchemaColumns.Items.Add(columnName);
            //            item.Tag = match;

            //            var s1A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s2A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s3A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s4A = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var diffSubItem = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, ""));
            //            var s1B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s2B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s3B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));
            //            var s4B = item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "-"));

            //            if (schemaA != null)
            //            {
            //                s1A.Text = schemaA.OrdinalPosition.ToString();
            //                s2A.Text = schemaA.DataType;
            //                s3A.Text = schemaA.MaxLength.ToString();
            //                s4A.Text = schemaA.IsNullable.ToString();
            //            }

            //            if (schemaB != null)
            //            {
            //                s1B.Text = schemaB.OrdinalPosition.ToString();
            //                s2B.Text = schemaB.DataType;
            //                s3B.Text = schemaB.MaxLength.ToString();
            //                s4B.Text = schemaB.IsNullable.ToString();
            //            }

            //            if (!areEqual) item.BackColor = System.Drawing.Color.HotPink;
            //        }
            //    }
            //}
        }
        #endregion
    }
}
