using System;

public class Card : IComparable<Card>
{
    public Card(string rank, string suit)
    {
        if (Enum.TryParse(rank, out CardRank parsedRank))
        {
            this.Rank = parsedRank;
        }

        if (Enum.TryParse(suit, out CardSuit parsedSuit))
        {
            this.Suit = parsedSuit;
        }
    }

    public CardRank Rank { get; private set; }

    public CardSuit Suit { get; private set; }

    public int Power => (int)this.Rank + (int)this.Suit;

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
    }
}