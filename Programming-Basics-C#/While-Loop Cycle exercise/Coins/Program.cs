using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double lev = Math.Floor(change);
            double coins = (change - lev) * 100;
            double counter = 0;

            while (lev > 0)
            {
                if (lev >= 2)
                {
                    counter++;
                    lev -= 2;
                }
                if (lev == 1)
                {
                    counter++;
                    lev -= 1;
                    break;
                }

            }
            while (coins > 0)
            {
                if (coins >= 50) { counter++; coins -= 50; }
                else if (coins >= 20) { counter++; coins -= 20; }
                else if (coins >= 10) { counter++; coins -= 10; }
                else if (coins >= 5) { counter++; coins -= 5; }
                else if (coins >= 2) { counter++; coins -= 2; }
                else if (coins >= 1) { counter++; coins -= 1; break; }
                else break;
            }
            Console.WriteLine(counter);

        }
    }
}
