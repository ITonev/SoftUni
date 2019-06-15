using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input);

            string regPattern = @"[a-zA-Z]";

            Queue<string> hall = new Queue<string>();
            List<int> hallReservations = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var item = stack.Pop();

                if (Regex.IsMatch(item, regPattern))
                {
                    hall.Enqueue(item);
                }

                else if (hall.Count > 0)
                {
                    int reservations = int.Parse(item);

                    if (hallReservations.Sum() + reservations <= capacity)
                    {
                        hallReservations.Add(reservations);
                    }

                    else
                    {
                        var currentHall = hall.Dequeue();
                        Console.WriteLine($"{currentHall} -> {string.Join(", ", hallReservations)}");
                        hallReservations.Clear();

                        if (hall.Count != 0)
                        {
                            hallReservations.Add(reservations);

                        }
                    }
                }
            }
        }
    }
}
