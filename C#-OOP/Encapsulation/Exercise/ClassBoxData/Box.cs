using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                LenghtValidations(value, nameof(this.Length));

                this.length = value;
            }
        }        

        public double Width
        {
            get => this.width;
            private set
            {
                LenghtValidations(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                LenghtValidations(value, nameof(this.Height));

                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        public double Volume()
        {
            return this.height * this.length * this.width;
        }

        private static void LenghtValidations(double value, string param)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{param} cannot be zero or negative.");
            }
        }
    }
}
