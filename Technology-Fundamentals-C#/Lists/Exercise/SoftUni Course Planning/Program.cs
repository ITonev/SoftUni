using System;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = Console.ReadLine()
                    .Split(", ")
                    .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "course start")
                {
                    break;
                }

                var tokens = command.Split(":");

                if (tokens[0] == "Add" && courses.Contains(tokens[1]) == false)
                {
                    courses.Add(tokens[1]);
                }

                else if (tokens[0] == "Insert" && courses.Contains(tokens[1]) == false)
                {
                    if (int.Parse(tokens[2])<courses.Count || int.Parse(tokens[2])>=0)
                    {
                        courses.Insert(int.Parse(tokens[2]), tokens[1]);
                    }                    
                }

                else if (tokens[0] == "Remove" && courses.Contains(tokens[1]))
                {
                    string course = tokens[1];
                    courses.Remove(tokens[1]);
                    courses.Remove($"{course}-Exercise");
                }

                else if (tokens[0] == "Swap" && courses.Contains(tokens[1]) && courses.Contains(tokens[2]))
                {
                    int indexOfFirst = courses.IndexOf(tokens[1]);
                    int indexOfSecond = courses.IndexOf(tokens[2]);

                    string firstCourse = courses[indexOfFirst];
                    string secondCourse = courses[indexOfSecond];

                    courses[indexOfFirst] = secondCourse;
                    courses[indexOfSecond] = firstCourse;

                    if (courses.Contains($"{firstCourse}-Exercise"))
                    {
                        courses.RemoveAt(indexOfFirst + 1);
                        courses.Insert(indexOfSecond + 1, $"{firstCourse}-Exercise");
                    }

                    if (courses.Contains($"{secondCourse}-Exercise"))
                    {

                        courses.RemoveAt(indexOfSecond + 1);
                        courses.Insert(indexOfFirst + 1, $"{secondCourse}-Exercise");

                    }
                }

                else if (tokens[0] == "Exercise")
                {
                    string lesson = tokens[1];
                    string lessonExercise = ($"{tokens[1]}-Exercise");

                    if (courses.Contains(lesson) == false)
                    {
                        courses.Add(lesson);
                        courses.Add(lessonExercise);
                    }
                    else
                    {
                        int indexOfLesson = courses.IndexOf(lesson);
                        courses.Insert(indexOfLesson + 1, lessonExercise);
                    }
                }
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
