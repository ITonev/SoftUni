using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; } = new Item();
            public int ItemQuality { get; set; }
            public double BoxPrice { get; set; }

        }

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (command != "end")
            {
                var tokens = command.Split();
                Box box = new Box();
                box.SerialNumber = tokens[0];
                box.Item.Name = tokens[1];
                box.Item.Price = double.Parse(tokens[3]);
                box.ItemQuality = int.Parse(tokens[2]);
                box.BoxPrice = int.Parse(tokens[2]) * double.Parse(tokens[3]);

                boxes.Add(box);

                command = Console.ReadLine();
            }

            foreach (var box in boxes.OrderByDescending(x=>x.BoxPrice))
            {
                Console.WriteLine($"{box.SerialNumber}\n-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuality}\n-- ${box.BoxPrice:f2}");
            }
        }

    }
}

