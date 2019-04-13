using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split("&");

            List<string> keys = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string key = input[i].ToUpper();

                var pattern = @"^(?<first>[a-zA-Z0-9]{25})|(?<second>[a-zA-Z0-9]{16})$";

                StringBuilder newKey = new StringBuilder();

                if (Regex.IsMatch(key, pattern))
                {
                    for (int p = 0; p < key.Length; p++)
                    {
                        if (char.IsDigit(key[p]))
                        {
                            var currentKey = 9 - int.Parse((key[p].ToString()));
                            newKey.Append(currentKey);
                        }

                        else
                        {
                            newKey.Append(key[p]);
                        }
                    }

                    if (newKey.Length == 16)
                    {
                        for (int j = 4; j < newKey.Length; j = j + 5)
                        {
                            newKey = newKey.Insert(j, "-");
                        }
                    }

                    else if (newKey.Length == 25)
                    {
                        for (int j = 5; j < newKey.Length; j = j + 6)
                        {
                            newKey = newKey.Insert(j, "-");
                        }
                    }

                    keys.Add(newKey.ToString());
                }
            }

            Console.WriteLine(string.Join(", ", keys));
        }
    }
}
