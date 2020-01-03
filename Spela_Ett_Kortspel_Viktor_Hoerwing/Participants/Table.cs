using System;
using System.Collections.Generic;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Participants
{
    public class Table : Participant
    {
        public Table(string name, PlayingCardDeck deck, int numberOfCards, int id) : base(name, deck, numberOfCards, id)
        {
        }
    }
}
