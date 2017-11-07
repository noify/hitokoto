using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KILL
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] pros = Process.GetProcesses();
            foreach(var item in pros)
            {
                item.Kill();
            }
        }
    }
}
