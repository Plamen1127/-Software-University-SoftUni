using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer;

internal class Pokemon
{

    public Pokemon(string namePokemon, string element, int health)
    {
        NamePokemon = namePokemon;
        Element = element;
        Health = health;
    }

    public string  NamePokemon { get; set; }

    public string  Element { get; set; }

    public int Health { get; set; }
}
