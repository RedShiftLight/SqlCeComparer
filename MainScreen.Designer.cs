namespace SqlCeComparer
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.openScheduleSdf = new System.Windows.Forms.OpenFileDialog();
            this.openConfigSdf = new System.Windows.Forms.OpenFileDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UpdateResults = new System.Windows.Forms.Label();
            this.updateReturnTxt = new System.Windows.Forms.TextBox();
            this.dwelltimehelp = new System.Windows.Forms.PictureBox();
            this.remotevalhelp = new System.Windows.Forms.PictureBox();
            this.timesynchelp = new System.Windows.Forms.PictureBox();
            this.gpstypehelp = new System.Windows.Forms.PictureBox();
            this.buslinkserverhelp = new System.Windows.Forms.PictureBox();
            this.buslinkadapterhelp = new System.Windows.Forms.PictureBox();
            this.otaserverhelp = new System.Windows.Forms.PictureBox();
            this.OtaLocalPicHlp = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.UpdateDB = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StopDwellTxt = new System.Windows.Forms.TextBox();
            this.RemoteValidateTxt = new System.Windows.Forms.TextBox();
            this.TimeSyncTxt = new System.Windows.Forms.TextBox();
            this.TypeGpsTxt = new System.Windows.Forms.TextBox();
            this.LocalAdapterTxt = new System.Windows.Forms.TextBox();
            this.RemoteServerTxt = new System.Windows.Forms.TextBox();
            this.OtaServerTxt = new System.Windows.Forms.TextBox();
            this.OtaAdapterTxt = new System.Windows.Forms.TextBox();
            this.CheckValuesBtn = new System.Windows.Forms.Button();
            this.VehicleTypeLbl = new System.Windows.Forms.Label();
            this.VehicleTypeListBox = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EditConfigTxt = new System.Windows.Forms.TextBox();
            this.EditConfigBtn = new System.Windows.Forms.Button();
            this.Tab = new System.Windows.Forms.TabControl();
            this.tabSchema = new System.Windows.Forms.TabPage();
            this.tcSchemaResults = new System.Windows.Forms.TabControl();
            this.tpSchemaColumns = new System.Windows.Forms.TabPage();
            this.lvSchemaColumns = new System.Windows.Forms.ListView();
            this.chColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColPosA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataTypeA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLengthA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColNullA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColGap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColPosB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataTypeB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLengthB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColNullB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSchemaIndexes = new System.Windows.Forms.TabPage();
            this.lvSchemaIndexes = new System.Windows.Forms.ListView();
            this.chIndexName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexPositionA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexColumnNameA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexAttributesA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexGap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexPositionB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexColumnNameB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndexAttributesB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSchemaTableName = new System.Windows.Forms.Label();
            this.chkSchemaShowDiff = new System.Windows.Forms.CheckBox();
            this.chkSchemaShowIdentical = new System.Windows.Forms.CheckBox();
            this.lvSchemaTables = new System.Windows.Forms.ListView();
            this.chSchemaTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSchemaDbA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSchemaDbB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSchemaEqual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSchemaColCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSchemaIdxCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabData = new System.Windows.Forms.TabPage();
            this.lvDataTables = new System.Windows.Forms.ListView();
            this.chDataTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataDbA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataDbB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataRowCountA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataRowCountB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataEqual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDatabaseB = new System.Windows.Forms.TextBox();
            this.txtDatabaseA = new System.Windows.Forms.TextBox();
            this.btnBrowseB = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnBrowseA = new System.Windows.Forms.Button();
            this.chkCompareData = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lvDataRows = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.lblDataTableName = new System.Windows.Forms.Label();
            this.chkDataShowDiff = new System.Windows.Forms.CheckBox();
            this.chkDataShowIdentical = new System.Windows.Forms.CheckBox();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwelltimehelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remotevalhelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesynchelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpstypehelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buslinkserverhelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buslinkadapterhelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otaserverhelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtaLocalPicHlp)).BeginInit();
            this.Tab.SuspendLayout();
            this.tabSchema.SuspendLayout();
            this.tcSchemaResults.SuspendLayout();
            this.tpSchemaColumns.SuspendLayout();
            this.tpSchemaIndexes.SuspendLayout();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // openScheduleSdf
            // 
            this.openScheduleSdf.FileName = "Schedule.sdf";
            this.openScheduleSdf.Filter = "Database Files|Schedule.sdf|All Files| *.*";
            // 
            // openConfigSdf
            // 
            this.openConfigSdf.FileName = "Configuration.sdf";
            this.openConfigSdf.Filter = "Configuration Database |Configuration.sdf| All Files |*.*";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UpdateResults);
            this.tabPage2.Controls.Add(this.updateReturnTxt);
            this.tabPage2.Controls.Add(this.dwelltimehelp);
            this.tabPage2.Controls.Add(this.remotevalhelp);
            this.tabPage2.Controls.Add(this.timesynchelp);
            this.tabPage2.Controls.Add(this.gpstypehelp);
            this.tabPage2.Controls.Add(this.buslinkserverhelp);
            this.tabPage2.Controls.Add(this.buslinkadapterhelp);
            this.tabPage2.Controls.Add(this.otaserverhelp);
            this.tabPage2.Controls.Add(this.OtaLocalPicHlp);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.UpdateDB);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.StopDwellTxt);
            this.tabPage2.Controls.Add(this.RemoteValidateTxt);
            this.tabPage2.Controls.Add(this.TimeSyncTxt);
            this.tabPage2.Controls.Add(this.TypeGpsTxt);
            this.tabPage2.Controls.Add(this.LocalAdapterTxt);
            this.tabPage2.Controls.Add(this.RemoteServerTxt);
            this.tabPage2.Controls.Add(this.OtaServerTxt);
            this.tabPage2.Controls.Add(this.OtaAdapterTxt);
            this.tabPage2.Controls.Add(this.CheckValuesBtn);
            this.tabPage2.Controls.Add(this.VehicleTypeLbl);
            this.tabPage2.Controls.Add(this.VehicleTypeListBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.EditConfigTxt);
            this.tabPage2.Controls.Add(this.EditConfigBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(695, 592);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Edit / Check Testing Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UpdateResults
            // 
            this.UpdateResults.AutoSize = true;
            this.UpdateResults.Location = new System.Drawing.Point(308, 345);
            this.UpdateResults.Name = "UpdateResults";
            this.UpdateResults.Size = new System.Drawing.Size(80, 13);
            this.UpdateResults.TabIndex = 94;
            this.UpdateResults.Text = "Update Results";
            // 
            // updateReturnTxt
            // 
            this.updateReturnTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateReturnTxt.Location = new System.Drawing.Point(16, 361);
            this.updateReturnTxt.Multiline = true;
            this.updateReturnTxt.Name = "updateReturnTxt";
            this.updateReturnTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.updateReturnTxt.Size = new System.Drawing.Size(654, 202);
            this.updateReturnTxt.TabIndex = 93;
            // 
            // dwelltimehelp
            // 
            this.dwelltimehelp.Image = ((System.Drawing.Image)(resources.GetObject("dwelltimehelp.Image")));
            this.dwelltimehelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("dwelltimehelp.InitialImage")));
            this.dwelltimehelp.Location = new System.Drawing.Point(271, 274);
            this.dwelltimehelp.Name = "dwelltimehelp";
            this.dwelltimehelp.Size = new System.Drawing.Size(21, 16);
            this.dwelltimehelp.TabIndex = 92;
            this.dwelltimehelp.TabStop = false;
            this.dwelltimehelp.Click += new System.EventHandler(this.dwelltimehelp_Click);
            // 
            // remotevalhelp
            // 
            this.remotevalhelp.Image = ((System.Drawing.Image)(resources.GetObject("remotevalhelp.Image")));
            this.remotevalhelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("remotevalhelp.InitialImage")));
            this.remotevalhelp.Location = new System.Drawing.Point(271, 247);
            this.remotevalhelp.Name = "remotevalhelp";
            this.remotevalhelp.Size = new System.Drawing.Size(21, 16);
            this.remotevalhelp.TabIndex = 91;
            this.remotevalhelp.TabStop = false;
            this.remotevalhelp.Click += new System.EventHandler(this.remotevalhelp_Click);
            // 
            // timesynchelp
            // 
            this.timesynchelp.Image = ((System.Drawing.Image)(resources.GetObject("timesynchelp.Image")));
            this.timesynchelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("timesynchelp.InitialImage")));
            this.timesynchelp.Location = new System.Drawing.Point(271, 220);
            this.timesynchelp.Name = "timesynchelp";
            this.timesynchelp.Size = new System.Drawing.Size(21, 16);
            this.timesynchelp.TabIndex = 90;
            this.timesynchelp.TabStop = false;
            this.timesynchelp.Click += new System.EventHandler(this.timesynchelp_Click);
            // 
            // gpstypehelp
            // 
            this.gpstypehelp.Image = ((System.Drawing.Image)(resources.GetObject("gpstypehelp.Image")));
            this.gpstypehelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("gpstypehelp.InitialImage")));
            this.gpstypehelp.Location = new System.Drawing.Point(271, 193);
            this.gpstypehelp.Name = "gpstypehelp";
            this.gpstypehelp.Size = new System.Drawing.Size(21, 16);
            this.gpstypehelp.TabIndex = 89;
            this.gpstypehelp.TabStop = false;
            this.gpstypehelp.Click += new System.EventHandler(this.gpstypehelp_Click);
            // 
            // buslinkserverhelp
            // 
            this.buslinkserverhelp.Image = ((System.Drawing.Image)(resources.GetObject("buslinkserverhelp.Image")));
            this.buslinkserverhelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("buslinkserverhelp.InitialImage")));
            this.buslinkserverhelp.Location = new System.Drawing.Point(271, 166);
            this.buslinkserverhelp.Name = "buslinkserverhelp";
            this.buslinkserverhelp.Size = new System.Drawing.Size(21, 16);
            this.buslinkserverhelp.TabIndex = 88;
            this.buslinkserverhelp.TabStop = false;
            this.buslinkserverhelp.Click += new System.EventHandler(this.buslinkserverhelp_Click);
            // 
            // buslinkadapterhelp
            // 
            this.buslinkadapterhelp.Image = ((System.Drawing.Image)(resources.GetObject("buslinkadapterhelp.Image")));
            this.buslinkadapterhelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("buslinkadapterhelp.InitialImage")));
            this.buslinkadapterhelp.Location = new System.Drawing.Point(271, 141);
            this.buslinkadapterhelp.Name = "buslinkadapterhelp";
            this.buslinkadapterhelp.Size = new System.Drawing.Size(21, 16);
            this.buslinkadapterhelp.TabIndex = 87;
            this.buslinkadapterhelp.TabStop = false;
            this.buslinkadapterhelp.Click += new System.EventHandler(this.buslinkadapterhelp_Click);
            // 
            // otaserverhelp
            // 
            this.otaserverhelp.Image = ((System.Drawing.Image)(resources.GetObject("otaserverhelp.Image")));
            this.otaserverhelp.InitialImage = ((System.Drawing.Image)(resources.GetObject("otaserverhelp.InitialImage")));
            this.otaserverhelp.Location = new System.Drawing.Point(271, 115);
            this.otaserverhelp.Name = "otaserverhelp";
            this.otaserverhelp.Size = new System.Drawing.Size(21, 16);
            this.otaserverhelp.TabIndex = 86;
            this.otaserverhelp.TabStop = false;
            this.otaserverhelp.Click += new System.EventHandler(this.otaserverhelp_Click);
            // 
            // OtaLocalPicHlp
            // 
            this.OtaLocalPicHlp.Image = ((System.Drawing.Image)(resources.GetObject("OtaLocalPicHlp.Image")));
            this.OtaLocalPicHlp.InitialImage = ((System.Drawing.Image)(resources.GetObject("OtaLocalPicHlp.InitialImage")));
            this.OtaLocalPicHlp.Location = new System.Drawing.Point(271, 85);
            this.OtaLocalPicHlp.Name = "OtaLocalPicHlp";
            this.OtaLocalPicHlp.Size = new System.Drawing.Size(21, 16);
            this.OtaLocalPicHlp.TabIndex = 85;
            this.OtaLocalPicHlp.TabStop = false;
            this.OtaLocalPicHlp.Click += new System.EventHandler(this.OtaLocalPicHlp_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(162, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 84;
            this.label16.Text = "Adjust Values Below";
            // 
            // UpdateDB
            // 
            this.UpdateDB.Location = new System.Drawing.Point(135, 311);
            this.UpdateDB.Name = "UpdateDB";
            this.UpdateDB.Size = new System.Drawing.Size(107, 23);
            this.UpdateDB.TabIndex = 83;
            this.UpdateDB.Text = "Update Database";
            this.UpdateDB.UseVisualStyleBackColor = true;
            this.UpdateDB.Click += new System.EventHandler(this.UpdateDB_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 13);
            this.label15.TabIndex = 82;
            this.label15.Text = "Service Stop Dwell Time";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 247);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 81;
            this.label14.Text = "Remote Validation ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "Time Sync Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(76, 193);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Gps Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Buslink Local Adapter";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Buslink Server Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "Ota Server Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Ota Local Adapter";
            // 
            // StopDwellTxt
            // 
            this.StopDwellTxt.Location = new System.Drawing.Point(135, 271);
            this.StopDwellTxt.Name = "StopDwellTxt";
            this.StopDwellTxt.Size = new System.Drawing.Size(130, 20);
            this.StopDwellTxt.TabIndex = 72;
            // 
            // RemoteValidateTxt
            // 
            this.RemoteValidateTxt.Location = new System.Drawing.Point(135, 244);
            this.RemoteValidateTxt.Name = "RemoteValidateTxt";
            this.RemoteValidateTxt.Size = new System.Drawing.Size(130, 20);
            this.RemoteValidateTxt.TabIndex = 71;
            // 
            // TimeSyncTxt
            // 
            this.TimeSyncTxt.Location = new System.Drawing.Point(135, 217);
            this.TimeSyncTxt.Name = "TimeSyncTxt";
            this.TimeSyncTxt.Size = new System.Drawing.Size(130, 20);
            this.TimeSyncTxt.TabIndex = 70;
            // 
            // TypeGpsTxt
            // 
            this.TypeGpsTxt.Location = new System.Drawing.Point(135, 190);
            this.TypeGpsTxt.Name = "TypeGpsTxt";
            this.TypeGpsTxt.Size = new System.Drawing.Size(130, 20);
            this.TypeGpsTxt.TabIndex = 69;
            // 
            // LocalAdapterTxt
            // 
            this.LocalAdapterTxt.Location = new System.Drawing.Point(135, 138);
            this.LocalAdapterTxt.Name = "LocalAdapterTxt";
            this.LocalAdapterTxt.Size = new System.Drawing.Size(130, 20);
            this.LocalAdapterTxt.TabIndex = 68;
            // 
            // RemoteServerTxt
            // 
            this.RemoteServerTxt.Location = new System.Drawing.Point(135, 163);
            this.RemoteServerTxt.Name = "RemoteServerTxt";
            this.RemoteServerTxt.Size = new System.Drawing.Size(130, 20);
            this.RemoteServerTxt.TabIndex = 67;
            // 
            // OtaServerTxt
            // 
            this.OtaServerTxt.Location = new System.Drawing.Point(135, 112);
            this.OtaServerTxt.Name = "OtaServerTxt";
            this.OtaServerTxt.Size = new System.Drawing.Size(130, 20);
            this.OtaServerTxt.TabIndex = 66;
            // 
            // OtaAdapterTxt
            // 
            this.OtaAdapterTxt.Location = new System.Drawing.Point(135, 82);
            this.OtaAdapterTxt.Name = "OtaAdapterTxt";
            this.OtaAdapterTxt.Size = new System.Drawing.Size(130, 20);
            this.OtaAdapterTxt.TabIndex = 65;
            // 
            // CheckValuesBtn
            // 
            this.CheckValuesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckValuesBtn.Location = new System.Drawing.Point(595, 52);
            this.CheckValuesBtn.Name = "CheckValuesBtn";
            this.CheckValuesBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckValuesBtn.TabIndex = 62;
            this.CheckValuesBtn.Text = "Get Settings";
            this.CheckValuesBtn.UseVisualStyleBackColor = true;
            this.CheckValuesBtn.Click += new System.EventHandler(this.CheckValuesBtn_Click);
            // 
            // VehicleTypeLbl
            // 
            this.VehicleTypeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleTypeLbl.AutoSize = true;
            this.VehicleTypeLbl.Location = new System.Drawing.Point(447, 63);
            this.VehicleTypeLbl.Name = "VehicleTypeLbl";
            this.VehicleTypeLbl.Size = new System.Drawing.Size(139, 13);
            this.VehicleTypeLbl.TabIndex = 61;
            this.VehicleTypeLbl.Text = "Select Vehicle Type To Edit";
            // 
            // VehicleTypeListBox
            // 
            this.VehicleTypeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleTypeListBox.FormattingEnabled = true;
            this.VehicleTypeListBox.Location = new System.Drawing.Point(450, 82);
            this.VehicleTypeListBox.Name = "VehicleTypeListBox";
            this.VehicleTypeListBox.Size = new System.Drawing.Size(220, 214);
            this.VehicleTypeListBox.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Select Configuration.sdf to Edit / View";
            // 
            // EditConfigTxt
            // 
            this.EditConfigTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditConfigTxt.Location = new System.Drawing.Point(208, 8);
            this.EditConfigTxt.Name = "EditConfigTxt";
            this.EditConfigTxt.Size = new System.Drawing.Size(378, 20);
            this.EditConfigTxt.TabIndex = 48;
            // 
            // EditConfigBtn
            // 
            this.EditConfigBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditConfigBtn.Location = new System.Drawing.Point(595, 6);
            this.EditConfigBtn.Name = "EditConfigBtn";
            this.EditConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.EditConfigBtn.TabIndex = 47;
            this.EditConfigBtn.Text = "Browse";
            this.EditConfigBtn.UseVisualStyleBackColor = true;
            this.EditConfigBtn.Click += new System.EventHandler(this.EditConfigBtn_Click);
            // 
            // Tab
            // 
            this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab.Controls.Add(this.tabSchema);
            this.Tab.Controls.Add(this.tabData);
            this.Tab.Controls.Add(this.tabPage2);
            this.Tab.Location = new System.Drawing.Point(0, 65);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(703, 618);
            this.Tab.TabIndex = 0;
            // 
            // tabSchema
            // 
            this.tabSchema.Controls.Add(this.label18);
            this.tabSchema.Controls.Add(this.tcSchemaResults);
            this.tabSchema.Controls.Add(this.lblSchemaTableName);
            this.tabSchema.Controls.Add(this.chkSchemaShowDiff);
            this.tabSchema.Controls.Add(this.chkSchemaShowIdentical);
            this.tabSchema.Controls.Add(this.lvSchemaTables);
            this.tabSchema.Location = new System.Drawing.Point(4, 22);
            this.tabSchema.Name = "tabSchema";
            this.tabSchema.Size = new System.Drawing.Size(695, 592);
            this.tabSchema.TabIndex = 3;
            this.tabSchema.Text = "Schema";
            this.tabSchema.UseVisualStyleBackColor = true;
            // 
            // tcSchemaResults
            // 
            this.tcSchemaResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSchemaResults.Controls.Add(this.tpSchemaColumns);
            this.tcSchemaResults.Controls.Add(this.tpSchemaIndexes);
            this.tcSchemaResults.Location = new System.Drawing.Point(8, 294);
            this.tcSchemaResults.Name = "tcSchemaResults";
            this.tcSchemaResults.SelectedIndex = 0;
            this.tcSchemaResults.Size = new System.Drawing.Size(679, 295);
            this.tcSchemaResults.TabIndex = 58;
            // 
            // tpSchemaColumns
            // 
            this.tpSchemaColumns.Controls.Add(this.lvSchemaColumns);
            this.tpSchemaColumns.Location = new System.Drawing.Point(4, 22);
            this.tpSchemaColumns.Name = "tpSchemaColumns";
            this.tpSchemaColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tpSchemaColumns.Size = new System.Drawing.Size(671, 269);
            this.tpSchemaColumns.TabIndex = 0;
            this.tpSchemaColumns.Text = "Columns";
            this.tpSchemaColumns.UseVisualStyleBackColor = true;
            // 
            // lvSchemaColumns
            // 
            this.lvSchemaColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chColName,
            this.chColPosA,
            this.chDataTypeA,
            this.chLengthA,
            this.chColNullA,
            this.chColGap,
            this.chColPosB,
            this.chDataTypeB,
            this.chLengthB,
            this.chColNullB});
            this.lvSchemaColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSchemaColumns.FullRowSelect = true;
            this.lvSchemaColumns.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSchemaColumns.HideSelection = false;
            this.lvSchemaColumns.Location = new System.Drawing.Point(3, 3);
            this.lvSchemaColumns.MultiSelect = false;
            this.lvSchemaColumns.Name = "lvSchemaColumns";
            this.lvSchemaColumns.Size = new System.Drawing.Size(665, 263);
            this.lvSchemaColumns.TabIndex = 56;
            this.lvSchemaColumns.UseCompatibleStateImageBehavior = false;
            this.lvSchemaColumns.View = System.Windows.Forms.View.Details;
            // 
            // chColName
            // 
            this.chColName.Text = "Column Name";
            this.chColName.Width = 180;
            // 
            // chColPosA
            // 
            this.chColPosA.Text = "Position";
            this.chColPosA.Width = 50;
            // 
            // chDataTypeA
            // 
            this.chDataTypeA.Text = "DataType";
            this.chDataTypeA.Width = 70;
            // 
            // chLengthA
            // 
            this.chLengthA.Text = "Length";
            this.chLengthA.Width = 50;
            // 
            // chColNullA
            // 
            this.chColNullA.Text = "Nullable";
            this.chColNullA.Width = 50;
            // 
            // chColGap
            // 
            this.chColGap.Text = "";
            this.chColGap.Width = 20;
            // 
            // chColPosB
            // 
            this.chColPosB.Text = "Position";
            this.chColPosB.Width = 50;
            // 
            // chDataTypeB
            // 
            this.chDataTypeB.Text = "DataType";
            this.chDataTypeB.Width = 70;
            // 
            // chLengthB
            // 
            this.chLengthB.Text = "Length";
            this.chLengthB.Width = 50;
            // 
            // chColNullB
            // 
            this.chColNullB.Text = "Nullable";
            this.chColNullB.Width = 50;
            // 
            // tpSchemaIndexes
            // 
            this.tpSchemaIndexes.Controls.Add(this.lvSchemaIndexes);
            this.tpSchemaIndexes.Location = new System.Drawing.Point(4, 22);
            this.tpSchemaIndexes.Name = "tpSchemaIndexes";
            this.tpSchemaIndexes.Padding = new System.Windows.Forms.Padding(3);
            this.tpSchemaIndexes.Size = new System.Drawing.Size(671, 269);
            this.tpSchemaIndexes.TabIndex = 1;
            this.tpSchemaIndexes.Text = "Indexes";
            this.tpSchemaIndexes.UseVisualStyleBackColor = true;
            // 
            // lvSchemaIndexes
            // 
            this.lvSchemaIndexes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIndexName,
            this.chIndexPositionA,
            this.chIndexColumnNameA,
            this.chIndexAttributesA,
            this.chIndexGap,
            this.chIndexPositionB,
            this.chIndexColumnNameB,
            this.chIndexAttributesB});
            this.lvSchemaIndexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSchemaIndexes.FullRowSelect = true;
            this.lvSchemaIndexes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSchemaIndexes.HideSelection = false;
            this.lvSchemaIndexes.Location = new System.Drawing.Point(3, 3);
            this.lvSchemaIndexes.MultiSelect = false;
            this.lvSchemaIndexes.Name = "lvSchemaIndexes";
            this.lvSchemaIndexes.Size = new System.Drawing.Size(665, 263);
            this.lvSchemaIndexes.TabIndex = 0;
            this.lvSchemaIndexes.UseCompatibleStateImageBehavior = false;
            this.lvSchemaIndexes.View = System.Windows.Forms.View.Details;
            // 
            // chIndexName
            // 
            this.chIndexName.Text = "Index Name";
            this.chIndexName.Width = 200;
            // 
            // chIndexPositionA
            // 
            this.chIndexPositionA.Text = "Position";
            this.chIndexPositionA.Width = 50;
            // 
            // chIndexColumnNameA
            // 
            this.chIndexColumnNameA.Text = "Column Name";
            this.chIndexColumnNameA.Width = 100;
            // 
            // chIndexAttributesA
            // 
            this.chIndexAttributesA.Text = "Attributes";
            // 
            // chIndexGap
            // 
            this.chIndexGap.Text = " ";
            this.chIndexGap.Width = 20;
            // 
            // chIndexPositionB
            // 
            this.chIndexPositionB.Text = "Position";
            this.chIndexPositionB.Width = 50;
            // 
            // chIndexColumnNameB
            // 
            this.chIndexColumnNameB.Text = "Column Name";
            this.chIndexColumnNameB.Width = 100;
            // 
            // chIndexAttributesB
            // 
            this.chIndexAttributesB.Text = "Attributes";
            // 
            // lblSchemaTableName
            // 
            this.lblSchemaTableName.AutoSize = true;
            this.lblSchemaTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchemaTableName.Location = new System.Drawing.Point(88, 270);
            this.lblSchemaTableName.Name = "lblSchemaTableName";
            this.lblSchemaTableName.Size = new System.Drawing.Size(164, 17);
            this.lblSchemaTableName.TabIndex = 57;
            this.lblSchemaTableName.Text = "lblSchemaTableName";
            // 
            // chkSchemaShowDiff
            // 
            this.chkSchemaShowDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSchemaShowDiff.AutoSize = true;
            this.chkSchemaShowDiff.Checked = true;
            this.chkSchemaShowDiff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSchemaShowDiff.Location = new System.Drawing.Point(582, 271);
            this.chkSchemaShowDiff.Name = "chkSchemaShowDiff";
            this.chkSchemaShowDiff.Size = new System.Drawing.Size(96, 17);
            this.chkSchemaShowDiff.TabIndex = 56;
            this.chkSchemaShowDiff.Text = "Show Different";
            this.chkSchemaShowDiff.UseVisualStyleBackColor = true;
            this.chkSchemaShowDiff.CheckedChanged += new System.EventHandler(this.lvSchemaTables_SelectedIndexChanged);
            // 
            // chkSchemaShowIdentical
            // 
            this.chkSchemaShowIdentical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSchemaShowIdentical.AutoSize = true;
            this.chkSchemaShowIdentical.Checked = true;
            this.chkSchemaShowIdentical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSchemaShowIdentical.Location = new System.Drawing.Point(468, 271);
            this.chkSchemaShowIdentical.Name = "chkSchemaShowIdentical";
            this.chkSchemaShowIdentical.Size = new System.Drawing.Size(96, 17);
            this.chkSchemaShowIdentical.TabIndex = 55;
            this.chkSchemaShowIdentical.Text = "Show Identical";
            this.chkSchemaShowIdentical.UseVisualStyleBackColor = true;
            this.chkSchemaShowIdentical.CheckedChanged += new System.EventHandler(this.lvSchemaTables_SelectedIndexChanged);
            // 
            // lvSchemaTables
            // 
            this.lvSchemaTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSchemaTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSchemaTableName,
            this.chSchemaDbA,
            this.chSchemaDbB,
            this.chSchemaEqual,
            this.chSchemaColCount,
            this.chSchemaIdxCount});
            this.lvSchemaTables.FullRowSelect = true;
            this.lvSchemaTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSchemaTables.HideSelection = false;
            this.lvSchemaTables.Location = new System.Drawing.Point(8, 3);
            this.lvSchemaTables.MultiSelect = false;
            this.lvSchemaTables.Name = "lvSchemaTables";
            this.lvSchemaTables.Size = new System.Drawing.Size(679, 245);
            this.lvSchemaTables.TabIndex = 54;
            this.lvSchemaTables.UseCompatibleStateImageBehavior = false;
            this.lvSchemaTables.View = System.Windows.Forms.View.Details;
            this.lvSchemaTables.SelectedIndexChanged += new System.EventHandler(this.lvSchemaTables_SelectedIndexChanged);
            // 
            // chSchemaTableName
            // 
            this.chSchemaTableName.Text = "Table Name";
            this.chSchemaTableName.Width = 150;
            // 
            // chSchemaDbA
            // 
            this.chSchemaDbA.Text = "Found in Db A";
            this.chSchemaDbA.Width = 90;
            // 
            // chSchemaDbB
            // 
            this.chSchemaDbB.Text = "Found in Db B";
            this.chSchemaDbB.Width = 90;
            // 
            // chSchemaEqual
            // 
            this.chSchemaEqual.Text = "Are Equal";
            this.chSchemaEqual.Width = 90;
            // 
            // chSchemaColCount
            // 
            this.chSchemaColCount.Text = "Column Count";
            this.chSchemaColCount.Width = 80;
            // 
            // chSchemaIdxCount
            // 
            this.chSchemaIdxCount.Text = "Index Count";
            this.chSchemaIdxCount.Width = 80;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.label4);
            this.tabData.Controls.Add(this.lblDataTableName);
            this.tabData.Controls.Add(this.chkDataShowDiff);
            this.tabData.Controls.Add(this.chkDataShowIdentical);
            this.tabData.Controls.Add(this.lvDataRows);
            this.tabData.Controls.Add(this.lvDataTables);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(695, 592);
            this.tabData.TabIndex = 4;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // lvDataTables
            // 
            this.lvDataTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDataTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDataTableName,
            this.chDataDbA,
            this.chDataDbB,
            this.chDataRowCountA,
            this.chDataRowCountB,
            this.chDataEqual});
            this.lvDataTables.FullRowSelect = true;
            this.lvDataTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDataTables.HideSelection = false;
            this.lvDataTables.Location = new System.Drawing.Point(8, 3);
            this.lvDataTables.MultiSelect = false;
            this.lvDataTables.Name = "lvDataTables";
            this.lvDataTables.Size = new System.Drawing.Size(679, 245);
            this.lvDataTables.TabIndex = 55;
            this.lvDataTables.UseCompatibleStateImageBehavior = false;
            this.lvDataTables.View = System.Windows.Forms.View.Details;
            this.lvDataTables.SelectedIndexChanged += new System.EventHandler(this.lvDataTables_SelectedIndexChanged);
            // 
            // chDataTableName
            // 
            this.chDataTableName.Text = "Table Name";
            this.chDataTableName.Width = 150;
            // 
            // chDataDbA
            // 
            this.chDataDbA.Text = "Found in Db A";
            this.chDataDbA.Width = 90;
            // 
            // chDataDbB
            // 
            this.chDataDbB.Text = "Found in Db B";
            this.chDataDbB.Width = 90;
            // 
            // chDataRowCountA
            // 
            this.chDataRowCountA.Text = "RowCount A";
            this.chDataRowCountA.Width = 90;
            // 
            // chDataRowCountB
            // 
            this.chDataRowCountB.Text = "RowCount B";
            this.chDataRowCountB.Width = 80;
            // 
            // chDataEqual
            // 
            this.chDataEqual.Text = "Are Equal";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Configuration.sdf";
            this.openFileDialog1.Filter = "Configuration Database |Configuration.sdf| All Files |*.*";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(570, 9);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(129, 23);
            this.btnCompare.TabIndex = 60;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Database A";
            // 
            // txtDatabaseB
            // 
            this.txtDatabaseB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseB.Location = new System.Drawing.Point(81, 38);
            this.txtDatabaseB.Name = "txtDatabaseB";
            this.txtDatabaseB.Size = new System.Drawing.Size(402, 20);
            this.txtDatabaseB.TabIndex = 57;
            this.txtDatabaseB.Text = "C:\\Users\\jimkr\\Desktop\\Configuration-VTA-S54-PSA.sdf";
            // 
            // txtDatabaseA
            // 
            this.txtDatabaseA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseA.Location = new System.Drawing.Point(81, 12);
            this.txtDatabaseA.Name = "txtDatabaseA";
            this.txtDatabaseA.Size = new System.Drawing.Size(402, 20);
            this.txtDatabaseA.TabIndex = 55;
            this.txtDatabaseA.Text = "C:\\Users\\jimkr\\Desktop\\Configuration-VTA-S54.sdf";
            // 
            // btnBrowseB
            // 
            this.btnBrowseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseB.Location = new System.Drawing.Point(489, 36);
            this.btnBrowseB.Name = "btnBrowseB";
            this.btnBrowseB.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseB.TabIndex = 58;
            this.btnBrowseB.Text = "Browse";
            this.btnBrowseB.UseVisualStyleBackColor = true;
            this.btnBrowseB.Click += new System.EventHandler(this.btnBrowseB_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 56;
            this.label17.Text = "Database B";
            // 
            // btnBrowseA
            // 
            this.btnBrowseA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseA.Location = new System.Drawing.Point(489, 11);
            this.btnBrowseA.Name = "btnBrowseA";
            this.btnBrowseA.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseA.TabIndex = 54;
            this.btnBrowseA.Text = "Browse";
            this.btnBrowseA.UseVisualStyleBackColor = true;
            this.btnBrowseA.Click += new System.EventHandler(this.btnBrowseA_Click);
            // 
            // chkCompareData
            // 
            this.chkCompareData.AutoSize = true;
            this.chkCompareData.Checked = true;
            this.chkCompareData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareData.Location = new System.Drawing.Point(582, 38);
            this.chkCompareData.Name = "chkCompareData";
            this.chkCompareData.Size = new System.Drawing.Size(116, 17);
            this.chkCompareData.TabIndex = 61;
            this.chkCompareData.Text = "Compare Data Too";
            this.chkCompareData.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(5, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 17);
            this.label18.TabIndex = 59;
            this.label18.Text = "TableName: ";
            // 
            // lvDataRows
            // 
            this.lvDataRows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDataRows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvDataRows.FullRowSelect = true;
            this.lvDataRows.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDataRows.HideSelection = false;
            this.lvDataRows.Location = new System.Drawing.Point(8, 294);
            this.lvDataRows.MultiSelect = false;
            this.lvDataRows.Name = "lvDataRows";
            this.lvDataRows.Size = new System.Drawing.Size(679, 290);
            this.lvDataRows.TabIndex = 56;
            this.lvDataRows.UseCompatibleStateImageBehavior = false;
            this.lvDataRows.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Table Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Found in Db A";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Found in Db B";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "RowCount A";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "RowCount B";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Are Equal";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 63;
            this.label4.Text = "TableName: ";
            // 
            // lblDataTableName
            // 
            this.lblDataTableName.AutoSize = true;
            this.lblDataTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataTableName.Location = new System.Drawing.Point(88, 270);
            this.lblDataTableName.Name = "lblDataTableName";
            this.lblDataTableName.Size = new System.Drawing.Size(141, 17);
            this.lblDataTableName.TabIndex = 62;
            this.lblDataTableName.Text = "lblDataTableName";
            // 
            // chkDataShowDiff
            // 
            this.chkDataShowDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDataShowDiff.AutoSize = true;
            this.chkDataShowDiff.Checked = true;
            this.chkDataShowDiff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataShowDiff.Location = new System.Drawing.Point(582, 271);
            this.chkDataShowDiff.Name = "chkDataShowDiff";
            this.chkDataShowDiff.Size = new System.Drawing.Size(96, 17);
            this.chkDataShowDiff.TabIndex = 61;
            this.chkDataShowDiff.Text = "Show Different";
            this.chkDataShowDiff.UseVisualStyleBackColor = true;
            // 
            // chkDataShowIdentical
            // 
            this.chkDataShowIdentical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDataShowIdentical.AutoSize = true;
            this.chkDataShowIdentical.Checked = true;
            this.chkDataShowIdentical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataShowIdentical.Location = new System.Drawing.Point(468, 271);
            this.chkDataShowIdentical.Name = "chkDataShowIdentical";
            this.chkDataShowIdentical.Size = new System.Drawing.Size(96, 17);
            this.chkDataShowIdentical.TabIndex = 60;
            this.chkDataShowIdentical.Text = "Show Identical";
            this.chkDataShowIdentical.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 683);
            this.Controls.Add(this.chkCompareData);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDatabaseB);
            this.Controls.Add(this.txtDatabaseA);
            this.Controls.Add(this.btnBrowseB);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnBrowseA);
            this.Controls.Add(this.Tab);
            this.Name = "MainScreen";
            this.Text = "CleverWare Configuration Diff Tool";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwelltimehelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remotevalhelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesynchelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpstypehelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buslinkserverhelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buslinkadapterhelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otaserverhelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtaLocalPicHlp)).EndInit();
            this.Tab.ResumeLayout(false);
            this.tabSchema.ResumeLayout(false);
            this.tabSchema.PerformLayout();
            this.tcSchemaResults.ResumeLayout(false);
            this.tpSchemaColumns.ResumeLayout(false);
            this.tpSchemaIndexes.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openScheduleSdf;
        private System.Windows.Forms.OpenFileDialog openConfigSdf;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox EditConfigTxt;
        private System.Windows.Forms.Button EditConfigBtn;
        private System.Windows.Forms.Label VehicleTypeLbl;
        private System.Windows.Forms.CheckedListBox VehicleTypeListBox;
        private System.Windows.Forms.Button CheckValuesBtn;
        private System.Windows.Forms.TextBox TimeSyncTxt;
        private System.Windows.Forms.TextBox TypeGpsTxt;
        private System.Windows.Forms.TextBox LocalAdapterTxt;
        private System.Windows.Forms.TextBox RemoteServerTxt;
        private System.Windows.Forms.TextBox OtaServerTxt;
        private System.Windows.Forms.TextBox OtaAdapterTxt;
        private System.Windows.Forms.TextBox StopDwellTxt;
        private System.Windows.Forms.TextBox RemoteValidateTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button UpdateDB;
        private System.Windows.Forms.PictureBox OtaLocalPicHlp;
        private System.Windows.Forms.PictureBox dwelltimehelp;
        private System.Windows.Forms.PictureBox remotevalhelp;
        private System.Windows.Forms.PictureBox timesynchelp;
        private System.Windows.Forms.PictureBox gpstypehelp;
        private System.Windows.Forms.PictureBox buslinkserverhelp;
        private System.Windows.Forms.PictureBox buslinkadapterhelp;
        private System.Windows.Forms.PictureBox otaserverhelp;
        private System.Windows.Forms.TextBox updateReturnTxt;
        private System.Windows.Forms.Label UpdateResults;
        private System.Windows.Forms.TabPage tabSchema;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lvSchemaTables;
        private System.Windows.Forms.ColumnHeader chSchemaTableName;
        private System.Windows.Forms.ColumnHeader chSchemaDbA;
        private System.Windows.Forms.ColumnHeader chSchemaDbB;
        private System.Windows.Forms.ColumnHeader chSchemaEqual;
        private System.Windows.Forms.CheckBox chkSchemaShowDiff;
        private System.Windows.Forms.CheckBox chkSchemaShowIdentical;
        private System.Windows.Forms.ColumnHeader chSchemaColCount;
        private System.Windows.Forms.Label lblSchemaTableName;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDatabaseB;
        private System.Windows.Forms.TextBox txtDatabaseA;
        private System.Windows.Forms.Button btnBrowseB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBrowseA;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.CheckBox chkCompareData;
        private System.Windows.Forms.ListView lvDataTables;
        private System.Windows.Forms.ColumnHeader chDataTableName;
        private System.Windows.Forms.ColumnHeader chDataDbA;
        private System.Windows.Forms.ColumnHeader chDataDbB;
        private System.Windows.Forms.ColumnHeader chDataRowCountA;
        private System.Windows.Forms.ColumnHeader chDataRowCountB;
        private System.Windows.Forms.ColumnHeader chDataEqual;
        private System.Windows.Forms.TabControl tcSchemaResults;
        private System.Windows.Forms.TabPage tpSchemaColumns;
        private System.Windows.Forms.TabPage tpSchemaIndexes;
        private System.Windows.Forms.ListView lvSchemaIndexes;
        private System.Windows.Forms.ColumnHeader chIndexName;
        private System.Windows.Forms.ColumnHeader chIndexPositionA;
        private System.Windows.Forms.ColumnHeader chIndexColumnNameA;
        private System.Windows.Forms.ColumnHeader chIndexAttributesA;
        private System.Windows.Forms.ListView lvSchemaColumns;
        private System.Windows.Forms.ColumnHeader chColName;
        private System.Windows.Forms.ColumnHeader chColPosA;
        private System.Windows.Forms.ColumnHeader chDataTypeA;
        private System.Windows.Forms.ColumnHeader chLengthA;
        private System.Windows.Forms.ColumnHeader chColNullA;
        private System.Windows.Forms.ColumnHeader chColGap;
        private System.Windows.Forms.ColumnHeader chColPosB;
        private System.Windows.Forms.ColumnHeader chDataTypeB;
        private System.Windows.Forms.ColumnHeader chLengthB;
        private System.Windows.Forms.ColumnHeader chColNullB;
        private System.Windows.Forms.ColumnHeader chIndexGap;
        private System.Windows.Forms.ColumnHeader chIndexPositionB;
        private System.Windows.Forms.ColumnHeader chIndexColumnNameB;
        private System.Windows.Forms.ColumnHeader chIndexAttributesB;
        private System.Windows.Forms.ColumnHeader chSchemaIdxCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDataTableName;
        private System.Windows.Forms.CheckBox chkDataShowDiff;
        private System.Windows.Forms.CheckBox chkDataShowIdentical;
        private System.Windows.Forms.ListView lvDataRows;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

