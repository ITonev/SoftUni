using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            string delivery = Console.ReadLine();

            double sashimiPrice = 0.0;
            double makiPrice = 0.0;
            double uramakiPrice = 0.0;
            double temakiPrice = 0.0;
            double totalPrice = 0.0;

            if (!(restaurant == "Sushi Zone" || restaurant == "Sushi Time" || restaurant == "Sushi Bar" || restaurant == "Asian Pub"))
                Console.WriteLine($"{restaurant} is invalid restaurant!");

            switch (restaurant)
            {
                case "Sushi Zone": sashimiPrice = 4.99; makiPrice = 5.29; uramakiPrice = 5.99; temakiPrice = 4.29; break;
                case "Sushi Time": sashimiPrice = 5.49; makiPrice = 4.69; uramakiPrice = 4.49; temakiPrice = 5.19; break;
                case "Sushi Bar": sashimiPrice = 5.25; makiPrice = 5.55; uramakiPrice = 6.25; temakiPrice = 4.75; break;
                case "Asian Pub": sashimiPrice = 4.50; makiPrice = 4.80; uramakiPrice = 5.50; temakiPrice = 5.50; break;
                default:
                    break;
            }

            if (sushi == "sashimi") totalPrice = sashimiPrice * portions;
            else if (sushi == "maki") totalPrice = makiPrice * portions;
            else if (sushi == "uramaki") totalPrice = uramakiPrice * portions;
            else if (sushi == "temaki") totalPrice = temakiPrice * portions;

            if (delivery == "Y") totalPrice = totalPrice + (totalPrice * 0.20);

            if (restaurant == "Sushi Zone" || restaurant == "Sushi Time" || restaurant == "Sushi Bar" || restaurant == "Asian Pub")
                Console.WriteLine($"Total price: {Math.Ceiling(totalPrice)} lv.");
        }
    }
}
