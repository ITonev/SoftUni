using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const decimal coffeePrice = 3.50m;
        private const double coffeeMilliliters = 50;
        
        public Coffee(string name, double caffeine) 
            : base(name, coffeePrice, coffeeMilliliters)
        {
            this.Caffeine = caffeine; 
        }

        public double Caffeine { get; set; }

    }
}
