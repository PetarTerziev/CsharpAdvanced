using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] trainersInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (trainersInfo[0] == "Tournament")
                {
                    break;
                }

                string trainerName = trainersInfo[0];

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(CreateTrainer(trainerName));
                }

                Trainer currentTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();
                currentTrainer.Pokemons.Add(CreatePokemon(trainersInfo));
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                TournamentRound(trainers, element);
            }
            
            foreach (var trainer in trainers.OrderByDescending(p => p.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        static Trainer CreateTrainer(string trainerName) 
        {   
            Trainer newTrainer = new Trainer(trainerName);

            return newTrainer;
        }
        static Pokemon CreatePokemon(string[] pokemonInfo) 
        {
            Pokemon newPokemon = new Pokemon(pokemonInfo[1], pokemonInfo[2],
                                            int.Parse(pokemonInfo[3]));

            return newPokemon;
        }

        static void TournamentRound(List<Trainer> trainers, string element) 
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                if (trainers[i].Pokemons.Any(p => p.Element == element))
                {
                    trainers[i].Badges++;
                }
                else
                {
                    trainers[i].DecreaseHealth();
                }

                trainers[i].RemoveDeadPokemons();
            }
        }

    }
}
