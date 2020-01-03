using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using Xunit;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class DeckTests
    {
        [Fact]
        public void CanCreate52Cards()
        {
            // arrange
            int expectedDeckCount = 52;

            // act
            PlayingCardDeck deck = new PlayingCardDeck();

            // assert
            Assert.Equal(expectedDeckCount, deck.Cards.Count);
        }
        [Fact]
        public void TwoDecksWillHaveSameCardOrderUnshuffled()
        {
            // arrange
            bool isSame = true;
            var orderedCardsList = new List<PlayingCard>();
            orderedCardsList.Initiate();
            var anotherOrderedCardsList = new List<PlayingCard>();
            anotherOrderedCardsList.Initiate();

            // act
            for (int i = 0; i < orderedCardsList.Count; i++)
            {
                if (orderedCardsList[i].Suit != anotherOrderedCardsList[i].Suit
                    || orderedCardsList[i].Face != anotherOrderedCardsList[i].Face)
                {
                    isSame = false;
                }
            }

            // assert
            Assert.Equal(52, orderedCardsList.Count);
            Assert.Equal(52, anotherOrderedCardsList.Count);
            Assert.True(isSame);
        }
        [Fact]
        public void TwoShuffledDecksWillNotBeTheSame()
        {
            // arrange
            bool isSame = true;
            PlayingCardDeck deck = new PlayingCardDeck();
            PlayingCardDeck anotherDeck = new PlayingCardDeck();

            // act
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                    if (deck.Cards[i].Suit != anotherDeck.Cards[i].Suit
                    || deck.Cards[i].Face != anotherDeck.Cards[i].Face)
                    {
                        isSame = false;
                    }
            }

            // assert
            Assert.False(isSame);
            Assert.Equal(52, deck.Cards.Count);
            Assert.Equal(52, anotherDeck.Cards.Count);
        }
    }
}
