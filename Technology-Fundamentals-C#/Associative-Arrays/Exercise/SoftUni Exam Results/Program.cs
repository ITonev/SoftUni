using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersSubmissions = new Dictionary<string, int>();
            var languageSubmissions = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input== "exam finished")
                {
                    break;
                }

                var tokens = input.Split("-");

                if (tokens.Length>2)
                {
                    var userName = tokens[0];
                    var language = tokens[1];
                    var points = int.Parse(tokens[2]);

                    if (!usersSubmissions.ContainsKey(userName))
                    {
                        usersSubmissions[userName] = 0;
                    }

                    if (usersSubmissions[userName]<points)
                    {
                        usersSubmissions[userName] = points;
                    }

                    if (!languageSubmissions.ContainsKey(language))
                    {
                        languageSubmissions[language] = 0;
                    }

                    languageSubmissions[language]++;
                }

                if (input.Contains("banned"))
                {
                    usersSubmissions.Remove(tokens[0]);
                }
            }

            Console.WriteLine("Results:");
            foreach (var kvp in usersSubmissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in languageSubmissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
