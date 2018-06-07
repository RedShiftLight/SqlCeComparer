using System;
using System.Collections.Generic;

namespace SqlCeComparer
{
    public enum FileIndicator
    {
        FileA,
        FileB
    }

    public class SqlCeCompareUtil
    {

        private string _fileA;
        private string _fileB;

        public SqlCeCompareUtil(string fileA, string fileB)
        {
            _fileA = fileA;
            _fileB = fileB;
        }

        public List<string> TableNames { get; private set; }

        public void GetTableList(FileIndicator whichFile)
        {
            string query = "select table_name from information_schema.tables where TABLE_TYPE <> 'VIEW'";
        }
    }
}