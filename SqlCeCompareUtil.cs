using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;

namespace SqlCeComparer
{
    public class SqlCeCompareUtil
    {
        #region Members
        private string _fileA;
        private string _fileB;
        #endregion

        #region Properties
        public DbInfo DbInfoA { get; private set; }
        public DbInfo DbInfoB { get; private set; }
        #endregion

        #region Constructor
        public SqlCeCompareUtil(string fileA, string fileB)
        {
            _fileA = fileA;
            _fileB = fileB;

            DbInfoA = new DbInfo(_fileA);
            DbInfoB = new DbInfo(_fileB);
        }
        #endregion

        #region Methods
        public void LoadSchemas()
        {
            DbInfoA.LoadSchema();
            DbInfoB.LoadSchema();
        }

        public Dictionary<string, Tuple<bool, bool>> CompareTableExistence()
        {
            /*
             * tables in a, not in b
             * tables in b, not in a
             * tables in both
             */

            Dictionary<string, Tuple<bool, bool>> result = new Dictionary<string, Tuple<bool, bool>>();

            IEnumerable<string> foo = DbInfoA.TableNames.Except(DbInfoB.TableNames, StringComparer.CurrentCultureIgnoreCase);
            foreach (string tableName in foo)
                result.Add(tableName, new Tuple<bool, bool>(true, false));

            foo = DbInfoB.TableNames.Except(DbInfoA.TableNames, StringComparer.CurrentCultureIgnoreCase);
            foreach (string tableName in foo)
                result.Add(tableName, new Tuple<bool, bool>(false, true));

            foo = DbInfoA.TableNames.Intersect(DbInfoB.TableNames, StringComparer.CurrentCultureIgnoreCase);
            foreach (string tableName in foo)
                result.Add(tableName, new Tuple<bool, bool>(true, true));

            return result;
        }

        public void CompareTableSchema(string tableName)
        {
            DataView dvA = DbInfoA.GetColumnDataView(tableName);
            DataView dvB = DbInfoB.GetColumnDataView(tableName);

            //Make a class to hold the data with IComparable
            //get a list from each table
            //Return Dictionary<ColumnName, Tuple<ClassA, ClassB>>

        }
        #endregion
    }

    public class DbInfo
    {
        #region Members
        public static readonly string TablesTableName = "Tables";
        public static readonly string ColumnsTableName = "Columns";
        #endregion

        #region Properties
        public List<string> TableNames { get; private set; }
        public string FilePath { get; private set; }
        public DataSet MyDataSet { get; private set; }
        public string ConnectionString { get; set; }
        #endregion

        #region Constructor
        public DbInfo(string filePath)
        {
            FilePath = filePath;
            ConnectionString = $"Data Source={FilePath};Max Buffer Size={1024 * 500};Mode=Read Only;";
            MyDataSet = new DataSet();
        }
        #endregion

        #region Methods
        public bool LoadSchema()
        {
            var conn = new SqlCeConnection(ConnectionString);

            //Get names of tables
            try
            {
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_type = 'table' ORDER BY table_name";
                string tableName = TablesTableName;
                using (var dr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable(tableName);
                    if (MyDataSet.Tables.Contains(tableName)) MyDataSet.Tables.Remove(tableName);
                    MyDataSet.Tables.Add(dt);
                    dt.Load(dr);
                }

                //Throw the table names into an easy to use list
                TableNames = new List<string>();
                foreach (DataRow row in MyDataSet.Tables[TablesTableName].DefaultView)
                {
                    string item = row["table_name"].ToString();
                    TableNames.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

            //Get column information
            try
            {
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT table_name, column_name, is_nullable, data_type, character_maximum_length FROM information_schema.columns ORDER BY table_name, column_name";
                string tableName = ColumnsTableName;
                using (var dr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable(tableName);
                    if (MyDataSet.Tables.Contains(tableName)) MyDataSet.Tables.Remove(tableName);

                    MyDataSet.Tables.Add(dt);
                    dt.Load(dr);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            var conn = new SqlCeConnection(ConnectionString);

            foreach (DataRow row in MyDataSet.Tables[TablesTableName].DefaultView)
            {
                string tableName = row["table_name"].ToString();

                //Get data from the table
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"SELECT * FROM {tableName}";
                    using (var dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable(tableName);
                        if (MyDataSet.Tables.Contains(tableName)) MyDataSet.Tables.Remove(tableName);

                        MyDataSet.Tables.Add(dt);
                        dt.Load(dr);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        public DataView GetColumnDataView(string tableName)
        {
            DataView result = MyDataSet.Tables[ColumnsTableName].AsDataView();
            result.RowFilter = $"table_name = '{tableName}'";
            return result;
        }

        #endregion

        /*
            INFORMATION_SCHEMA views
            COLUMNS                   Columns accessed to the current user in the current database.
            INDEXES                   Indexes in the current database.
            KEY_COLUMN_USAGE          Keys in the current database.
            PROVIDER_TYPES            Data types supported in SQL Server Compact.
            TABLES                    Tables accessible to the current user in the current database.
            TABLE_CONSTRAINTS         Table constraints in the current database.
            REFERENTIAL_CONSTRAINTS   Foreign constraint in the current database
         */
    }
}