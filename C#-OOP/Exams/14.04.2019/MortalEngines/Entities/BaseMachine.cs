using System;
using System.Text;
using System.Collections.Generic;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;

        private IPilot pilot;

        private double attackPoints;

        private double defensePoints;

        private double healthPoints;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }


        public IPilot Pilot
        {
            get => this.pilot;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;

            set => this.healthPoints = value;
        }

        public double AttackPoints
        {
            get => this.attackPoints;

            protected set => this.attackPoints = value;
        }

        public double DefensePoints
        {
            get => this.defensePoints;

            protected set => this.defensePoints = value;
        }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}")
              .AppendLine($" *Type: {this.GetType().Name}")
              .AppendLine($" *Health: {this.HealthPoints:f2}")
              .AppendLine($" *Attack: {this.AttackPoints:f2}")
              .AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }

            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
