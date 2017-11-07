using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class Program
    {
        static void Main(string[] args)
        {
            CangKu a = new CangKu();
            a.Jinpros("Nokia", 10);
            a.Jinpros("Tencent", 10);
            a.Jinpros("SamSung", 10);
            a.Jinpros("Apple", 10);
            a.Showpros();
            Console.ReadKey();
        }
    }
}
