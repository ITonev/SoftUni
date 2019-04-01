using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {

            int NPokePower = int.Parse(Console.ReadLine());
            int Mdistance = int.Parse(Console.ReadLine());
            int YexhaustionFactor = int.Parse(Console.ReadLine());
            int middlePoke = NPokePower * 50 / 100;
            int initialPokePower = NPokePower;
            int poketTargets = 0;

            while (initialPokePower>=Mdistance)
            {
                initialPokePower -= Mdistance;
                poketTargets++;

                if (initialPokePower == middlePoke)
                {
                    initialPokePower /= YexhaustionFactor;
                }
            }

            Console.WriteLine($"{initialPokePower}\n{poketTargets}");

        }
    }
}
