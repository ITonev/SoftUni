using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badScore = int.Parse(Console.ReadLine());
            int counter = 0;
            int taskCount = 0;
            int averageScore = 0;
            string taskName = string.Empty;
            string lastName = string.Empty;

            while (counter < badScore)
            {
                taskName = Console.ReadLine();
                double average = (double)averageScore / (double)taskCount;
                if (taskName == "Enough")
                {
                    Console.WriteLine($"Average score: {average:F2}\n" +
                       $"Number of problems: {taskCount}\n" +
                       $"Last problem: {lastName}");
                    break;
                }

                lastName = taskName;
                int score = int.Parse(Console.ReadLine());
                taskCount++;
                averageScore += score;

                if (score <= 4) counter++;

            }

            if (counter == badScore) Console.WriteLine($"You need a break, {badScore} poor grades.");


        }
    }
}
