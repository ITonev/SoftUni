using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int totalslices = width * height;
            int slices = 0;

            while (totalslices >= 0)
            {
                string command = Console.ReadLine();
                if (command == "STOP") { Console.WriteLine($"{totalslices} pieces are left."); break; }

                slices = int.Parse(command);
                totalslices -= slices;
                
            }            
            if (totalslices < 0)
            {
                
                Console.WriteLine($"No more cake left! You need {Math.Abs(totalslices)} pieces more.");
            }    
        }
    }
}
