using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
               
        public int GetTotalPower()
        {
            return this.GetStatPower() + this.GetWeaponPower();
        }

        public int GetWeaponPower()
        {
            int power = this.Weapon.Sharpness
                    + this.Weapon.Size
                    + this.Weapon.Solidity;

            return power;

        }

        public int GetStatPower()
        {
            int power = this.Stat.Agility
                    + this.Stat.Flexibility
                    + this.Stat.Intelligence
                    + this.Stat.Strength
                    + this.Stat.Skills;

            return power;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($" Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($" Stat Power: [{this.GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }

    }
}
