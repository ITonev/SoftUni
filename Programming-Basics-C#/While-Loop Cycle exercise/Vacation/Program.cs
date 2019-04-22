using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationCost = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int spendCounter = 0;

            while (availableMoney<vacationCost && spendCounter<5)
            {
                string activity = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if (activity=="save")
                {
                    availableMoney += money;
                    days++;
                    spendCounter = 0;
                }

                else if (activity=="spend")
                {
                    availableMoney = availableMoney - money;
                    if (availableMoney < 0) availableMoney = 0;

                    spendCounter++;
                    days++;                    
                }

            }

            if (spendCounter == 5) Console.WriteLine($"You can't save the money.\n{days}");
            else Console.WriteLine($"You saved the money for {days} days.");
        }
    }
}
