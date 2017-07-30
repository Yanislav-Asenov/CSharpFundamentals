using System;
using System.Text;

public class Startup
{
    public static void Main()
    {
        Type cardSuitType = typeof(CardSuit);
        var cardSuitNames = Enum.GetNames(cardSuitType);

        StringBuilder result = new StringBuilder();
        result.Append($"Card Suits:{Environment.NewLine}");
        foreach (var cardSuitName in cardSuitNames)
        {
            if (Enum.TryParse(cardSuitName, out CardSuit cardSuit))
            {
                result.Append($"Ordinal value: {(int)cardSuit}; Name value: {cardSuitName}{Environment.NewLine}");
            }
        }
        Console.Write(result);
    }
}