using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
           string s1 = "ersdf";
            string s2 = s1.Substring(s1.Length-2);
            Console.WriteLine(s1);
            Console.ReadKey();
        }
    }
}
