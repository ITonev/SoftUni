using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_dispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            int cup = int.Parse(Console.ReadLine());
            int tofull = 0;
            int counter = 0;

            while (tofull<cup)
            {
                string command = Console.ReadLine();
                if (command == "Easy")
                    tofull = tofull+50;
                else if (command == "Medium")
                    tofull = tofull + 100;
                else if (command == "Hard")
                    tofull = tofull + 200;
                counter++;
            }
            if (tofull == cup) Console.WriteLine($"The dispenser has been tapped {counter} times.");
            else if (tofull > cup) Console.WriteLine($"{Math.Abs(cup-tofull)}ml has been spilled.");
        }
    }
}
