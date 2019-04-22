using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewing_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double wight = double.Parse(Console.ReadLine());
            double cover = tables * (lenght + 2 * 0.30) * (wight + 2 * 0.30);
            double cover2 = tables * (lenght / 2) * (lenght / 2);
            double amountUSD = cover * 7 + cover2 * 9;
            Console.WriteLine("{0:F2} USD", amountUSD);
            double amountBGN = amountUSD * 1.85;
            Console.WriteLine($"{amountBGN:f2}");


        }
    }
}
