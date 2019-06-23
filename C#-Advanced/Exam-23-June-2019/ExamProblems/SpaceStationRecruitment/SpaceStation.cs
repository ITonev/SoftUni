using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.astronauts.Count;
         

        public SpaceStation(string name, int capacity)
        {
            this.astronauts = new List<Astronaut>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Astronaut astronaut)
        {
            this.astronauts.Add(astronaut);
        }

        public bool Remove(string name)
        {
            var astronautToRemove = this.astronauts.FirstOrDefault(x => x.Name == name);

            if (astronautToRemove==null)
            {
                return false;
            }

            this.astronauts.Remove(astronautToRemove);

            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            var oldest = this.astronauts.OrderByDescending(x => x.Age).First();
            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            var astronaut = this.astronauts.FirstOrDefault(x => x.Name == name);
            
            if (astronaut==null)
            {
                throw new InvalidOperationException("No such astronaut found");
            }

            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            sb.AppendLine(string.Join(Environment.NewLine, astronauts));

            return sb.ToString().TrimEnd();
        }

    }
}
