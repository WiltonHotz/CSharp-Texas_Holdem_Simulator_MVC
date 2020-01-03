using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public class PlayingCardDeck
    {
        public List<PlayingCard> Cards { get; private set; }

        public PlayingCardDeck()
        {
            var cards = new List<PlayingCard>();
            cards.Initiate();
            cards.Shuffle();
            Cards = cards;
        }
    }
}
