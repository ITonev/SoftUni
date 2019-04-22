using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int roomVolume = width*lenght*height;
            int boxesVolume = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command=="Done")
                {
                    Console.WriteLine($"{roomVolume - boxesVolume} Cubic meters left.");
                    break;
                }

                int boxes = int.Parse(command);
                boxesVolume += boxes;
                
                if (boxesVolume>roomVolume)
                {
                    Console.WriteLine($"No more free space! You need {boxesVolume-roomVolume} Cubic meters more.");break;
                }

            }
            
        }
    }
}
