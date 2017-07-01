using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string inputLine = Console.ReadLine();
        Dictionary<string, Trainer> trainersByName = new Dictionary<string, Trainer>();

        while (inputLine != "Tournament")
        {
            string[] inputLineArgs = inputLine.Split();

            string trainerName = inputLineArgs[0];
            string pokemonName = inputLineArgs[1];
            string pokemonElement = inputLineArgs[2];
            int pokemonHealth = int.Parse(inputLineArgs[3]);

            Trainer trainer = new Trainer(trainerName);
            if (!trainersByName.ContainsKey(trainerName))
            {
                trainersByName.Add(trainerName, trainer);
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            trainersByName[trainerName].Pokemons.Add(pokemon);

            inputLine = Console.ReadLine();
        }

        string targetElement = Console.ReadLine();
        while (targetElement != "End")
        {
            foreach (var kvp in trainersByName)
            {
                if (kvp.Value.HasPokemonWithElement(targetElement))
                {
                    kvp.Value.Badges++;
                }
                else
                {
                    kvp.Value.DamagePokemons();
                }
            }

            targetElement = Console.ReadLine();
        }

        foreach (var trainer in trainersByName.OrderByDescending(t => t.Value.Badges))
        {
            Console.WriteLine(trainer.Value);
        }
    }
}

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public ICollection<Pokemon> Pokemons { get; set; }

    public Trainer(string name)
    {
        this.Name = name;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public bool HasPokemonWithElement(string element)
    {
        return this.Pokemons.Any(p => p.Element == element);
    }

    public void DamagePokemons()
    {
        foreach (var pokemon in this.Pokemons)
        {
            pokemon.Health -= 10;
        }

        this.FilterDeadPokemons();
    }

    private void FilterDeadPokemons()
    {
        this.Pokemons = this.Pokemons.Where(p => p.Health > 0).ToList();
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    }
}

public class Pokemon
{
    public string Name { get; set; }
    public string Element { get; set; }
    public int Health { get; set; }

    public Pokemon(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}

