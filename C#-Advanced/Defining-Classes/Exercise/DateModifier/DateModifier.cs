using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public int DifferenceInDays(string firstDate, string secondDate)
        {
            this.FirstDate = DateTime.Parse(firstDate);
            this.SecondDate = DateTime.Parse(secondDate);        
                        
            return (int)Math.Abs((FirstDate-SecondDate).TotalDays);
        }
    }
}
