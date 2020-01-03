using System;
using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Participants;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CanCreatePlayer()
        {
            // arrange
            var deck = new PlayingCardDeck();
            var name = "Viktor";
            var numberOfCards = 2;
            var id = 0;

            // act
            Participant player = new Player("Viktor", deck, 2, 0);

            // assert
            Assert.NotNull(player);
            Assert.Equal(name, player.Name);
            Assert.Equal(numberOfCards, player.Cards.Count);
            Assert.Equal(id, player.Id);
        }
        [Fact]
        public void CanCreateTable()
        {
            // arrange
            var deck = new PlayingCardDeck();
            var name = "Table";
            var numberOfCards = 5;
            var id = 0;

            // act
            Participant table = new Table("Table", deck, 5, 0);

            // assert
            Assert.NotNull(table);
            Assert.Equal(name, table.Name);
            Assert.Equal(numberOfCards, table.Cards.Count);
            Assert.Equal(id, table.Id);
        }
        [Fact]
        public void CardsAreRemovedFromDeckWhenAddingMultipleOpponents()
        {
            // arrange
            var deck = new PlayingCardDeck();
            int id = 0;
            int expectedId = 6;
            int expectedCardsLeft = 35;

            // act
            Participant player = new Player("player", deck, 2, 0);
            for (int i = 1; i <= 5; i++)
            {
                id = i;
                Participant opponent = new Player("opponent", deck, 2, id);
            }
            Participant table = new Table("table", deck, 5, ++id);

            // assert
            Assert.Equal(expectedId, table.Id);
            Assert.Equal(expectedCardsLeft, deck.Cards.Count);
        }
    }
}
