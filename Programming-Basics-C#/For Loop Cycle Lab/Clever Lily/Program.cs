using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double washingmachinePrice = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());

            int birthdayMoney = 0;
            int evenBirthdaysCounter = 0;
            int toysCounter = 0;
            int totalSavedMoney = 0;

            for (int birthDay = 1; birthDay <= lilyAge; birthDay++)
            {
                if (birthDay%2==0) 
                {
                    evenBirthdaysCounter++;
                    birthdayMoney += (evenBirthdaysCounter * 10) - 1;
                }
                else
                {
                    toysCounter++;
                }
            }

            totalSavedMoney = birthdayMoney + (toysCounter * toysPrice);
            if (washingmachinePrice <= totalSavedMoney) Console.WriteLine($"Yes! {(totalSavedMoney-washingmachinePrice):F2}");
            else Console.WriteLine($"No! {(washingmachinePrice-totalSavedMoney):F2}");
        }
    }
}
