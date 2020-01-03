using System;
using System.Collections.Generic;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Utils
{
    public static class DeckExtensions
    {
        private static Random random = new Random();
        public static List<PlayingCard> Initiate(this List<PlayingCard> cards)
        {
            var suits = new List<Suit>()
            {
                Suit.Spades,
                Suit.Hearts,
                Suit.Diamonds,
                Suit.Clubs
            };
            var faces = new List<Face>()
            {
                Face.Ace,
                Face.Two,
                Face.Three,
                Face.Four,
                Face.Five,
                Face.Six,
                Face.Seven,
                Face.Eight,
                Face.Nine,
                Face.Ten,
                Face.Jack,
                Face.Queen,
                Face.King
            };

            foreach (Suit suit in suits)
            {
                foreach (Face face in faces)
                {
                    cards.Add(new PlayingCard() { Suit = suit, Face = face });
                }
            }
            return cards;
        }
        public static void Shuffle(this IList<PlayingCard> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                PlayingCard value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
