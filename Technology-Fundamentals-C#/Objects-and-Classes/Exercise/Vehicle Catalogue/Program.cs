using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Catalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> catalogue = new List<Catalogue>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var tokens = command.Split();
                Catalogue newInput = new Catalogue
                {
                    Type = tokens[0].First().ToString().ToUpper() + tokens[0].Substring(1).ToLower(),
                    Model = tokens[1],
                    Color = tokens[2],
                    Horsepower = int.Parse(tokens[3])
                };

                catalogue.Add(newInput);
            }

            string model = Console.ReadLine();

            while (model != "Close the Catalogue")
            {

                foreach (var item in catalogue.Where(x => x.Model == model))
                {
                    Console.WriteLine($"Type: {item.Type}\n" +
                                     $"Model: {item.Model}\n" +
                                     $"Color: {item.Color}\n" +
                                     $"Horsepower: {item.Horsepower}");
                }


                model = Console.ReadLine();
            }

            if (catalogue.Where(x => x.Type == "Car").Count() > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {catalogue.Where(x => x.Type == "Car").Select(x => x.Horsepower).Average():F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (catalogue.Where(x => x.Type == "Truck").Count() > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {catalogue.Where(x => x.Type == "Truck").Select(x => x.Horsepower).Average():F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }

        }
    }
}
