using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;
        private const int MIN_HORSEPOWER = 70;
        private const int MAX_HORSEPOWER = 100;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {

        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value<MIN_HORSEPOWER || value> MAX_HORSEPOWER)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                base.HorsePower = value;
            }
        }
    }
}
