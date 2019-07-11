using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public abstract class Identification
    {
        protected Identification(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
