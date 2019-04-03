using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var forceUsers = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                var tokens = input.
                    Split(new[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);


                if (input.Contains("|"))
                {
                    var forceSide = tokens[0];
                    var user = tokens[1];

                    if (!forceUsers.ContainsKey(forceSide))
                    {
                        forceUsers[forceSide] = new List<string>();
                    }

                    if (!forceUsers.Values.Any(x => x.Contains(user)))
                    {
                        forceUsers[forceSide].Add(user);
                    }
                }

                else if (input.Contains("->"))
                {
                    var user = tokens[0];
                    var forceSide = tokens[1];

                    if (!forceUsers.ContainsKey(forceSide))
                    {
                        forceUsers[forceSide] = new List<string>();
                    }

                    bool forceUserPresent = CheckIfUserExists(forceUsers, user);

                    forceUsers[forceSide].Add(user);
                    Console.WriteLine($"{user} joins the {forceSide} side!");
                }
            }

            var newForce = forceUsers.Where(x => x.Value.Count > 0);

            foreach (var kvp in newForce.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                var users = kvp.Value.OrderBy(x => x).ToList();
                Console.WriteLine($"Side: {kvp.Key}, Members: {users.Count}");
                Console.WriteLine($"! {string.Join("\n! ", users)}");
            }
        }

        private static bool CheckIfUserExists(Dictionary<string, List<string>> forceUsers, string user)
        {
            foreach (var kvp in forceUsers)
            {
                var users = kvp.Value;

                if (users.Contains(user))
                {
                    forceUsers[kvp.Key].Remove(user);
                    return true;
                }
            }

            return false;
        }
    }
}
