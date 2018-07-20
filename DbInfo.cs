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
                LoadTableSchemas(result, conn);
                foreach (var item in result.Tables)
                {
                    LoadColumnSchemas(item.Value, conn);
                    LoadIndexSchemas(item.Value, conn);
                }
            }
            finally
            {
                conn.Close();
            }

            Schema = result;
        }

        private void LoadTableSchemas(DbSchema dbSchema, SqlCeConnection conn)
        {
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
                        dbSchema.Tables.Add(tableName, ts);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to select from information_schema.tables", ex);
            }
        }

        private void LoadColumnSchemas(TableSchema tableSchema, SqlCeConnection conn)
        {
            //Get column information
            try
            {
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT column_name, ordinal_position, data_type, " +
                    "case is_nullable when 'YES' then 1 else 0 end AS is_nullable, coalesce(character_maximum_length, 0) as character_maximum_length " +
                    "FROM information_schema.columns WHERE table_name = @TableName ORDER BY ordinal_position";
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters[0].Value = tableSchema.TableName;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ColumnSchema item = new ColumnSchema();
                        item.TableName = tableSchema.TableName;
                        item.ColumnName = dr[0].ToString();
                        item.OrdinalPosition = Convert.ToInt32(dr[1]);
                        item.DataType = dr[2].ToString();
                        item.IsNullable = Convert.ToBoolean(dr[3]);
                        item.MaxLength = Convert.ToInt32(dr[4]);

                        tableSchema.Columns.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to select from information_schema.columns", ex);
            }
        }

        private void LoadIndexSchemas(TableSchema tableSchema, SqlCeConnection conn)
        {
            //Get column information
            try
            {
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT index_name, ordinal_position, column_name " +
                    ", case collation when 1 then 'Asc' else 'Desc' end as SortDirection, primary_key, [unique], [clustered] " +
                    "FROM information_schema.indexes WHERE table_name = @TableName ORDER BY table_name, index_name, ordinal_position";
                cmd.Parameters.Add("@TableName", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters[0].Value = tableSchema.TableName;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IndexSchema item = new IndexSchema();
                        item.TableName = tableSchema.TableName;
                        item.IndexName = dr[0].ToString();
                        item.OrdinalPosition = Convert.ToInt32(dr[1]);
                        item.ColumnName = dr[2].ToString();
                        item.SortDirection = dr[3].ToString();
                        item.IsPrimaryKey = Convert.ToBoolean(dr[4]);
                        item.IsUnique = Convert.ToBoolean(dr[5]);
                        item.IsClustered = Convert.ToBoolean(dr[6]);

                        tableSchema.Indexes.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to select from information_schema.indexes", ex);
            }
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

                        DataTable dt = result.Tables.Add(tableName);

                        using (SqlCeDataAdapter da = new SqlCeDataAdapter(cmd))
                            da.FillSchema(dt, SchemaType.Source);

                        using (var dr = cmd.ExecuteReader())
                            dt.Load(dr);
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
            .TABLES                    Tables accessible to the current user in the current database.
            .COLUMNS                   Columns accessed to the current user in the current database.
            .INDEXES                   Indexes in the current database.
            .TABLE_CONSTRAINTS         Table constraints in the current database.
            .KEY_COLUMN_USAGE          Keys in the current database.
            .PROVIDER_TYPES            Data types supported in SQL Server Compact.
            .REFERENTIAL_CONSTRAINTS   Foreign constraint in the current database



        select * FROM information_schema.TABLE_CONSTRAINTS WHERE constraint_type = 'primary key' and table_name = 'jimtest'
        select * FROM information_schema.KEY_COLUMN_USAGE WHERE constraint_name = 'pk_jimtest' --and table_name = 'jimtest'
         */
    }
}
