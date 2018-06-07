using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SqlCeComparer
{
    public partial class DatabaseTool : Form
    {

        public DatabaseTool()
        {
            InitializeComponent();
        }

        #region FirstTab
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
            if(Directory.Exists("C:/Program Files (x86)/WinMerge"))
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

        #region Second Tab
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
                while(SqlReturn2.Read())
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
                    else if(MessageResult == DialogResult.Cancel)
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
                while(SqlReturn2.Read())
                {
                    newModuleList.Add(Convert.ToString(SqlReturn2["Name"]));
                }
                textBox1.Text = string.Join(Environment.NewLine, oldModuleList);
                textBox2.Text = string.Join(Environment.NewLine, newModuleList);
                var inOldList = newModuleList.Except(oldModuleList).ToList();
                var inNewList = oldModuleList.Except(newModuleList).ToList();
                var MissingModules = inOldList.Concat(inNewList);
                bool isEmpty = !MissingModules.Any();
                if(isEmpty)
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

        #region Third tab
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

            SqlCeCompareUtil util = new SqlCeCompareUtil(txtDatabaseA.Text, txtDatabaseB.Text);
            util.GetTableList(FileIndicator.FileA);
            util.GetTableList(FileIndicator.FileB);
            foreach (string table in util.TableNames)
            {

            }
            util.CompareSchemas();
            
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
        #endregion
    }
}
