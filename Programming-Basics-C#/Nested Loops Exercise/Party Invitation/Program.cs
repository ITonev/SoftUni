using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Invitation
{
    class Program
    {
        static void Main(string[] args)
        {
            int counterValidNames = 0;
            int counterInvalidNames = 0;
            double counter = 0;

            while (true)
            {
                bool validName = true;
                string name = Console.ReadLine();

                if (name == "Statistic")
                {
                    break;
                }
                string newName = string.Empty;
                for (int i = 0; i < name.Length; i++)
                {
                    char ch = name[i];
                    if (!(char.IsLetter(ch)))
                    {
                        validName = false;
                        
                    }
                }
                if (!validName)
                {
                    Console.WriteLine("Invalid name!");
                    counterInvalidNames++;
                }
                else
                {
                    string currentName = string.Empty;
                    name = name.ToUpper();
                    newName = name.ToLower();
                    char firstLetter = name[0];
                    for (int i = 1; i < newName.Length; i++)
                    {
                        currentName += newName[i];
                    }
                    newName = firstLetter + currentName;
                    Console.WriteLine(newName);
                    counterValidNames++;
                }
                counter++;
            }
            double percenValidNames = counterValidNames / counter * 100;
            double percentInvalidNames = counterInvalidNames / counter * 100;

            Console.WriteLine($"Valid names are {percenValidNames:f2}% from {counter} names.");
            Console.WriteLine($"Invalid names are {percentInvalidNames:f2}% from {counter} names.");
        }
    }
}
