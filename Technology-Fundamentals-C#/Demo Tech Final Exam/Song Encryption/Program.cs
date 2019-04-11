using System;
using System.Text.RegularExpressions;

namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                var tokens = command.Split(":");
                string artist = tokens[0];
                string song = tokens[1];

                string artistValidPattern = @"^[A-Z]{1}[a-z' ]*$";
                string songValidPattern = @"^[A-Z ]*$";

                if (Regex.IsMatch(artist, artistValidPattern) && Regex.IsMatch(song, songValidPattern))
                {
                    int stringLenght = artist.Length;

                    var output = artist + "@" + song;
                    var encrypted = string.Empty;

                    foreach (var @char in output)
                    {
                        if (@char == ' ')
                        {
                            encrypted += ' ';
                        }

                        else if (@char =='\'')
                        {
                            encrypted += '\'';
                        }

                        else if (@char == '@')
                        {
                            encrypted += '@';
                        }

                        else if (@char != '\t' && @char != ' ' && @char != '@')
                        {
                            if (@char <= 90)
                            {
                                if (@char + stringLenght > 90)
                                {
                                    encrypted += (char)(64 + stringLenght - (90 - @char));
                                }

                                else
                                {
                                    encrypted += (char)(@char + stringLenght);
                                }
                            }

                            else if (@char >= 97)
                            {
                                if (@char + stringLenght >122)
                                {
                                    encrypted += (char)(96 + stringLenght - (122 - @char));
                                }

                                else
                                {
                                    encrypted += (char)(@char + stringLenght);
                                }
                            }
                        }
                    }

                    Console.WriteLine($"Successful encryption: {encrypted}");
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
