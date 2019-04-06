using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgeCount = int.Parse(Console.ReadLine());
            double fullTotalscore = 0;
            double presentationsCount = 0;
            while (true)
            {
                string presentation = Console.ReadLine();

                double totalScore = 0.0;
                fullTotalscore +=totalScore ;

                if (presentation == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {(fullTotalscore / (judgeCount*presentationsCount)):F2}.");
                        break;
                } 
                                
                for (int i = 1; i <=judgeCount; i++)
                {
                    double score = double.Parse(Console.ReadLine());
                    totalScore += score;
                    fullTotalscore += score;
                }
                presentationsCount++;
                Console.WriteLine($"{presentation} - {(totalScore/judgeCount):F2}.");
            }

        }
    }
}
