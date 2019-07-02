using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long currency = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string currentType = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string type = string.Empty;

                if (currentType.Length == 3)
                {
                    type = "Cash";
                }

                else if (currentType.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }

                else if (currentType.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == string.Empty)
                {
                    continue;
                }

                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":

                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }

                        else if (bag[type].Values.Sum() + amount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }

                        break;

                    case "Cash":

                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }

                            else
                            {
                                continue;
                            }
                        }

                        else if (bag[type].Values.Sum() + amount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                }

                if (!bag.ContainsKey(type))
                {
                    bag[type] = new Dictionary<string, long>();
                }

                if (!bag[type].ContainsKey(currentType))
                {
                    bag[type][currentType] = 0;
                }

                bag[type][currentType] += amount;

                if (type == "Gold")
                {
                    gold += amount;
                }

                else if (type == "Gem")
                {
                    gems += amount;
                }

                else if (type == "Cash")
                {
                    currency += amount;
                }
            }

            foreach (var type in bag)
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");

                foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}