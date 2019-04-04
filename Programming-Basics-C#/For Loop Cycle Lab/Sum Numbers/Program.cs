using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int d = 0;
            for (int i = 1; i <= n; i++)
            {
                int c = int.Parse(Console.ReadLine());
                d += c;
                
            }
            Console.WriteLine(d);
        }
    }
}
