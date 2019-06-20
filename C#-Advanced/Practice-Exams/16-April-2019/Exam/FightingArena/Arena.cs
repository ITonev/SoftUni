using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var toRemove = this.gladiators.FirstOrDefault(x => x.Name == name);
            this.gladiators.Remove(toRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.gladiators.OrderBy(x => x.GetStatPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.gladiators.OrderBy(x => x.GetWeaponPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.gladiators.OrderBy(x => x.GetTotalPower()).FirstOrDefault();
        }

        public override string ToString()
        {
            return ($"[{this.Name}] - [{this.Count}] gladiators are participating.").TrimEnd();
        }
    }
}
