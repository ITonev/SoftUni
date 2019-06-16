using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var ArrVegetables = Console.ReadLine().Split();
            var ArrSaladCalories = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<string> vegetables = new Queue<string>(ArrVegetables);
            Stack<int> saladCalories = new Stack<int>(ArrSaladCalories);

            List<int> preparedSalads = new List<int>();

            while (vegetables.Count > 0
                && saladCalories.Count > 0)
            {
                int curretSaladCalories = saladCalories.Pop();
                int caloriesNeeded = curretSaladCalories;
                
                while (caloriesNeeded > 0 && vegetables.Count > 0)
                {
                    string currentVegetable = vegetables.Dequeue();
                    int currentVegetableCalories = GetCalories(currentVegetable);

                    caloriesNeeded -= currentVegetableCalories;

                    if (caloriesNeeded <= 0)
                    {
                        preparedSalads.Add(curretSaladCalories);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", preparedSalads));

            if (vegetables.Count>0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }

            if (saladCalories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", saladCalories));
            }
        }

        private static int GetCalories(string vegetable)
        {
            int calories = 0;

            switch (vegetable)
            {
                case "tomato":
                    calories = 80;
                    break;
                case "carrot":
                    calories = 136;
                    break;
                case "lettuce":
                    calories = 109;
                    break;
                case "potato":
                    calories = 215;
                    break;
            }

            return calories;
        }
    }
}
