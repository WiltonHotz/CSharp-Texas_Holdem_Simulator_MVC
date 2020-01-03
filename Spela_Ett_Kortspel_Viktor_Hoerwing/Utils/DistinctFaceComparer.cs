using System;
using System.Collections.Generic;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Utils
{
    public class DistinctFaceComparer : IEqualityComparer<PlayingCard>
    {
        public bool Equals(PlayingCard x, PlayingCard y)
        {
            return x.Face == y.Face;
        }

        public int GetHashCode(PlayingCard obj)
        {
            return obj.Face.GetHashCode();
        }
    }
}
