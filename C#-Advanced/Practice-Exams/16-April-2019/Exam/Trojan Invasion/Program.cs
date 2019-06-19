using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    public class Program
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());

            List<int> spartanDefenses = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> trojanAttacks = new Stack<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray());

                if (i % 3 == 0)
                {
                    var def = int.Parse(Console.ReadLine());
                    spartanDefenses.Add(def);
                }

                while (spartanDefenses.Count > 0 && trojanAttacks.Count > 0)
                {
                    var attack = trojanAttacks.Pop();
                    var defense = spartanDefenses[0];

                    if (attack > defense)
                    {
                        attack -= defense;
                        trojanAttacks.Push(attack);

                        spartanDefenses.RemoveAt(0);
                    }

                    else if (attack < defense)
                    {
                        spartanDefenses[0] =  defense - attack;
                    }

                    else if (attack == defense)
                    {
                        spartanDefenses.RemoveAt(0);
                    }
                }

                if (spartanDefenses.Count == 0)
                {
                    Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                    Console.Write("Warriors left: ");
                    Console.WriteLine(string.Join(", ", trojanAttacks));
                    break;
                }
            }

            if (spartanDefenses.Count > 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", spartanDefenses));
            }
        }
    }
}
