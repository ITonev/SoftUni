using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int m = 1; m <= 9; m++)
                        {
                            if (N % i == 0 && N % j == 0 && N % k == 0 && N % m == 0)
                            {
                                Console.Write($"{i}{j}{k}{m} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
