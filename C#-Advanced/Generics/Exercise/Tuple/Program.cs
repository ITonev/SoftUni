using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var name = personInfo[0] + " " + personInfo[1];
            var address = personInfo[2];

            var beerInfo = Console.ReadLine().Split();
            string secondName = beerInfo[0];
            int beers = int.Parse(beerInfo[1]);
            
            var intDoubleDuo = Console.ReadLine().Split();
            int firstNum = int.Parse(intDoubleDuo[0]);
            double secondNum = double.Parse(intDoubleDuo[1]);

            Tuple<string, string> infoPerson = new Tuple<string, string>(name, address);
            Tuple<string, int> infoBeer = new Tuple<string, int>(secondName, beers);
            Tuple<int,double> infoNumbers = new Tuple<int,double>(firstNum, secondNum);

            Console.WriteLine(infoPerson.ToString());
            Console.WriteLine(infoBeer.ToString());
            Console.WriteLine(infoNumbers.ToString());
        }
    }
}
