using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split('|').Reverse().ToArray();
            var resultList = new List<string>();
            
            for (int i = 0; i < list.Length; i++)
            {
                var numbers = list[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in numbers)
                {
                    resultList.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
