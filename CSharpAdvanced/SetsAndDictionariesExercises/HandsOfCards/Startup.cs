namespace HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var peopleHands = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string[] handInfoArgs = Console.ReadLine()
                    .Split(':')
                    .Select(x => x.Trim())
                    .ToArray();

                string name = handInfoArgs[0];

                if (name.Equals("JOKER"))
                {
                    break;
                }

                string[] cards = handInfoArgs[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!peopleHands.ContainsKey(name))
                {
                    peopleHands.Add(name, new HashSet<string>());
                }

                foreach (var card in cards)
                {
                    peopleHands[name].Add(card);
                }
            }

            foreach (var kvp in peopleHands)
            {
                int handPower = 0;

                foreach (var card in kvp.Value)
                {
                    char cardType = card[card.Length - 1];
                    string cardPower = card.Substring(0, card.Length - 1);

                    handPower += GetCardPower(cardPower, cardType);
                }

                Console.WriteLine($"{kvp.Key}: {handPower}");
            }
        }

        private static int GetCardPower(string cardPower, char cardType)
        {
            var cardPowers = new Dictionary<string, int>()
            {
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "A", 14 }
            };

            var cardTypePowers = new Dictionary<char, int>()
            {
                { 'S', 4 },
                { 'H', 3 },
                { 'D', 2 },
                { 'C', 1 }
            };

            return cardPowers[cardPower] * cardTypePowers[cardType];
        }
    }
}
