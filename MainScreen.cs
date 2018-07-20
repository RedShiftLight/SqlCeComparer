using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Drawing;

//SELECT name, enabled FROM module WHERE enabled = 1 ORDER by name
//                cmd.CommandText = @"SELECT m.Name, cv.VehicleType, cn.Name as Name2, cv.Value, cn.DataType, cv.Scope, cv.ScopeInstance, cn.IsEditable, cn.IsVisible 
//                                    FROM ConfigurationNames cn Left Join ConfigurationValues cv on cn.id=cv.configurationid 
//                                    Left Join Module m on m.id = cn.moduleid order by m.Name, cv.VehicleType, cn.Name";

namespace SqlCeComparer
{
    public partial class MainScreen : Form
    {
        private CompareUtil _util = null;
        private Color _badColor = Color.HotPink;

        public MainScreen()
        {
            InitializeComponent();
        }

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
        #endregion

        #region Form
        private void MainScreen_Load(object sender, EventArgs e)
        {
            lblSchemaTableName.Text = string.Empty;
        }

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
                _util = new CompareUtil(txtDatabaseA.Text, txtDatabaseB.Text);
                _util.LoadSchemas();

                Dictionary<string, Tuple<TableSchema, TableSchema, bool>> schemaMatches = _util.GetTableSchemaMatches();
                DisplayTableSchemas(schemaMatches);

                if (chkCompareData.Checked)
                {
                    _util.LoadData();
                    CompareData(schemaMatches);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error comparing databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show(this, $"The file {filePath} does not exist", "No File Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
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

                if (!match.Value.Item3) item.BackColor = _badColor;
            }

            if (lvSchemaTables.Items.Count > 0)
            {
                lvSchemaTables.Items[0].Selected = true;
                lvSchemaTables.Focus();
            }
        }

        private void CompareData(Dictionary<string, Tuple<TableSchema, TableSchema, bool>> schemaMatches)
        {
            DataSet dataSetA = _util.DbInfoA.MyDataSet;
            DataSet dataSetB = _util.DbInfoB.MyDataSet;
            if (dataSetA == null || dataSetB == null) return;

            //Display table information
            lvDataTables.Items.Clear();
            foreach (var match in schemaMatches)
            {
                ListViewItem item = lvDataTables.Items.Add(match.Key);
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

                bool areEqual = CompareUtil.DataTableComparer.Equals(dtA, dtB);
                equalCol.Text = YesNo(areEqual);
                Tuple<string, DataTable, DataTable, bool> tag = new Tuple<string, DataTable, DataTable, bool>(match.Key, dtA, dtB, areEqual);
                item.Tag = tag;
                if (!areEqual) item.BackColor = _badColor;
            }

            if (lvDataTables.Items.Count > 0)
            {
                lvDataTables.Items[0].Selected = true;
                lvDataTables.Focus();
            }
        }

        private string YesNo(bool value)
        {
            return value ? "Yes" : "**No**";
        }
        #endregion

        #region Schema tab
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
                        item.BackColor = _badColor;
                        foundDiff = true;
                    }
                }
            }

            tpSchemaColumns.Text = "Columns";
            if (foundDiff)
            {
                tpSchemaColumns.Text += " ***";
                //PaintTab(tpSchemaColumns, _badColor);
            }
        }

        private void DisplayIndexSchemas(TableSchema tsA, TableSchema tsB)
        {
            List<string> indexNames = tsA.Indexes.Select(x => x.IndexName).Union(tsB.Indexes.Select(x => x.IndexName)).OrderBy(x => x).ToList();
            bool foundDiff = false;

            foreach (var indexName in indexNames)
            {
                //Match up the index parts by ordinal position
                Dictionary<int, Tuple<IndexSchema, IndexSchema>> matches = CompareUtil.GetIndexSchemaMatches(indexName, tsA, tsB);

                foreach (var match in matches)
                {
                    bool areEqual = CompareUtil.IndexSchemaComparer.Equals(match.Value.Item1, match.Value.Item2);
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

                        if (match.Value.Item1 != null)
                        {
                            s1A.Text = match.Value.Item1.OrdinalPosition.ToString();
                            s2A.Text = match.Value.Item1.ColumnName;
                            s3A.Text = match.Value.Item1.Attributes;
                        }

                        if (match.Value.Item2 != null)
                        {
                            s1B.Text = match.Value.Item2.OrdinalPosition.ToString();
                            s2B.Text = match.Value.Item2.ColumnName;
                            s3B.Text = match.Value.Item2.Attributes;
                        }

                        if (!areEqual)
                        {
                            item.BackColor = _badColor;
                            foundDiff = true;
                        }
                    }
                }
            }

            tpSchemaIndexes.Text = "Indexes";
            if (foundDiff) tpSchemaIndexes.Text += " ***";
        }
        #endregion

        #region Data tab
        private void lvDataTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDataRows.Items.Clear();

            if (lvDataTables.SelectedItems.Count > 0)
            {
                var match = (Tuple<string, DataTable, DataTable, bool>)lvDataTables.SelectedItems[0].Tag;
                string tableName = match.Item1;
                DataTable dtA = match.Item2;
                DataTable dtB = match.Item3;
                bool isEqual = match.Item4;

                lblDataTableName.Text = tableName;

                //Get the PK for the tables
                List<string> pkColumnsA = dtA.PrimaryKey.Select(x => x.ColumnName).ToList();
                List<string> pkColumnsB = dtB.PrimaryKey.Select(x => x.ColumnName).ToList();
                bool pkAreEqual = pkColumnsA.Except(pkColumnsB).Count() == 0 && pkColumnsB.Except(pkColumnsA).Count() == 0;
                lvDataRows.Items.Clear();
                if (!pkAreEqual || pkColumnsA.Count == 0)
                {
                    ListViewItem item = lvDataRows.Items.Add("Primary keys don't match. Can't display values.");
                    return;
                }

                //Sort the data by the primary keys
                dtA.DefaultView.ApplyDefaultSort = true;
                dtB.DefaultView.ApplyDefaultSort = true;

                //********************Can't make a datarelation between two different data sets!!!!!********************
                //DataSet ds = new DataSet();
                //ds.Tables.Add(dtA);
                //ds.Tables.Add(dtB);
                ////Create DataRelations between the two DataTables using the columns of the PK.
                //DataRelation drA = new DataRelation($"{tableName}_RelationA", dtA.PrimaryKey, dtB.PrimaryKey);
                //DataRelation drB = new DataRelation($"{tableName}_RelationA", dtA.PrimaryKey, dtB.PrimaryKey);
                //******************************************************************************************************

                /*

                //Loop through table A and use the relateion to get data from table B
                //Compare the two DataRows different, show the rows
                //Do again but reverse the data relation...will this take too long?


                foreach (DataRow dr in dtA.Rows)
                {
                    DataRow joinedRow = dr.GetParentRow("JoinRelation");


                    // Just add all the columns' data in "dr" to the New table.
                    for (int i = 0; i < ds.Tables["Table1"].Columns.Count; i++)
                    {
                        current[i] = dr[i];
                    }
                    // Add the column that is not present in the child, which is present in the parent.
                    current["Dname"] = parent["Dname"];
                    jt.Rows.Add(current);
                }
                dataGridView1.DataSource = ds.Tables["Joinedtable"];
                */





                DisplayDataRows(dtA, dtB);
            }
        }

        private List<string> GetPKColumnList(string tableName)
        {
            throw new NotImplementedException();
        }

        private void DisplayDataRows(DataTable dtA, DataTable dtB)
        {
            //throw new NotImplementedException();

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

            //            if (!areEqual) item.BackColor = _badColor;
            //        }
            //    }
            //}
        }
        #endregion

    }
}
