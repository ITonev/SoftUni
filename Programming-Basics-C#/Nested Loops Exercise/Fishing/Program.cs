using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyQuota = int.Parse(Console.ReadLine());
            int counter = 0;
            double profit = 0;

            for (int i = 1; i <=dailyQuota; i++)
            {
                string fish = Console.ReadLine();
                if (fish == "Stop")
                {
                    break;
                }

                double fishWeight = double.Parse(Console.ReadLine());
                int letterSum = 0;

                for (int j = 0; j < fish.Length; j++)
                {
                    letterSum += fish[j];
                }
                double fishPrice = (letterSum / fishWeight);
                if (i % 3 == 0) profit += fishPrice;
                else profit -= fishPrice;
                counter++;
            }

            if (counter == dailyQuota) Console.WriteLine("Lyubo fulfilled the quota!");

            if (profit <= 0) Console.WriteLine($"Lyubo lost {Math.Abs(profit):F2} leva today.");
            else if (profit >0) Console.WriteLine($"Lyubo's profit from {counter} fishes is {(profit):F2} leva.");

        }
    }
}
