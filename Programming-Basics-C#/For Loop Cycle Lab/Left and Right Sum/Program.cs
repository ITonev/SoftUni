using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftsum = 0;
            int rightsum = 0;

            for (int i = 1; i <= n; i++)
            {
                int left = int.Parse(Console.ReadLine());
                leftsum += left;
            }
            for (int i = 1; i <= n; i++)
            {
                int right = int.Parse(Console.ReadLine());
                rightsum += right;
            }
            if (leftsum == rightsum) Console.WriteLine("Yes, sum = {0}", leftsum);
            else Console.WriteLine($"No, diff = {Math.Abs(leftsum-rightsum)}");
        }
    }
}
