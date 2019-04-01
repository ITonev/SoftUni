using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();

            double pricePerPerson = 0.0;
            var totalPrice = 0.0;

            switch (groupType)
            {
                case "Students":
                    switch (dayOfTheWeek)
                    {
                        case "Friday": pricePerPerson = 8.45; break;
                        case "Saturday": pricePerPerson = 9.80; break;
                        case "Sunday": pricePerPerson = 10.46; break;
                    }
                    break;

                case "Business":
                    switch (dayOfTheWeek)
                    {
                        case "Friday": pricePerPerson = 10.90; break;
                        case "Saturday": pricePerPerson = 15.60; break;
                        case "Sunday": pricePerPerson = 16.00; break;
                    }
                    break;

                case "Regular":
                    switch (dayOfTheWeek)
                    {
                        case "Friday": pricePerPerson = 15.00; break;
                        case "Saturday": pricePerPerson = 20.00; break;
                        case "Sunday": pricePerPerson = 22.50; break;
                    }
                    break;
            }

            totalPrice = numberOfPeople * pricePerPerson;
            if (numberOfPeople>=30 && groupType=="Students")
            {
                totalPrice = (numberOfPeople * pricePerPerson) * 0.85;
            }

            else if (numberOfPeople >= 100 && groupType == "Business")
            {
                totalPrice = (numberOfPeople-10) * pricePerPerson;
            }

            else if ((numberOfPeople >= 10 && numberOfPeople<=20) && groupType == "Regular")
            {
                totalPrice = (numberOfPeople * pricePerPerson) * 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
