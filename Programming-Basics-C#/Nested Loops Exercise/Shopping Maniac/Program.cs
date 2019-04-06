using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Maniac
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = int.Parse(Console.ReadLine());
            int totalSpent = 0;
            int price = 0;
            int boughtCloths = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "enough")
                {
                    break;
                }

                if (command == "enter")
                {
                    while (true)
                    {
                        string command2 = Console.ReadLine();

                        if (command2 == "leave")
                        {
                            break;
                        }

                        else
                        {
                            price = int.Parse(command2);
                            totalSpent += price;
                            boughtCloths++;
                        }
                        if (totalSpent > money)
                        {
                            Console.WriteLine("Not enough money.");
                            totalSpent -= price;
                            boughtCloths = boughtCloths - 1;
                        }
                        if (totalSpent == money) break;
                    }
                }
                if (totalSpent == money) break;

            }
            Console.WriteLine($"For {boughtCloths} clothes I spent {totalSpent} lv and have {money-totalSpent} lv left.");

        }
    }
}
