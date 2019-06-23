using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var physicalItemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> items = new Stack<int>(physicalItemsInput);

            int glass = 0;
            int aluminium = 0;
            int lithium = 0;
            int carbonFiber = 0;

            while (liquids.Count > 0 && items.Count > 0)
            {
                var liquid = liquids.Dequeue();
                var item = items.Pop();

                var result = liquid + item;

                if (result==25)
                {
                    glass++;
                }

                else if (result==50)
                {
                    aluminium++;
                }

                else if (result==75)
                {
                    lithium++;
                }

                else if (result==100)
                {
                    carbonFiber++;
                }

                else
                {
                    item += 3;
                    items.Push(item);
                }

            }

            if (aluminium>0 
                && lithium>0
                && glass>0
                && carbonFiber>0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count>0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Count>0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {aluminium}");
            Console.WriteLine($"Carbon fiber: {carbonFiber}");
            Console.WriteLine($"Glass: {glass}");
            Console.WriteLine($"Lithium: {lithium}");
        }
    }
}
