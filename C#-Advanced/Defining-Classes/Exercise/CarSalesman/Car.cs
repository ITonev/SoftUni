using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public Engine Engine { get; set; }


        public Car(string model, string weight, string color, Engine engine)
        {
            this.Model = model;
            this.Weight = weight;
            this.Color = color;
            this.Engine = engine;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
         
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            sb.AppendLine($"    Displacement: {this.Engine.Displacement}");
            sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            sb.AppendLine($"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}