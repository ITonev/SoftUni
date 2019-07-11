using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfBuyers = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfBuyers; i++)
            {
                var tokens = Console.ReadLine().Split();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                if (tokens.Length==3)
                {
                    Rebel rebel = new Rebel(name, age, tokens[2]);
                    buyers.Add(rebel);
                }

                else
                {
                    Citizen citizen = new Citizen(name, age, tokens[2], tokens[3]);

                    buyers.Add(citizen);
                }
            }

            var input = Console.ReadLine();

            while (input!="End")
            {
                
                var currentBuyer = buyers.FirstOrDefault(x=>x.Name==input);

                if (currentBuyer!=null)
                {
                    currentBuyer.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(buyers.Select(x=>x.Food).Sum());
        }
    }
}
