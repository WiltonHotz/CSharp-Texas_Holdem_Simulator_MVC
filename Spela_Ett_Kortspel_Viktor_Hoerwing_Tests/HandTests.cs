using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Participants;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class HandTests
    {
        public (Participant, PlayingCardDeck) GetPlayerWithSevenCardHand()
        {
            var deck = new PlayingCardDeck();
            Participant player = new Player("Tester", deck, 2, 0);
            Table table = new Table("TableTester", deck, 5, 0);
            Judge judge = new Judge();
            player.GetHand(table);

            return (player, deck);
        }
        [Fact]
        public void PlayerCanGetSevenCardHand()
        {
            // arrange
            int expectedNumberOfCards = 7;
            int expectedDeckCount = 45;

            // act
            var (player, deck) = GetPlayerWithSevenCardHand();

            // assert
            Assert.Equal(expectedNumberOfCards, player.Hand.SevenCardHand.Count);
            Assert.Equal(expectedDeckCount, deck.Cards.Count);
        }
    }
}
