using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Identification> identifications = new List<Identification>();

            var input = Console.ReadLine();

            while (input!="End")
            {
                var tokens = input.Split();

                if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);

                    identifications.Add(robot);
                }

                else if (tokens.Length==3)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);

                    identifications.Add(citizen);
                }

                input = Console.ReadLine();
            }

            var fakeIds = Console.ReadLine();

            foreach (var entity in identifications.Where(x=>x.Id.EndsWith(fakeIds)))
            {
                Console.WriteLine(entity.Id);
            }
        }
    }
}
