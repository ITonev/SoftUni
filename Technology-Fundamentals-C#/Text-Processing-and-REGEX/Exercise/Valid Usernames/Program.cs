using System;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            var usernames = Console.ReadLine().Split(", ");
            bool validUsername = true;

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        if (char.IsLetterOrDigit(username[i]) || username[i] == '-' || username[i] == '_')
                        {
                            validUsername = true;
                           
                        }
                        else
                        {
                            validUsername = false;
                            break;
                        }
                    }
                    if (validUsername)
                    {
                        Console.WriteLine(username);
                    }

                }
            }

        }
    }
}
