using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {

            double availableMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int freeBelts = studentsCount / 6;

            double lightsabers = lightsaberPrice * (Math.Ceiling(studentsCount * 1.10));
            double robes = robePrice * studentsCount;
            double belts = beltPrice * (studentsCount - freeBelts);

            double totalPrice = lightsabers + robes + belts;

            if (availableMoney>=totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice-availableMoney):f2}lv more.");
            }
        }
    }
}
