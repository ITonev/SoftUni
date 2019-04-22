using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double totalcakes = cakes * 45;
            double totalwaffles = waffles * 5.80;
            double totalpancakes = pancakes * 3.20;
            double totalamount1day = (totalcakes + totalpancakes + totalwaffles) * bakers;
            double totalcampamount = totalamount1day * days;
            double total = totalcampamount - (totalcampamount / 8);
            Console.WriteLine("{0:F2}", total);

        }
    }
}
