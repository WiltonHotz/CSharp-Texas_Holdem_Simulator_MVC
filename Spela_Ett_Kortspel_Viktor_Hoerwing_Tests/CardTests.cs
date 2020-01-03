using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using Xunit;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreatePlayingCard()
        {
            // arrange
            var face = Face.Ace;
            var suit = Suit.Spades;

            // act
            var card = new PlayingCard { Face = Face.Ace, Suit = Suit.Spades };

            // assert
            Assert.Equal(face, card.Face);
            Assert.Equal(suit, card.Suit);
        }
        [Fact]
        public void CanDescribeCard()
        {
            // arrange
            var face = Face.Ace;
            var suit = Suit.Spades;
            string expectedDescription = "Ace of Spades";

            // act
            var card = new PlayingCard { Face = face, Suit = suit };

            // assert
            Assert.Equal(expectedDescription, card.ToString());
        }
    }
}