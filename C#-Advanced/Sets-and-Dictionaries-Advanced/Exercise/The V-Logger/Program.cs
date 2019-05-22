using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public HashSet<string> Following { get; set; } = new HashSet<string>();

        public HashSet<string> Followers { get; set; } = new HashSet<string>();
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            var entry = Console.ReadLine();

            while (entry != "Statistics")
            {
                var tokens = entry.Split();

                if (tokens[1] == "joined")
                {
                    string vloggerName = tokens[0];

                    Vlogger vlogger = new Vlogger(vloggerName);

                    if (vloggers.FirstOrDefault(x=>x.Name==vlogger.Name)==null)
                    {
                        vloggers.Add(vlogger);
                    }
                }

                else if (tokens[1] == "followed")
                {
                    string follower = tokens[0];
                    string vloggerToFollow = tokens[2];

                    if (vloggers.FirstOrDefault(x => x.Name == follower) != null
                        && vloggers.FirstOrDefault(x => x.Name == vloggerToFollow) != null
                        && follower != vloggerToFollow)
                    {
                        var user = vloggers.Find(x => x.Name == follower);
                        var vlogger = vloggers.Find(x => x.Name == vloggerToFollow);

                        user.Following.Add(vlogger.Name);
                        vlogger.Followers.Add(user.Name);
                    }
                }

                entry = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int index = 1;

            foreach (var vlogger in vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count))
            {
                var name = vlogger.Name;
                var followers = vlogger.Followers;
                var following = vlogger.Following;

                if (index == 1)
                {
                    Console.WriteLine($"{index++}. {name} : {followers.Count} followers, {following.Count} following");

                    foreach (var follower in followers.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                else
                {
                    Console.WriteLine($"{index++}. {name} : {followers.Count} followers, {following.Count} following");
                }
            }
        }
    }
}
