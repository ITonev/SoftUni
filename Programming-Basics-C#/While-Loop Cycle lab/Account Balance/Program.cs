using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double counter = 1;
            double totalamount = 0;

            while (counter<=n)
            {
                
                double increase = double.Parse(Console.ReadLine());
                                
                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!"); break;
                }
                Console.WriteLine($"Increase: {increase:F2}");
                totalamount += increase;
                counter++;
            }
            Console.WriteLine($"Total: {totalamount:F2}");
        }
    }
}
