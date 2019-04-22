using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double value = double.Parse(Console.ReadLine());
            string inCurrency = Console.ReadLine();
            string outCurrency = Console.ReadLine();

            double courseUSD = 1.79549;
            double courseEUR = 1.95583;
            double courseGBP = 2.53405;

            double moneyInBGN = 0;
            double result = 0;


            
            if (inCurrency == "BGN" && outCurrency == "USD")
            {
                result = value / courseUSD;
            }
            else if (inCurrency=="BGN" && outCurrency=="EUR")
            {
                result = value / courseEUR;
            }
            else if (inCurrency=="BGN" && outCurrency=="GBP")
            {
                result = value / courseGBP;
            }
            else if (inCurrency == "USD" && outCurrency == "BGN")
            {
                result = value * courseUSD;
            }
            else if (inCurrency == "USD" && outCurrency == "EUR")
            {
                moneyInBGN = value * courseUSD;
                result = moneyInBGN / courseUSD;
            }
            else if (inCurrency == "USD" && outCurrency == "GBP")
            {
                moneyInBGN = value * courseUSD;
                result = moneyInBGN / courseGBP;
            }
            else if (inCurrency == "EUR" && outCurrency == "BGN")
            {
                result = value * courseEUR;
            }
            else if (inCurrency == "EUR" && outCurrency == "USD")
            {
                moneyInBGN = value * courseEUR;
                result = moneyInBGN / courseUSD;
            }
            else if (inCurrency == "EUR" && outCurrency == "GBP")
            {
                moneyInBGN = value * courseEUR;
                result = moneyInBGN / courseGBP;
            }
            else if (inCurrency == "GBP" && outCurrency == "BGN")
            {
                result = value * courseGBP;
            }
            else if (inCurrency == "GBP" && outCurrency == "USD")
            {
                moneyInBGN = value * courseGBP;
                result = moneyInBGN / courseUSD;
            }
            else if (inCurrency == "GBP" && outCurrency == "EUR")
            {
                moneyInBGN = value * courseGBP;
                result = moneyInBGN / courseEUR;
            }
            Console.WriteLine(Math.Round(result, 2) +" "+ outCurrency);
        }
    }
}
