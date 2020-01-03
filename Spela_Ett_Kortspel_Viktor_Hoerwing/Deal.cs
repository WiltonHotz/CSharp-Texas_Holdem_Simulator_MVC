using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public static class Deal
    {
        public static List<PlayingCard> DealNCards(PlayingCardDeck deck, int count)
        {
            var dealtCards = new List<PlayingCard>();
            for (int i = 0; i < count; i++)
            {
                PlayingCard temp = deck.Cards[deck.Cards.Count-1];
                dealtCards.Add(temp);
                deck.Cards.Remove(temp);
            }
            return dealtCards;
        }
        public static void AddCardToBottom(PlayingCardDeck deck, PlayingCard card) => deck.Cards.Insert(0, card);
    }
}
