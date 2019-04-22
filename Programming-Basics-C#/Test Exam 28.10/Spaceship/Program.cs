using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double spaceshipWidth = double.Parse(Console.ReadLine());
            double spaceshiplenght = double.Parse(Console.ReadLine());
            double spaceshipheight = double.Parse(Console.ReadLine());
            double austronatsHeight = double.Parse(Console.ReadLine());

            double spaceshipVolume = spaceshipheight * spaceshiplenght * spaceshipWidth;
            double roomVolume = 2 * 2 * (austronatsHeight + 0.40);

            double spaceFor = Math.Floor(spaceshipVolume / roomVolume);

            if (spaceFor<3)  Console.WriteLine("The spacecraft is too small.");
            else if (spaceFor > 10) Console.WriteLine("The spacecraft is too big.");
            else Console.WriteLine($"The spacecraft holds {spaceFor} astronauts.");
        }
    }
}
