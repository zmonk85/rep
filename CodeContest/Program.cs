using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContest
{
    internal class Program
    {   
        private static void Main(string[] args)
        {   
            SmartShopper bs = new SmartShopper(Console.In, Console.Out);
            bs.GetResult();

            Console.ReadLine();                
        }
    }
}
