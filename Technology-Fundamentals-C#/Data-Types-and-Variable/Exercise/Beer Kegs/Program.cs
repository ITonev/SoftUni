using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beerKegs = int.Parse(Console.ReadLine());

            double highestKegVolume = 0d;
            var model = string.Empty;
            for (int i = 0; i < beerKegs; i++)
            {
                string currentModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                var currentKegVolume = Math.PI * (Math.Pow(radius,2)) * height;
                if (currentKegVolume>highestKegVolume)
                {
                    highestKegVolume = currentKegVolume;
                    model = currentModel;               
                }
            }
            Console.WriteLine(model);
        }
    }
}
