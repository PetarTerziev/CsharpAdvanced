using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            Badges = 0;
        }
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }

        public void DecreaseHealth() 
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public void RemoveDeadPokemons() 
        {
            List<Pokemon> result = new List<Pokemon>();

            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Health > 0)
                {
                    result.Add(pokemon);
                }
            }

            Pokemons = result;
        }
    }
}
