using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictionary = new Dictionary<string, List<string>>();

            var wordAndDefinitionPair = input.Split(" | ").ToList();

            for (int i = 0; i < wordAndDefinitionPair.Count; i++)
            {
                var currentpair = wordAndDefinitionPair[i].Split(": ");
                var word = currentpair[0];
                var definition = currentpair[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>();
                }

                dictionary[word].Add(definition);
            }

            var wordsToprint = Console.ReadLine().Split(" | ");

            foreach (var word in wordsToprint)
            {
                if (dictionary.ContainsKey(word))
                {
                    var DefList = dictionary[word].OrderByDescending(x=>x.Count()).ToList();

                    Console.WriteLine($"{word}");

                    foreach (var definition in DefList)
                    {
                        Console.WriteLine($"-{definition}");
                    }
                }
            }

            var command = Console.ReadLine();

            if (command=="List")
            {
                Console.WriteLine(string.Join(" ", dictionary.Keys.OrderBy(x=>x)));
            }
        }
    }
}
