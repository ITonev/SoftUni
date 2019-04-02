using System;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToList();

            string command = Console.ReadLine();

            while (command!="end")
            {
                var tokens = command.Split();

                if (tokens[0]=="Delete")
                {
                    numbers.RemoveAll(x=>x==int.Parse(tokens[1]));
                }

                else if (tokens[0]=="Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    
                    numbers.Insert(position, number);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
