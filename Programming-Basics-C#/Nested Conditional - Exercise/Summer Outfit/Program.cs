using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            string timeofday = Console.ReadLine();

            if (degrees>=10 && degrees<=18)
            {
                switch (timeofday)
                {
                    case "Morning": Console.WriteLine($"It's {degrees} degrees, get your Sweatshirt and Sneakers.");break;
                    case "Afternoon": Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");break;
                    case "Evening": Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins.");break;
                    default:
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (timeofday)
                {
                    case "Morning": Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins."); break;
                    case "Afternoon": Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals."); break;
                    case "Evening": Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins."); break;
                    default:
                        break;
                }
            }
            else if (degrees >= 25)
            {
                switch (timeofday)
                {
                    case "Morning": Console.WriteLine($"It's {degrees} degrees, get your T-Shirt and Sandals."); break;
                    case "Afternoon": Console.WriteLine($"It's {degrees} degrees, get your Swim Suit and Barefoot."); break;
                    case "Evening": Console.WriteLine($"It's {degrees} degrees, get your Shirt and Moccasins."); break;
                    default:
                        break;
                }
            }

        }
    }
}
