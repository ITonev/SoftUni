using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row <n; row++)
            {
                for (int column = 0; column <n; column++)
                {
                    int num = row + column + 1;

                    if (num<=n) Console.Write(num+ " ");
                    if (num > n) Console.Write(2*n-num+ " "); 
                }
                Console.WriteLine();
            }
        }
    }
}
