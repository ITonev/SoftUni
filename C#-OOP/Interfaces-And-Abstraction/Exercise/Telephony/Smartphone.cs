using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        private string number;
        private string website;

        public string Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (!NumberValidation(value))
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.number = value;
            }
        }               

        public string Website
        {
            get
            {
                return this.website;
            }

            set
            {
                if (WebsiteValidation(value))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.website = value;
            }
        }        

        public string Browse()
        {
            return $"Browsing: {this.Website}!";
        }

        public string Call()
        {
            return $"Calling... {this.Number}";
        }


        private bool NumberValidation(string value)
        {
            foreach (var c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool WebsiteValidation(string value)
        {
            return value.FirstOrDefault(c => char.IsDigit(c)) != 0;
        }
    }
}
