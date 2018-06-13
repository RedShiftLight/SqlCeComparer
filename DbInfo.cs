using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCeComparer
{
    public class DbInfo
    {
        #region Members
        #endregion

        #region Properties
        public string FilePath { get; private set; }
        public string ConnectionString { get; private set; }
        public DbSchema Schema { get; set; }
        public DataSet MyDataSet { get; private set; }
        #endregion

        #region Constructor
        public DbInfo(string filePath)
        {
            FilePath = filePath;
            ConnectionString = $"Data Source={FilePath};Max Buffer Size={1024 * 255};Mode=Read Write;";
            //ConnectionString = $"Data Source={FilePath};Mode=Read Only;";
            Schema = new DbSchema();
            MyDataSet = new DataSet();
        }
        #endregion

        #region Methods
        public void LoadSchema()
        {
            var conn = new SqlCeConnection(ConnectionString);
            DbSchema result = new DbSchema();

            try
            {
                conn.Open();

                //Get names of tables
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_type = 'table' ORDER BY table_name";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string tableName = dr["table_name"].ToString();
                            TableSchema ts = new TableSchema(tableName);
                            result.Tables.Add(tableName, ts);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to select from information_schema.tables", ex);
                }

                //Get column information
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT table_name, column_name, ordinal_position, data_type, is_nullable, character_maximum_length FROM information_schema.columns ORDER BY table_name, ordinal_position";

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ColumnSchema cs = new ColumnSchema();
                            cs.TableName = dr["table_name"].ToString();
                            cs.ColumnName = dr["column_name"].ToString();
                            cs.OrdinalPosition = Convert.ToInt32(dr["ordinal_position"]);
                            cs.DataType = dr["data_type"].ToString();
                            string tmp = Convert.ToString(dr["is_nullable"]).ToUpper();
                            cs.IsNullable = tmp == "YES";
                            tmp = Convert.ToString(dr["character_maximum_length"]);
                            if (!string.IsNullOrEmpty(tmp)) cs.MaxLength = Convert.ToInt32(dr["character_maximum_length"]);

                            if (result.Tables.TryGetValue(cs.TableName, out TableSchema ts)) ts.Columns.Add(cs);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to select from information_schema.columns", ex);
                }
            }
            finally
            {
                conn.Close();
            }

            Schema = result;
        }

        public void LoadData()
        {
            var conn = new SqlCeConnection(ConnectionString);
            DataSet result = new DataSet();

            try
            {
                conn.Open();

                foreach (string tableName in Schema.Tables.Keys)
                {
                    //Get data from the table
                    try
                    {
                        SqlCeCommand cmd = conn.CreateCommand();
                        cmd.CommandText = $"SELECT * FROM {tableName}";
                        using (var dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable(tableName);
                            result.Tables.Add(dt);
                            dt.Load(dr);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Unable to select from {tableName}", ex);
                    }
                }
            }
            finally
            {
                conn.Close();
            }

            MyDataSet = result;
        }

        #endregion

        /*
            INFORMATION_SCHEMA views
            .COLUMNS                   Columns accessed to the current user in the current database.
            .INDEXES                   Indexes in the current database.
            .KEY_COLUMN_USAGE          Keys in the current database.
            .PROVIDER_TYPES            Data types supported in SQL Server Compact.
            .TABLES                    Tables accessible to the current user in the current database.
            .TABLE_CONSTRAINTS         Table constraints in the current database.
            .REFERENTIAL_CONSTRAINTS   Foreign constraint in the current database
         */
    }
}
