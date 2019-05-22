using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            var entry = Console.ReadLine();

            while (entry != "PARTY")
            {
                if (char.IsDigit(entry[0]))
                {
                    VIP.Add(entry);
                }

                else
                {
                    regular.Add(entry);
                }

                entry = Console.ReadLine();
            }

            entry = Console.ReadLine();

            while (entry!="END")
            {
                VIP.Remove(entry);
                regular.Remove(entry);

                entry = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count+regular.Count);

            foreach (var person in VIP)
            {
                Console.WriteLine(person);
            }

            foreach (var person in regular)
            {
                Console.WriteLine(person);
            }
        }
    }
}
