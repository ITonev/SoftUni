using System;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var explosionPower = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '>')
                {
                    explosionPower += int.Parse(line[i + 1].ToString());

                }

                if (line[i]!='>' && explosionPower>0)
                {
                    line = line.Remove(i, 1);
                    explosionPower--;
                    i--;
                }
            }

            Console.WriteLine(line);
        }
    }
}
