using System;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var distances = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sumOfRemovedElements = 0;
            while (distances.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedElement = 0;

                if (index < 0)
                {
                    removedElement = distances[0];
                    sumOfRemovedElements += removedElement;
                    distances[0] = distances[distances.Count - 1];
                }
                else if (index >= distances.Count)
                {
                    removedElement = distances[distances.Count - 1];
                    sumOfRemovedElements += removedElement;
                    distances[distances.Count - 1] = distances[0];
                }
                else
                {
                    removedElement = distances[index];
                    sumOfRemovedElements += removedElement;
                    distances.RemoveAt(index);
                }

                for (int i = 0; i < distances.Count; i++)
                {
                    if (removedElement >= distances[i])
                    {
                        distances[i] += removedElement;
                    }
                    else if (removedElement < distances[i])
                    {
                        distances[i] -= removedElement;
                    }
                }
            }

            Console.WriteLine(sumOfRemovedElements);
        }
    }
}
