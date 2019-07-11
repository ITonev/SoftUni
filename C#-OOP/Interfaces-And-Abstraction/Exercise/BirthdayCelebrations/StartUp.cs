using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IPersonalInfo> personalInfos = new List<IPersonalInfo>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split();

                var type = tokens[0];

                if (type == "Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);

                    personalInfos.Add(citizen);
                }

                else if (type == "Pet")
                {
                    Pet pet = new Pet(tokens[1], tokens[2]);

                    personalInfos.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(year))
            {
                foreach (var entity in personalInfos.Where(x => x.Birthdate.EndsWith(year)))
                {
                    Console.WriteLine(entity.Birthdate);
                }

            }
        }
    }
}
