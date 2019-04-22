using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_market
{
    class Program
    {
        static void Main(string[] args)
        {
            double wiskeyprice = double.Parse(Console.ReadLine());
            double beerquantity = double.Parse(Console.ReadLine());
            double winequantity = double.Parse(Console.ReadLine());
            double rakiaquantity = double.Parse(Console.ReadLine());
            double wiskeyquantity = double.Parse(Console.ReadLine());

            double rakiaprice = wiskeyprice / 2;
            double wineprice = rakiaprice - (0.4 * rakiaprice);
            double beerprice = rakiaprice - (0.8 * rakiaprice);

            double rakiatotal = rakiaprice * rakiaquantity;
            double winetotal = wineprice * winequantity;
            double beertotal = beerprice * beerquantity;
            double wiskeytotal = wiskeyprice * wiskeyquantity;
            double totalamount = rakiatotal + winetotal + beertotal + wiskeytotal;
            Console.WriteLine("{0:f2}", totalamount);



        }
    }
}
