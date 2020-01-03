using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public class PlayingCard : IEqualityComparer<PlayingCard>
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public bool Equals([AllowNull] PlayingCard x, [AllowNull] PlayingCard y)
        {
            return x.Suit == y.Suit && x.Face == y.Face;
        }

        public int GetHashCode([DisallowNull] PlayingCard obj)
        {
            return obj.GetHashCode();
        }

        public override string ToString() => $"{Face} of {Suit}";
    }
}
