﻿using System.Collections.Generic;

public class RecipeItem : Item, IRecipe
{
    private readonly IList<string> requiredItems;

    public RecipeItem(
        string name, 
        int strengthBonus, 
        int agilityBonus, 
        int intelligenceBonus, 
        int hitPointsBonus, 
        int damageBonus,
        IList<string> requiredItems) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.requiredItems = new List<string>(requiredItems);
    }

    public IList<string> RequiredItems => this.requiredItems;
}