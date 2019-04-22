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
            int roomcubics = width * lenght * height;
            int boxcubics = 0;


            while (boxcubics < roomcubics)
            {
                string boxes = Console.ReadLine();
                if (boxes == "Done") break;

                int totalboxes = int.Parse(boxes);
                boxcubics += totalboxes;
            }
            if (roomcubics> boxcubics) Console.WriteLine($"{roomcubics-boxcubics} Cubic meters left.");
            else Console.WriteLine($"No more free space! You need {boxcubics - roomcubics} Cubic meters more.");

        }
    }
}
