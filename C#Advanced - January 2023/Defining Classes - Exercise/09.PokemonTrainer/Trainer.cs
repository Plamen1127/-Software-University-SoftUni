using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer;

internal class Trainer
{
    public Trainer(string nameTrainer)
    {
        NameTrainer = nameTrainer;
        Pokemons = new List<Pokemon>();
    }

    public string NameTrainer { get; set; }

    public int NumbersOfBadges { get; set; }

    public List<Pokemon> Pokemons { get; set; }


    public void CheckPokemon(string element)
    {
        if (Pokemons.Any(p=> p.Element==element))
        {
            NumbersOfBadges++;
        }
        else
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemon currentPokemon = Pokemons[i];

                currentPokemon.Health -= 10;
                if (currentPokemon.Health<=0)
                {
                    Pokemons.Remove(currentPokemon);
                }
            }
        }
    }
}
