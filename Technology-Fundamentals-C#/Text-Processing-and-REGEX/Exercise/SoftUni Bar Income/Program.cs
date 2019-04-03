using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalIncome = 0.0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input== "end of shift")
                {
                    break;
                }

                Regex reg = new Regex(@"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$");

                if (reg.IsMatch(input))
                {
                    var match = reg.Match(input);

                    var customer = match.Groups["customer"].Value;
                    var product = match.Groups["product"].Value;
                    var count = int.Parse(match.Groups["count"].Value);
                    var price = double.Parse(match.Groups["price"].Value);

                    var totalPrice = count * price;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
