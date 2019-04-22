using System;
using System.Text;
using System.Text.RegularExpressions;

namespace First_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Last note")
                {
                    break;
                }

                var pattern = @"^(?<peak>[a-zA-Z0-9!@#$?]+)=(?<lenght>[0-9]+)<<(?<geohash>.*)$";

                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);

                    var peak = match.Groups["peak"].Value;
                    var lenght = match.Groups["lenght"].Value;
                    var geohash = match.Groups["geohash"].Value;

                    if (geohash.Length == int.Parse(lenght))
                    {
                        StringBuilder peakName = new StringBuilder();

                        foreach (var @char in peak)
                        {
                            if (char.IsLetter(@char))
                            {
                                peakName.Append(@char);
                            }
                        }

                        Console.WriteLine($"Coordinates found! {peakName.ToString()} -> {geohash}");
                    }

                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }

                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
