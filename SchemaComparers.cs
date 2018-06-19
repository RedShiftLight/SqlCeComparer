using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCeComparer
{
    public class DbSchemaComparer : IEqualityComparer<DbSchema>
    {
        public bool Equals(DbSchema x, DbSchema y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return x.HashString == y.HashString;
            return false;
        }

        public int GetHashCode(DbSchema obj)
        {
            if (obj != null) return obj.HashString.GetHashCode();
            return 0;
        }
    }

    public class TableSchemaComparer : IEqualityComparer<TableSchema>
    {
        public bool Equals(TableSchema x, TableSchema y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return x.HashString == y.HashString;
            return false;
        }

        public int GetHashCode(TableSchema obj)
        {
            if (obj != null) return obj.HashString.GetHashCode();
            return 0;
        }
    }

    public class ColumnSchemaComparer : IEqualityComparer<ColumnSchema>
    {
        public bool Equals(ColumnSchema x, ColumnSchema y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return x.HashString == y.HashString;
            return false;
        }

        public int GetHashCode(ColumnSchema obj)
        {
            if (obj != null) return obj.HashString.GetHashCode();
            return 0;
        }
    }
    
    public class IndexSchemaComparer : IEqualityComparer<IndexSchema>
    {
        public bool Equals(IndexSchema x, IndexSchema y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return x.HashString == y.HashString;
            return false;
        }

        public int GetHashCode(IndexSchema obj)
        {
            if (obj != null) return obj.HashString.GetHashCode();
            return 0;
        }
    }

    public class DataComparer : IEqualityComparer<DataTable>
    {
        public bool Equals(DataTable x, DataTable y)
        {
            if (x == null && y == null) return true;
            if (x != null && y != null) return CompareTableData(x, y);
            return false;
        }

        public int GetHashCode(DataTable obj)
        {
            return obj.GetHashCode();
        }

        private bool CompareTableData(DataTable x, DataTable y)
        {
            if (x.Rows.Count != y.Rows.Count) return false;

            //TODO: implement something to compare all the rows in the tables
            return true;
        }
    }
}
