using System;
using System.Linq;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool passwordLenght = PasswordLenghtCheck(password);
            if (!passwordLenght) Console.WriteLine("Password must be between 6 and 10 characters");

            bool onlyLettersAndDigits = PasswordOnlyLetterAndDigits(password);
            if (!onlyLettersAndDigits) Console.WriteLine("Password must consist only of letters and digits");

            bool atleast2Digits = PasswordContainsMin2Digits(password);
            if (!atleast2Digits) Console.WriteLine("Password must have at least 2 digits");

            if (passwordLenght && onlyLettersAndDigits && atleast2Digits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool PasswordContainsMin2Digits(string password)
        {
            int digitCounter = password.Count(x => char.IsDigit(x));
            return digitCounter >= 2;
        }

        private static bool PasswordOnlyLetterAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool PasswordLenghtCheck(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else return false;
        }
    }
}
