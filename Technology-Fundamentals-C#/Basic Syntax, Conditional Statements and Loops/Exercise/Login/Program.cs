using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {

            string userName = Console.ReadLine();
            int wrongPasswordsCounter = 0;

            while (true)
            {

                string password = Console.ReadLine();
                string reversedPasswrd = string.Empty;

                for (int i = password.Length - 1; i >= 0; i--)
                {
                    reversedPasswrd += password[i];
                }

                if (userName != reversedPasswrd)
                {
                    wrongPasswordsCounter++;
                    if (wrongPasswordsCounter==4)
                    {
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }

                else
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
            }

            if (wrongPasswordsCounter == 4)
            {
                Console.WriteLine($"User {userName} blocked!");
            }

        }
    }
}
