using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "end of contests")
            {
                var contest = input[0];
                var password = input[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end of submissions")
            {
                var contest = input[0];
                var password = input[1];
                var user = input[2];
                var points = int.Parse(input[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(user))
                    {
                        users[user] = new Dictionary<string, int>();
                    }

                    if (!users[user].ContainsKey(contest))
                    {
                        users[user].Add(contest, points);
                    }

                    else if (users[user][contest] < points)
                    {
                        users[user][contest] = points;
                    }
                }

                input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            var userWithTopScore = string.Empty;
            int sum = 0;

            foreach (var user in users)
            {
                if (sum < user.Value.Values.Sum())
                {
                    userWithTopScore = user.Key;
                    sum = user.Value.Values.Sum();
                }
            }

            Console.WriteLine($"Best candidate is {userWithTopScore} with total {users.FirstOrDefault(x => x.Key == userWithTopScore).Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
