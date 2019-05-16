using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int capacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int currentCapacity = 0;
            int lenght = clothes.Count;

            for (int i = 0; i < lenght; i++)
            {
                var currentCloth = clothes.Pop();

                if (currentCapacity+currentCloth<capacity)
                {
                    currentCapacity += currentCloth;
                }

                else if (currentCapacity+currentCloth==capacity)
                {
                    racks++;
                    currentCapacity = 0;
                }

                else if (currentCapacity + currentCloth > capacity)
                {
                    racks++;
                    currentCapacity = currentCloth;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
