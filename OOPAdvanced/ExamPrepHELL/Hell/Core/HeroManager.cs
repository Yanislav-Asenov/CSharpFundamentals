using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    private IDictionary<string, IHero> heroes = new Dictionary<string, IHero>();

    public IDictionary<string, IHero> Heroes => this.heroes;

    public string AddHero(IList<string> arguments)
    {
        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type targetHeroType = Type.GetType(heroType);
            IHero hero = Activator.CreateInstance(targetHeroType, new object[] { heroName }) as IHero;
            this.Heroes.Add(hero.Name, hero);

            string result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
            return result;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string AddItemToHero(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);

        this.Heroes[heroName].Inventory.AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);
        string[] requiredItems = arguments.Skip(7).ToArray();

        RecipeItem newRecipe = new RecipeItem(
            itemName, 
            strengthBonus, 
            agilityBonus, 
            intelligenceBonus, 
            hitPointsBonus,
            damageBonus, 
            requiredItems);

        this.Heroes[heroName].Inventory.AddRecipeItem(newRecipe);

        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
        return result;
    }

    public string Quit(IList<string> arguments)
    {
        int heroCounter = 1;
        StringBuilder result = new StringBuilder();

        var orderedHeroes = this.Heroes
            .Values
            .OrderByDescending(h => h.PrimaryStats)
            .ThenByDescending(h => h.SecondaryStats);
        foreach (var hero in orderedHeroes)
        {
            result.AppendLine($"{heroCounter++}. {hero.GetType().Name}: {hero.Name}");
            result.AppendLine($"###HitPoints: {hero.HitPoints}");
            result.AppendLine($"###Damage: {hero.Damage}");
            result.AppendLine($"###Strength: {hero.Strength}");
            result.AppendLine($"###Agility: {hero.Agility}");
            result.AppendLine($"###Intelligence: {hero.Intelligence}");

            string items = hero.Items.Count == 0 ? "None" : string.Join(", ", hero.Items.Select(i => i.Name));
            result.AppendLine($"###Items: {items}");
        }

        return result.ToString().Trim();
    }
}