using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenir = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            double flagsPrice = 0.0;
            double capsPrice = 0.0;
            double postersPrice = 0.0;
            double stickersPrice = 0.0;
            double totalSpent = 0.0;

            switch (team)
            {
                case "Argentina": flagsPrice = 3.25; capsPrice = 7.20; postersPrice = 5.10; stickersPrice = 1.25;break;
                case "Brazil": flagsPrice = 4.20; capsPrice = 8.50; postersPrice = 5.35; stickersPrice = 1.20;break;
                case "Croatia": flagsPrice = 2.75; capsPrice = 6.90; postersPrice = 4.95; stickersPrice = 1.10;break;
                case "Denmark": flagsPrice = 3.10; capsPrice = 6.50; postersPrice = 4.80; stickersPrice = 0.90;break;
                default:
                    break;
            }

            if (souvenir=="flags") totalSpent = flagsPrice * number;
            else if (souvenir=="caps") totalSpent = capsPrice * number;
            else if (souvenir=="stickers") totalSpent = stickersPrice * number;
            else if (souvenir=="posters") totalSpent = postersPrice * number;


            if (!(team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark"))
            {
                Console.WriteLine("Invalid country!");
            }
            
            if (!(souvenir == "flags" || souvenir == "caps" || souvenir == "posters" || souvenir == "stickers"))
            {
                Console.WriteLine("Invalid stock!");
            }

            if ((team == "Argentina" || team == "Brazil" || team == "Croatia" || team == "Denmark") && (souvenir == "flags" || souvenir == "caps" || souvenir == "posters" || souvenir == "stickers"))
            {
                Console.WriteLine($"Pepi bought {number} {souvenir} of {team} for {totalSpent:F2} lv.");
            }

        }
    }
}
