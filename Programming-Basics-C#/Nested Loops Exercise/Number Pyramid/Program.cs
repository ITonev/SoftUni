using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;
            int currentNum = 1;

            while (currentNum <= n)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.Write(currentNum+" ");
                    currentNum++;
                    if (currentNum > n) break;
                    
                }
                counter++;
                Console.WriteLine();
            }
        }
    }
}
