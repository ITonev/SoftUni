using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Pizza Meatless
            //Dough Wholegrain Crispy 100
            //Topping Veggies 50
            //Topping Cheese 50

            var pizaName = Console.ReadLine().Substring(6);

            var doughArgs = Console.ReadLine().Split();

            try
            {
                Dough dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));

                Pizza pizza = new Pizza(pizaName, dough);

                var command = Console.ReadLine();

                while (command != "END")
                {
                    var currentToppingArgs = command.Split();

                    Topping topping = new Topping(currentToppingArgs[1], int.Parse(currentToppingArgs[2]));

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                var calories = pizza.Calories;
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
