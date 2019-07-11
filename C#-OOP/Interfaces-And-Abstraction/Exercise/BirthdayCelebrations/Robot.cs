using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : Identification
    {
        public Robot(string model, string id)
            : base(id)
        {
            this.Model = model;
        }

        public string Model { get; set; }
    }
}
