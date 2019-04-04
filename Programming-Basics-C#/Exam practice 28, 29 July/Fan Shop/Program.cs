using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int quantity = int.Parse(Console.ReadLine());
            int moneySpent = 0;          

            for (int i = 1; i <=quantity; i++)
            {
                string article = Console.ReadLine();

                switch (article)
                {
                    case "hoodie": moneySpent += 30;break;
                    case "keychain": moneySpent += 4;break;
                    case "T-shirt": moneySpent += 20;break;
                    case "flag": moneySpent += 15;break;
                    case "sticker": moneySpent += 1;break;
                }
            }
            if (moneySpent<=budget) Console.WriteLine($"You bought {quantity} items and left with {budget-moneySpent} lv.");
            else Console.WriteLine($"Not enough money, you need {moneySpent-budget} more lv.");
        }
    }
}
