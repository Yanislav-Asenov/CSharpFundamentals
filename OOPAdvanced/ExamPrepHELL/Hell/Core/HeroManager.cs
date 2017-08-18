using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HeroManager : IManager
{
    private IDictionary<string, IHero> heroes = new Dictionary<string, IHero>();

    public IDictionary<string, IHero> Heroes => this.heroes;

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type targetHeroType = Type.GetType(heroType);
            ConstructorInfo constructor = targetHeroType.GetConstructors().FirstOrDefault();
            IHero hero = constructor.Invoke(targetHeroType, new object[] { heroName }) as IHero;

            result = string.Format($"Created {heroType} - {hero.GetType().Name}");
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
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
}