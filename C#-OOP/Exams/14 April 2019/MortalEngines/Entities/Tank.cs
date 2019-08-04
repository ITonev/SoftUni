using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HEALTH = 100;
        private const double DECREASED_ATTACK_POINTS = 40;
        private const double INCREASED_DEFENSE_POINTS = 30;


        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode==false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= DECREASED_ATTACK_POINTS;
                this.DefensePoints += INCREASED_DEFENSE_POINTS;
            }

            else
            {
                this.DefenseMode = false;
                
                this.AttackPoints += DECREASED_ATTACK_POINTS;
                this.DefensePoints -= INCREASED_DEFENSE_POINTS;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
