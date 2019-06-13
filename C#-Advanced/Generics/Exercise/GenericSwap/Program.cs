using System;
using System.Collections.Generic;

namespace GenericSwap
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<int>(int.Parse(Console.ReadLine()));

                boxes.Add(box);
            }

            var swapCommand = Console.ReadLine();

            ToSwap(boxes, swapCommand);

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }


        }

        private static void ToSwap<T>(List<Box<T>> boxes, string swapCommand)
        {
            var tokens = swapCommand.Split();

            var first = int.Parse(tokens[0]);
            var second = int.Parse(tokens[1]);

            if (first >= 0 && first < boxes.Count
                && second >= 0 && second < boxes.Count)
            {
                var firstBox = boxes[first];
                var secondBox = boxes[second];

                boxes[first] = secondBox;
                boxes[second] = firstBox;
            }
        }
    }
}
