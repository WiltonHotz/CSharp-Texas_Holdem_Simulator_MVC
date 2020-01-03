using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Utils
{
    public static class JudgeExtensions
    {
        public static IOrderedEnumerable<Participant> JudgeGroup(this IGrouping<Rank, Participant> group)
        {
            switch (group.Key)
            {
                case Rank.HighCard:
                default:
                    return
                        group.OrderByDescending(c => c.Hand.H1)
                        .ThenByDescending(c => c.Hand.H2)
                        .ThenByDescending(c => c.Hand.H3)
                        .ThenByDescending(c => c.Hand.H4)
                        .ThenByDescending(c => c.Hand.H5);
                case Rank.OnePair:
                    return
                        group.OrderByDescending(c => c.Hand.PairValue1)
                        .ThenByDescending(c => c.Hand.H3)
                        .ThenByDescending(c => c.Hand.H4)
                        .ThenByDescending(c => c.Hand.H5);
                case Rank.TwoPair:
                    return
                        group.OrderByDescending(c => c.Hand.PairValue1)
                        .ThenByDescending(c => c.Hand.PairValue2)
                        .ThenByDescending(c => c.Hand.H5);
                case Rank.ThreeOfAKind:
                    return
                        group.OrderByDescending(c => c.Hand.PairValue1)
                        .ThenByDescending(c => c.Hand.H4)
                        .ThenByDescending(c => c.Hand.H5);
                case Rank.FullHouse:
                    return
                        group.OrderByDescending(c => c.Hand.PairValue1)
                        .ThenByDescending(c => c.Hand.PairValue2);
                case Rank.FourOfAKind:
                    return
                        group.OrderByDescending(c => c.Hand.PairValue1)
                        .ThenByDescending(c => c.Hand.H5);
                case Rank.Straight:
                case Rank.StraightFlush:
                case Rank.RoyalFlush:
                    return
                        group.OrderByDescending(c => c.Hand.H1);
            }
        }
    }
}
