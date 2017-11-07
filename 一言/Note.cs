using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 一言
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int No { get; set; }
        public string id { get; set; }
        public string hitokoto { get; set; }
        public string cat { get; set; }
        public string catname { get; set; }
        public string author { get; set; }
        public string source { get; set; }
        public string like { get; set; }
        public string date { get; set; }
    }
}
