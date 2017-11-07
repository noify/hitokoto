using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 本地文件
{
    class FileModel
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public override string ToString()
        {
            return FileName;
        }
    }
}
