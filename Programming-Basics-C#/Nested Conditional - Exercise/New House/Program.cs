using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {

            string flower = Console.ReadLine();
            int floweramout = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double rosesprice = 5.00;
            double dahliasprice = 3.80;
            double tulipsprice = 2.80;
            double narcissusprice = 3.00;
            double gladiousprice = 2.50;
            double finalprice = 0;

            if (flower=="Roses")
            {
                if (floweramout > 80) finalprice = (floweramout * rosesprice) * 0.90;
                else finalprice = floweramout * rosesprice;
            }
            else if (flower == "Dahlias")
            {
                if (floweramout > 90) finalprice = (floweramout * dahliasprice) * 0.85;
                else finalprice = floweramout * dahliasprice;
            }
            else if (flower == "Tulips")
            {
                if (floweramout > 80) finalprice = (floweramout * tulipsprice) * 0.85;
                else finalprice = floweramout * tulipsprice;
            }
            else if (flower == "Narcissus")
            {
                if (floweramout <120) finalprice = (floweramout * narcissusprice)*1.15;
                else finalprice = floweramout * narcissusprice;
            }
            else if (flower == "Gladiolus")
            {
                if (floweramout < 80) finalprice = (floweramout * gladiousprice) * 1.20;
                else finalprice = floweramout * gladiousprice;
            }


            if (budget>=finalprice)
            {
                Console.WriteLine($"Hey, you have a great garden with {floweramout} {flower} and {(budget-finalprice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(finalprice-budget):F2} leva more.");
            }
        }
    }
}
