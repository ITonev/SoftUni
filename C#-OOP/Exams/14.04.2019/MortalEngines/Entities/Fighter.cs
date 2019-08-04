using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH = 200;
        private const double INCREASED_ATTACK_POINTS = 50;
        private const double DECREASED_DEFENSE_PONTS = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode==true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= INCREASED_ATTACK_POINTS;
                this.DefensePoints += DECREASED_DEFENSE_PONTS;

            }

            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += INCREASED_ATTACK_POINTS;
                this.DefensePoints -= DECREASED_DEFENSE_PONTS;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($" *Aggressive: {(this.AggressiveMode==true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
