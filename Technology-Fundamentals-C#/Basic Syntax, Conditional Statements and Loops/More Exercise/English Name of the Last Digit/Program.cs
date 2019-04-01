using System;

namespace English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;
            string letter = LastLeterInEnglish(lastDigit);
            Console.WriteLine(letter);
        }

        private static string LastLeterInEnglish(int lastDigit)
        {
            string lastDig = string.Empty;
            switch (lastDigit)
            {
                case 1: lastDig= "one";break;
                case 2: lastDig= "two";break;
                case 3: lastDig= "three";break;
                case 4: lastDig= "four";break;
                case 5: lastDig= "five";break;
                case 6: lastDig= "six";break;
                case 7: lastDig= "seven";break;
                case 8: lastDig= "eight";break;
                case 9: lastDig= "nine";break;
                case 0: lastDig= "zero";break;
            }

            return lastDig;
        }
    }
}
