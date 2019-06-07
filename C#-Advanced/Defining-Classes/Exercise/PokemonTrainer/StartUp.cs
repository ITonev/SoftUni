using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            var input = Console.ReadLine();

            while (input != "Tournament")
            {
                var token = input.Split();

                var trainerName = token[0];
                var pokemonName = token[1];
                var element = token[2];
                var health = int.Parse(token[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                    trainers.Add(trainer);
                }

                trainers.FirstOrDefault(x => x.Name == trainerName).Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }

                    else
                    {
                        trainer.Pokemons.Select(x => x.Health -= 10).ToList();
                        trainer.Pokemons.RemoveAll(x => x.Health <= 10);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

        }
    }
}
