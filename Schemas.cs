using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCeComparer
{
    public class DbSchema : IComparable<DbSchema>
    {
        /// <summary>
        /// Key = Table Name
        /// </summary>
        public Dictionary<string, TableSchema> Tables { get; set; }
        internal string HashString
        {
            get
            {
                List<int> vals = new List<int>();
                Tables.Values.OrderBy(x=> x.TableName).ToList().ForEach(x => vals.Add(x.GetHashCode()));
                return $"{string.Join("|", vals)}".ToLower();
            }
        }
        public DbSchema()
        {
            Tables = new Dictionary<string, TableSchema>();
        }

        public int CompareTo(DbSchema obj)
        {
            if (obj == null) return 1;
            else
            {
                return HashString.CompareTo(obj.HashString);
            }
        }

        public override bool Equals(object obj)
        {
            DbSchema x = obj as DbSchema;
            if (x == null) return false;
            return CompareTo(x) == 0;
        }

        public override int GetHashCode()
        {
            return HashString.GetHashCode();
        }
    }

    public class TableSchema : IComparable<TableSchema>
    {
        public string TableName { get; set; }
        public List<ColumnSchema> Columns { get; set; }
        public List<IndexSchema> Indexes { get; set; }
        internal string HashString
        {
            get
            {
                List<int> vals = new List<int>();
                Columns.OrderBy(x=> x.ColumnName).ToList().ForEach(x => vals.Add(x.GetHashCode()));
                vals.Add(0); //Need a seperator between columns and indexes
                Indexes.OrderBy(x => x.IndexName).ThenBy(x => x.OrdinalPosition).ToList().ForEach(x => vals.Add(x.GetHashCode()));
                return $"{TableName}|{string.Join("|",vals)}".ToLower();
            }
        }

        public TableSchema(string tableName)
        {
            TableName = tableName;
            Columns = new List<ColumnSchema>();
            Indexes = new List<IndexSchema>();
        }

        public int CompareTo(TableSchema obj)
        {
            if (obj == null) return 1;
            else
            {
                return HashString.CompareTo(obj.HashString);
            }
        }

        public override bool Equals(object obj)
        {
            TableSchema x = obj as TableSchema;
            if (x == null) return false;
            return CompareTo(x) == 0;
        }

        public override int GetHashCode()
        {
            return HashString.GetHashCode();
        }
    }

    public class ColumnSchema : IComparable<ColumnSchema>
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int OrdinalPosition { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public int MaxLength { get; set; }
        internal string HashString { get { return $"{TableName}|{ColumnName}|{OrdinalPosition}|{DataType}|{IsNullable}|{MaxLength}".ToLower(); } }

        public int CompareTo(ColumnSchema obj)
        {
            if (obj == null) return 1;
            else
            {
                return HashString.CompareTo(obj.HashString);
            }
        }

        public override bool Equals(object obj)
        {
            ColumnSchema x = obj as ColumnSchema;
            if (x == null) return false;
            return CompareTo(x) == 0;
        }

        public override int GetHashCode()
        {
            return HashString.GetHashCode();
        }
    }

    public class IndexSchema : IComparable<IndexSchema>
    {
        public string TableName { get; set; }
        public string IndexName { get; set; }
        public int OrdinalPosition { get; set; }
        public string ColumnName { get; set; }
        public string SortDirection { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsUnique { get; set; }
        public bool IsClustered { get; set; }
        public string Attributes
        {
            get
            {
                string type = IsPrimaryKey ? "PK" : "IDX";
                string unique = IsUnique ? "Unique" : "";
                string clustered = IsClustered ? "Clustered" : "";
                return $"{type} {unique} {clustered} {SortDirection}";
            }
        }
        internal string HashString { get { return $"{TableName}|{IndexName}|{OrdinalPosition}|{ColumnName}|{SortDirection}|{IsPrimaryKey}|{IsUnique}|{IsClustered}".ToLower(); } }

        public int CompareTo(IndexSchema obj)
        {
            if (obj == null) return 1;
            else
            {
                return HashString.CompareTo(obj.HashString);
            }
        }

        public override bool Equals(object obj)
        {
            IndexSchema x = obj as IndexSchema;
            if (x == null) return false;
            return CompareTo(x) == 0;
        }

        public override int GetHashCode()
        {
            return HashString.GetHashCode();
        }
    }
}
