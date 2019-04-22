    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Birthday
    {
        class Program
        {
            static void Main(string[] args)
            {
                int length = int.Parse(Console.ReadLine());
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double percent = double.Parse(Console.ReadLine());

                int volume = length * width * height;
                double liters = volume * 0.001;
                percent = percent * 0.01;
                liters = liters * (1 - percent);
                Console.WriteLine($"{liters:F3}");

            }
        }
    }
