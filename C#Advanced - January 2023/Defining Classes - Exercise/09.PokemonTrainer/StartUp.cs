
using System;

namespace PokemonTrainer;


public class StartUp
{
    public static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();
        string command;

        while ((command=Console.ReadLine()) != "Tournament")
        {
            string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Trainer trainer = trainers.SingleOrDefault(t => t.NameTrainer == info[0]);

            if (trainer==null)
            {
                trainer = new Trainer(info[0]);
                trainer.Pokemons.Add(new(info[1], info[2], int.Parse(info[3])));
                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(new(info[1], info[2], int.Parse(info[3])));
            }
        }

        string command2;
        while ((command2 = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                trainer.CheckPokemon(command2);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t=> t.NumbersOfBadges ))
        {
            Console.WriteLine($"{trainer.NameTrainer} {trainer.NumbersOfBadges} {trainer.Pokemons.Count}");
        }
    }
}
