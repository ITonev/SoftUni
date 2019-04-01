using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double gamingExpenses = 0.0;
            int trashcount = 0;

            for (int i = 1; i <=lostGamesCount; i++)
            {

                if (i%2==0)
                {
                    gamingExpenses += headsetPrice;
                }

                if (i%3==0)
                {
                    gamingExpenses += mousePrice;
                }

                if (i%6==0)
                {
                    gamingExpenses += keyboardPrice;
                    trashcount++;
                }

                if (trashcount==2)
                {
                    gamingExpenses += displayPrice;
                    trashcount = 0;
                }
            }

            Console.WriteLine($"Rage expenses: {gamingExpenses:f2} lv.");
        }
    }
}
