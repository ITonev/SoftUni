using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var name = personInfo[0] + " " + personInfo[1];
            var address = personInfo[2];
            var town = string.Empty;

            if (personInfo.Length > 4)
            {
                town = personInfo[3] + " " + personInfo[4];
            }
            else
            {
                town = personInfo[3];
            }

            var beerInfo = Console.ReadLine().Split();
            var name2 = beerInfo[0];
            var liters = int.Parse(beerInfo[1]);
            var drunk = beerInfo[2] == "drunk" ? true : false;

            var bankInfo = Console.ReadLine().Split();
            var personName = bankInfo[0];
            var balance = double.Parse(bankInfo[1]);
            var bankName = bankInfo[2];

            Threeuple<string, string, string> infoPerson = new Threeuple<string, string, string>(name, address, town);
            Threeuple<string, int, bool> infoBeer = new Threeuple<string, int, bool>(name2, liters, drunk);
            Threeuple<string, double, string> infoBank = new Threeuple<string, double, string>(personName, balance, bankName);

            Console.WriteLine(infoPerson.GetInfo());
            Console.WriteLine(infoBeer.GetInfo());
            Console.WriteLine(infoBank.GetInfo());

        }
    }
}
