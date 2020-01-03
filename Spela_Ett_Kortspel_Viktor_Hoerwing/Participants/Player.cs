using System;
using System.Collections.Generic;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Participants
{
    public class Player : Participant
    {
        public Player(string name, PlayingCardDeck deck, int numberOfCards, int id) : base(name, deck, numberOfCards, id)
        {
        }
    }
}
