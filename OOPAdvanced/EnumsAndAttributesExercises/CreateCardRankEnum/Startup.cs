using System;
using System.Text;

public class Startup
{
    public static void Main()
    {
        Type cardSuitType = typeof(CardRank);
        var cardSuitNames = Enum.GetNames(cardSuitType);

        StringBuilder result = new StringBuilder();
        result.Append($"Card Ranks:{Environment.NewLine}");
        foreach (var cardSuitName in cardSuitNames)
        {
            if (Enum.TryParse(cardSuitName, out CardRank cardSuit))
            {
                result.Append($"Ordinal value: {(int)cardSuit}; Name value: {cardSuitName}{Environment.NewLine}");
            }
        }
        Console.Write(result);
    }
}