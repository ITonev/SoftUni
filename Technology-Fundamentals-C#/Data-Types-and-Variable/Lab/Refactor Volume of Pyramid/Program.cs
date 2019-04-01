using System;

namespace Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Length: ");
            double lenght = double.Parse(Console.ReadLine());
            Console.WriteLine("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (lenght * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {volume:f2}");

        }
    }
}
