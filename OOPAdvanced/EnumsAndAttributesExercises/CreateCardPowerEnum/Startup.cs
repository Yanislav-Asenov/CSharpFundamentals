using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        #region 05. Card CompareTo
        //string firstCardRank = Console.ReadLine();
        //string firstCardSuit = Console.ReadLine();
        //Card firstCard = new Card(firstCardRank, firstCardSuit);

        //string secondCardRank = Console.ReadLine();
        //string secondCardSuit = Console.ReadLine();
        //Card secondCard = new Card(secondCardRank, secondCardSuit);

        //if (firstCard.CompareTo(secondCard) > 0)
        //{
        //    Console.WriteLine(firstCard);
        //}
        //else
        //{
        //    Console.WriteLine(secondCard);
        //}
        #endregion

        #region 06. Custom Enum Attribute
        //string inputCategory = Console.ReadLine();

        //var customAttributes = typeof(CardRank).GetCustomAttributes(false)
        //    .Union(typeof(CardSuit).GetCustomAttributes(false))
        //    .Where(ca => ca.GetType() == typeof(TypeAttribute));

        //foreach (TypeAttribute customAttribute in customAttributes)
        //{
        //    if (customAttribute.Category == inputCategory)
        //    {
        //        Console.WriteLine(customAttribute);
        //        break;
        //    }
        //}
        #endregion

        #region 07. Deck of Cards
        //var cardRankNames = Enum.GetNames(typeof(CardRank));
        //var cardSuitNames = Enum.GetNames(typeof(CardSuit));

        //StringBuilder result = new StringBuilder();
        //for (int i = 0; i < cardSuitNames.Length; i++)
        //{
        //    string currentCardSuit = cardSuitNames[i];

        //    for (int j = 0; j < cardRankNames.Length; j++)
        //    {
        //        string currentCardRank = cardRankNames[j];
        //        result.Append($"{currentCardRank} of {currentCardSuit}{Environment.NewLine}");
        //    }
        //}

        //Console.Write(result);
        #endregion

        #region 08. Card Game
        //// Initialize deck
        //var cardRankNames = Enum.GetNames(typeof(CardRank));
        //var cardSuitNames = Enum.GetNames(typeof(CardSuit));
        //var deck = new Dictionary<string, Card>();

        //for (int i = 0; i < cardSuitNames.Length; i++)
        //{
        //    string currentCardSuit = cardSuitNames[i];

        //    for (int j = 0; j < cardRankNames.Length; j++)
        //    {
        //        string currentCardRank = cardRankNames[j];
        //        deck.Add($"{currentCardRank} of {currentCardSuit}", new Card(currentCardRank, currentCardSuit));
        //    }
        //}

        //// Get player names
        //string firstPlayer = Console.ReadLine();
        //string secondPlayer = Console.ReadLine();

        //// Get player cards
        //List<Card> firstPlayerCards = new List<Card>();
        //GetCardsForPlayer(firstPlayerCards, deck);

        //List<Card> secondPlayerCards = new List<Card>();
        //GetCardsForPlayer(secondPlayerCards, deck);

        //// Get players most powered card
        //Card firstPlayerMaxMostPoweredCard = firstPlayerCards.Max();
        //Card secondPlayerMostPoweredCard = secondPlayerCards.Max();

        //if (firstPlayerMaxMostPoweredCard.CompareTo(secondPlayerMostPoweredCard) > 0)
        //{
        //    Console.WriteLine($"{firstPlayer} wins with {firstPlayerMaxMostPoweredCard.Rank} of {firstPlayerMaxMostPoweredCard.Suit}.");
        //}
        //else
        //{
        //    Console.WriteLine($"{secondPlayer} wins with {secondPlayerMostPoweredCard.Rank} of {secondPlayerMostPoweredCard.Suit}.");
        //}
        #endregion
    }

    public static void GetCardsForPlayer(List<Card> playerCards, Dictionary<string, Card> availableCards)
    {
        while (playerCards.Count < 5)
        {
            string targetCard = Console.ReadLine();
            if (availableCards.ContainsKey(targetCard))
            {
                if (availableCards[targetCard] == null)
                {
                    Console.WriteLine("Card is not in the deck.");
                }
                else
                {
                    playerCards.Add(availableCards[targetCard]);
                    availableCards[targetCard] = null;
                }
            }
            else
            {
                Console.WriteLine("No such card exists.");
            }
        }
    }
}