using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class DealTests
    {
        [Fact]
        public void CardIsRemovedFromDeckWhenDealt()
        {
            // arrange
            int expectedCount = 51;
            var deck = new PlayingCardDeck();
            bool cardIsRemoved = true;
            var dealtCard = Deal.DealNCards(deck, 1).Single();

            // act
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                if (deck.Cards[i] == dealtCard)
                {
                    cardIsRemoved = false;
                }
            }

            // assert
            Assert.True(cardIsRemoved);
            Assert.Equal(expectedCount, deck.Cards.Count);
        }
        [Fact]
        public void CanAddCardToBottomOfDeck()
        {
            // arrange
            var deck = new PlayingCardDeck();
            var expectedNewQueueDeckCount = 53;
            var card = new PlayingCard { Face = Face.Ace, Suit = Suit.Spades };

            // act
            Deal.AddCardToBottom(deck, card);

            // assert
            Assert.Equal(Suit.Spades, deck.Cards[0].Suit);
            Assert.Equal(Face.Ace, deck.Cards[0].Face);
            Assert.Equal(expectedNewQueueDeckCount, deck.Cards.Count);
        }
    }
}
