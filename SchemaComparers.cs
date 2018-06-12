using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCeComparer
{
    public class DbSchemaComparaer : IEqualityComparer<DbSchema>
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

    public class TableSchemaComparaer : IEqualityComparer<TableSchema>
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

    public class ColumnSchemaComparaer : IEqualityComparer<ColumnSchema>
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
}
