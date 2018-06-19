using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;

namespace SqlCeComparer
{
    public class CompareUtil
    {
        #region Members
        public static DbSchemaComparer DbSchemaComparer = new DbSchemaComparer();
        public static TableSchemaComparer TableSchemaComparer = new TableSchemaComparer();
        public static ColumnSchemaComparer ColumnSchemaComparer = new ColumnSchemaComparer();
        public static IndexSchemaComparer IndexSchemaComparer = new IndexSchemaComparer();
        public static DataComparer DataComparer = new DataComparer();

        private string _fileA;
        private string _fileB;
        #endregion

        #region Properties
        public DbInfo DbInfoA { get; set; }
        public DbInfo DbInfoB { get; set; }
        #endregion

        #region Constructor
        public CompareUtil(string fileA, string fileB)
        {
            _fileA = fileA;
            _fileB = fileB;

            DbInfoA = new DbInfo(_fileA);
            DbInfoB = new DbInfo(_fileB);
        }
        #endregion

        #region Concrete Methods
        public void LoadSchemas()
        {
            DbInfoA.LoadSchema();
            DbInfoB.LoadSchema();
        }

        public void LoadData()
        {
            DbInfoA.LoadData();
            DbInfoB.LoadData();
        }

        /// <summary>
        /// Key = Table Name
        /// Tuple.Item1 = TableSchema from DbA (if exists)
        /// Tuple.Item2 = TableSchema from DbB (if exists)
        /// Tuple.Item3 = True if table schemas are equal, else false
        /// </summary>
        public Dictionary<string, Tuple<TableSchema, TableSchema, bool>> GetTableSchemaMatches()
        {
            Dictionary<string, Tuple<TableSchema, TableSchema, bool>> result = new Dictionary<string, Tuple<TableSchema, TableSchema, bool>>();
            foreach (var tbl in DbInfoA.Schema.Tables)
            {
                DbInfoB.Schema.Tables.TryGetValue(tbl.Key, out TableSchema b);
                bool areEqual = TableSchemaComparer.Equals(tbl.Value, b);
                result.Add(tbl.Key, new Tuple<TableSchema, TableSchema, bool>(tbl.Value, b, areEqual));
            }

            foreach (var tbl in DbInfoB.Schema.Tables)
            {
                if (result.ContainsKey(tbl.Key)) continue;
                result.Add(tbl.Key, new Tuple<TableSchema, TableSchema, bool>(null, tbl.Value, false));
            }

            return result;
        }
        #endregion

        #region Static Methods
        #region Compare TableNames
        public static List<TableSchema> GetTablesOnlyInA(Dictionary<string, Tuple<TableSchema, TableSchema>> matches)
        {
            List<TableSchema> result = new List<TableSchema>();
            foreach (var match in matches)
            {
                if (match.Value.Item1 != null && match.Value.Item2 == null)
                {
                    result.Add(match.Value.Item1);
                }
            }
            return result;
        }

        public static List<TableSchema> GetTablesOnlyInB(Dictionary<string, Tuple<TableSchema, TableSchema>> matches)
        {
            List<TableSchema> result = new List<TableSchema>();
            foreach (var match in matches)
            {
                if (match.Value.Item2 != null && match.Value.Item1 == null)
                {
                    result.Add(match.Value.Item2);
                }
            }
            return result;
        }

        /// <summary>
        /// Key = Table Name
        /// Tuple.Item1 = TableSchema from DbA
        /// Tuple.Item2 = TableSchema from DbB
        /// </summary>
        public static Dictionary<string, Tuple<TableSchema, TableSchema>> GetTablesInBoth(Dictionary<string, Tuple<TableSchema, TableSchema>> matches)
        {
            Dictionary<string, Tuple<TableSchema, TableSchema>> result = new Dictionary<string, Tuple<TableSchema, TableSchema>>();
            foreach (var match in matches)
            {
                if (match.Value.Item1 != null && match.Value.Item2 != null)
                {
                    result.Add(match.Key, match.Value);
                }
            }
            return result;
        }
        #endregion

        #region Compare Schemas
        public static bool IsDbSchemaIdentical(DbSchema x, DbSchema y)
        {
            return DbSchemaComparer.Equals(x, y);
        }

        /// <summary>
        /// Key = Table Name
        /// Tuple.Item1 = TableSchema from DbA
        /// Tuple.Item2 = TableSchema from DbB
        /// </summary>
        public static Dictionary<string, Tuple<TableSchema, TableSchema>> GetEqualTableSchemas(Dictionary<string, Tuple<TableSchema, TableSchema>> matches)
        {
            Dictionary<string, Tuple<TableSchema, TableSchema>> result = new Dictionary<string, Tuple<TableSchema, TableSchema>>();
            foreach (var match in matches)
            {
                if (TableSchemaComparer.Equals(match.Value.Item1, match.Value.Item2))
                {
                    result.Add(match.Key, match.Value);
                }
            }
            return result;
        }

        /// <summary>
        /// Key = Table Name
        /// Tuple.Item1 = TableSchema from DbA
        /// Tuple.Item2 = TableSchema from DbB
        /// </summary>
        public static Dictionary<string, Tuple<TableSchema, TableSchema>> GetUnequalTableSchemas(Dictionary<string, Tuple<TableSchema, TableSchema>> matches)
        {
            Dictionary<string, Tuple<TableSchema, TableSchema>> result = new Dictionary<string, Tuple<TableSchema, TableSchema>>();
            foreach (var match in matches)
            {
                if (!TableSchemaComparer.Equals(match.Value.Item1, match.Value.Item2))
                {
                    result.Add(match.Key, match.Value);
                }
            }
            return result;
        }
        #endregion
        
        #region Compare Indexes
        /// <summary>
        /// Key = Position Ordinal
        /// Tuple.Item1 = IndexSchema from DbA
        /// Tuple.Item2 = IndexSchema from DbB
        /// </summary>
        public static Dictionary<int, Tuple<IndexSchema, IndexSchema>> GetIndexSchemaMatches(string indexName, TableSchema tsA, TableSchema tsB)
        {
            Dictionary<int, Tuple<IndexSchema, IndexSchema>> result = new Dictionary<int, Tuple<IndexSchema, IndexSchema>>();
            //This code assumes the ordinal values will start with 1 and will be consecutive.
            List<IndexSchema> schemaListA = tsA.Indexes.Where(x => x.IndexName == indexName).ToList();
            List<IndexSchema> schemaListB = tsB.Indexes.Where(x => x.IndexName == indexName).ToList();
            int maxIndex = Math.Max(schemaListA.Count, schemaListB.Count) + 1;

            for (int i = 1; i < maxIndex; i++)
            {
                IndexSchema schemaA = schemaListA.FirstOrDefault(x => x.OrdinalPosition == i);
                IndexSchema schemaB = schemaListB.FirstOrDefault(x => x.OrdinalPosition == i);
                result.Add(i, new Tuple<IndexSchema, IndexSchema>(schemaA, schemaB));
            }
            return result;
        }
        #endregion
        #endregion
    }

}