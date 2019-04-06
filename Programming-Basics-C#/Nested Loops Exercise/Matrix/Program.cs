using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());   
            int b = int.Parse(Console.ReadLine());   
            int c = int.Parse(Console.ReadLine());   
            int d = int.Parse(Console.ReadLine());   

            for (int i = a; i <=b; i++)
            {
                for (int j = a; j <=b; j++)
                {
                    for (int k = c; k <=d; k++)
                    {
                        for (int m = c; m <= d; m++)
                        {
                            if (i != j && k != m && i + m == j + k)
                            {
                                Console.WriteLine($"{i}{j}");
                                Console.WriteLine($"{k}{m}");
                                Console.WriteLine();
                            }
                        }
                    }
                }               

            }           

        }
    }
}
