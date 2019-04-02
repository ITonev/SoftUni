using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            int shortestList = Math.Min(firstList.Count, secondList.Count);
            int longestList = Math.Max(firstList.Count, secondList.Count);

            List<int> resultList = new List<int>();

            for (int i = 0; i < shortestList; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            for (int i = shortestList; i < longestList; i++)
            {
                if (firstList.Count > shortestList)
                {
                    resultList.Add(firstList[i]);
                }

                else if (secondList.Count > shortestList)
                {
                    resultList.Add(secondList[i]);
                }


            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
