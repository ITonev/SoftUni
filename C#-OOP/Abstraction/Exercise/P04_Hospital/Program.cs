using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] input = command.Split();

                var departament = input[0];
                var fullName = input[1] + input[2];
                var patient = input[3];

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool hasFreeSpace = departments[departament].SelectMany(x => x).Count() < 60;

                if (hasFreeSpace)
                {
                    int roomNumber = 0;

                    doctors[fullName].Add(patient);

                    for (int room = 0; room < departments[departament].Count; room++)
                    {
                        if (departments[departament][room].Count < 3)
                        {
                            roomNumber = room;
                            break;
                        }
                    }

                    departments[departament][roomNumber].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split();

                if (input.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[input[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }

                else if (input.Length == 2 && int.TryParse(input[1], out int room))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[input[0]][room - 1].OrderBy(x => x)));
                }

                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[input[0] + input[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
