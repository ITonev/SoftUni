using System;
using System.Collections.Generic;

namespace GenericCount
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var boxes = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var box = double.Parse(Console.ReadLine());
                boxes.Add(box);
                
            }

            var elementToCompare = double.Parse(Console.ReadLine());

            int counter = boxes.CompareTo(elementToCompare);

            Console.WriteLine(counter);
        }
    }
}
