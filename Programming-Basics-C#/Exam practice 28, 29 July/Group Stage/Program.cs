using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Stage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());
            int totalGoalScored = 0;
            int totalGoalsReceived = 0;
            int totalPoints = 0;
            for (int i = 1; i <=matches; i++)
            {
                int goalsScored = int.Parse(Console.ReadLine());
                int goalsReceived = int.Parse(Console.ReadLine());

                if (goalsScored > goalsReceived) totalPoints += 3;
                else if (goalsScored < goalsReceived) totalPoints += 0;
                else if (goalsScored == goalsReceived) totalPoints += 1;

                totalGoalScored += goalsScored;
                totalGoalsReceived += goalsReceived;
            }

            if (totalGoalScored>=totalGoalsReceived)
            {
                Console.WriteLine($"{team} has finished the group phase with {totalPoints} points." +
                    $"\nGoal difference: {totalGoalScored - totalGoalsReceived}.");                
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase." +
                    $"\nGoal difference: {totalGoalScored-totalGoalsReceived}.");
            }

        }
    }
}
