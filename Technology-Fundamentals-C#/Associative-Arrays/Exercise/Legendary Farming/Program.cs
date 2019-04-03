using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {

            var legendary = new Dictionary<string, int>();
            legendary["shards"] = 0;
            legendary["fragments"] = 0;
            legendary["motes"] = 0;
            var junk = new Dictionary<string, int>();

            bool foundIt = false;
            while (true)
            {
                var input = Console.ReadLine().ToLower().Split();

                for (int i = 1; i <= input.Length; i += 2)
                {
                    var material = input[i];
                    var quantity = int.Parse(input[i - 1]);
                    
                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendary[material] += quantity;

                        if (legendary["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            legendary["shards"] -= 250;
                            foundIt = true;
                            break;
                        }

                        else if (legendary["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            legendary["fragments"] -= 250;
                            foundIt = true;
                            break;
                        }

                        else if (legendary["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            legendary["motes"] -= 250;
                            foundIt = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }
                        junk[material] += quantity;
                    }
                }

                if (foundIt)
                {
                    break;
                }
            }

            foreach (var kvp in legendary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junk.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
