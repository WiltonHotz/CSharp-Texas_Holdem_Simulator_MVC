using Spela_Ett_Kortspel_Viktor_Hoerwing.Participants;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public abstract class Participant
    {
        public int Id { get; set; } = 0;
        public string Name { get; private set; }
        public List<PlayingCard> Cards { get; set; }
        public List<PlayingCard> TwoCardHand { get; set; }
        public Hand Hand { get; set; }
        public string SevenCardHandShortHandSyntax { get; set; }
        public string TwoCardHandShortHandSyntax { get; set; }
        public string CopyOfTableHandShortHandSyntax { get; set; }
        public string CopyTableHTML { get; set; }
        public string TwoCardHTML { get; set; }
        public Participant(string name, PlayingCardDeck deck, int numberOfCards, int id)
        {
            Id = id;
            Name = name;
            Cards = Deal.DealNCards(deck, numberOfCards);
            TwoCardHand = new List<PlayingCard>(Cards);
        }
        public void GetHand(Table table)
        {
            Hand hand = new Hand(this, table);
            Hand = hand;
            TwoCardHandShortHandSyntax = Hand.GetShortHandSyntax(TwoCardHand);
            SevenCardHandShortHandSyntax = Hand.GetShortHandSyntax(Cards);
            CopyOfTableHandShortHandSyntax = Hand.GetShortHandSyntax(table.Cards);
            CopyTableHTML = Hand.ImageBuilder(CopyOfTableHandShortHandSyntax);
            TwoCardHTML = Hand.ImageBuilder(TwoCardHandShortHandSyntax);
            Judge.AllParticipants.Add(this);
        }
    }
}
