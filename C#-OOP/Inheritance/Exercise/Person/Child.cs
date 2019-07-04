using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public int Age
        {
            get
            {
                return base.Age;
            }

            set
            {
                base.Age = value;
            }
        }
    }
}
