using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public static class HandRank
    {
        // ---------------------------- HELPER METHODS ----------------------------------------//
        #region Helper Methods
        public static IOrderedEnumerable<KeyValuePair<Face, int>> FaceCounter(List<PlayingCard> sevenCardHand)
        {
            var dict = new Dictionary<Face, int>();
            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                var faceCount = sevenCardHand.Count(c => c.Face == face);
                if (faceCount != 0)
                {
                    dict.Add(face, faceCount);
                }
            }
            return dict.OrderByDescending(c => c.Value).ThenByDescending(c => c.Key);
        }

        public static IOrderedEnumerable<KeyValuePair<Suit, int>> SuitCounter(List<PlayingCard> sevenCardHand)
        {
            var dict = new Dictionary<Suit, int>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                var suitCount = sevenCardHand.Count(c => c.Suit == suit);
                if (suitCount != 0)
                {
                    dict.Add(suit, suitCount);
                }
            }
            return dict.OrderByDescending(c => c.Value).ThenByDescending(c => c.Key);
        }
        #endregion
        // ---------------------------- HAND RANKS --------------------------------------------//
        #region Return Hand Ranks
        public static bool HasOnePair(List<PlayingCard> sevenCardHand)
            => FaceCounter(sevenCardHand).Where(c => c.Value == 2).Count() == 1;
        public static bool HasTwoPair(List<PlayingCard> sevenCardHand)
            => FaceCounter(sevenCardHand).Where(c => c.Value == 2).Count() >= 2;
        public static bool HasThreeOfAKind(List<PlayingCard> sevenCardHand)
            => FaceCounter(sevenCardHand).Where(c => c.Value == 3).Count() == 1;
        public static bool HasStraight(List<PlayingCard> sevenCardHand)
        {
            var hand = sevenCardHand.OrderByDescending(c => c.Face).ThenBy(c => c.Suit).Distinct(new DistinctFaceComparer()).ToList();
            var sFinder = 0;
            for (int i = 0; i < hand.Count - 1; i++)
            {
                if ((int)hand[i].Face == (int)hand[i + 1].Face + 1)
                {
                    sFinder++;
                }
                else
                {
                    sFinder = 0;
                }
                if (sFinder == 4)
                {
                    return true;
                }
            }

            return hand.Where(c => c.Face == Face.Ace).Count() == 1
                && hand.Where(c => c.Face == Face.Two).Count() == 1
                && hand.Where(c => c.Face == Face.Three).Count() == 1
                && hand.Where(c => c.Face == Face.Four).Count() == 1
                && hand.Where(c => c.Face == Face.Five).Count() == 1
            ? true
            : false;
        }
        public static bool HasFlush(List<PlayingCard> sevenCardHand)
            => SuitCounter(sevenCardHand).Where(c => c.Value >= 5).Count() == 1;
        public static bool HasFullHouse(List<PlayingCard> sevenCardHand)
            => FaceCounter(sevenCardHand).Where(c => c.Value == 3).Count() >= 2
            || FaceCounter(sevenCardHand).Where(c => c.Value == 3).Count() == 1
            && FaceCounter(sevenCardHand).Where(c => c.Value == 2).Count() >= 1;

        public static bool HasFourOfAKind(List<PlayingCard> sevenCardHand)
            => FaceCounter(sevenCardHand).Where(c => c.Value == 4).Count() == 1;

        public static bool HasStraightFlush(List<PlayingCard> sevenCardHand)
        {
            if(HasFlush(sevenCardHand) && HasStraight(sevenCardHand))
            {
                var suitCounter = SuitCounter(sevenCardHand);
                Suit suit = suitCounter.Where(c => c.Value >= 5).Select(c => c.Key).First();

                var hand = sevenCardHand.Where(c => c.Suit == suit).OrderByDescending(c => c.Face).ToList();

                return HasStraight(hand);
            }
            return false;
        }
        public static bool HasRoyalFlush(List<PlayingCard> sevenCardHand)
        {
            if (HasFlush(sevenCardHand) && HasStraight(sevenCardHand))
            {
                var suitCounter = SuitCounter(sevenCardHand);
                Suit suit = suitCounter.Where(c => c.Value >= 5).Select(c => c.Key).First();

                var hand = sevenCardHand.Where(c => c.Suit == suit).OrderByDescending(c => c.Face).ToList();
                if (hand[0].Face == Face.Ace && hand[0].Suit == suit
                    && hand[1].Face == Face.King && hand[1].Suit == suit
                    && hand[2].Face == Face.Queen && hand[2].Suit == suit
                    && hand[3].Face == Face.Jack && hand[3].Suit == suit
                    && hand[4].Face == Face.Ten && hand[4].Suit == suit)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        // ---------------------------- HANDS -------------------------------------------------//
        #region Return Hands
        public static List<PlayingCard> ReturnHighCardHand(List<PlayingCard> sevenCardHand, int numberOfCards)
            => sevenCardHand.OrderByDescending(c => c.Face).Take(numberOfCards).ToList();

        public static List<PlayingCard> ReturnOfAKindHand(List<PlayingCard> sevenCardHand, int ofAKind)
        {
            var faceCounter = FaceCounter(sevenCardHand);
            var lookForValue = faceCounter.Where(c => c.Value == ofAKind);
            var lookForValueCount = lookForValue.Count();
            var hand = new List<PlayingCard>();
            var nph = new List<PlayingCard>();

            Expression<Func<PlayingCard, bool>> first = c => c.Face == faceCounter.Where(c => c.Value == ofAKind).Select(c => c.Key).First();
            Expression<Func<PlayingCard, bool>> skipFirst = c => c.Face == faceCounter.Where(c => c.Value == ofAKind).Select(c => c.Key).Skip(1).First();


            switch (ofAKind)
            {
                case 2:
                    switch (lookForValueCount)
                    {
                        case 1:
                            hand = sevenCardHand.Where(first.Compile()).OrderByDescending(c => c.Suit).ToList();
                            nph = ReturnHighCardHand(sevenCardHand.Except(hand).ToList(), 3);
                            hand.AddRange(nph);
                            break;
                        case 2:
                        case 3:
                            hand = sevenCardHand.Where(first.Compile()).OrderByDescending(c => c.Suit).ToList();
                            var h2 = sevenCardHand.Where(skipFirst.Compile()).OrderByDescending(c => c.Suit).ToList();
                            hand.AddRange(h2);
                            nph = ReturnHighCardHand(sevenCardHand.Except(hand).ToList(), 1);
                            hand.AddRange(nph);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (lookForValueCount)
                    {
                        case 1:
                            hand = sevenCardHand.Where(first.Compile()).OrderByDescending(c => c.Suit).ToList();

                            var lookForValue2 = faceCounter.Where(c => c.Value == 2);
                            var lookForValue2Count = lookForValue2.Count();
                            if (lookForValue2Count >= 1)
                            {
                                nph = sevenCardHand.Where(c => c.Face == faceCounter.Where(c => c.Value == 2).Select(c => c.Key).First()).OrderByDescending(c => c.Suit).ToList();
                            }
                            else
                            {
                                nph = ReturnHighCardHand(sevenCardHand.Except(hand).ToList(), 2);
                            }
                            hand.AddRange(nph);
                            break;
                        case 2:
                            hand = sevenCardHand.Where(first.Compile()).OrderByDescending(c => c.Suit).ToList();
                            var h2 = sevenCardHand.Where(skipFirst.Compile()).OrderByDescending(c => c.Suit).ToList();
                            hand.AddRange(h2.Take(2));
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    hand = sevenCardHand.Where(first.Compile()).OrderByDescending(c => c.Suit).ToList();
                    nph = ReturnHighCardHand(sevenCardHand.Except(hand).ToList(), 1);
                    hand.AddRange(nph);
                    break;
                default:
                    break;
            }
            return hand;
        }
        public static List<PlayingCard> ReturnStraightHand(List<PlayingCard> sevenCardHand)
        {
            var hand = sevenCardHand.OrderByDescending(c => c.Face).Distinct(new DistinctFaceComparer()).ToList();
            var straightHand = new List<PlayingCard>();
            for (int i = 0; i < hand.Count-1; i++)
            {
                if((int)hand[i].Face == (int)hand[i+1].Face + 1)
                {
                    straightHand.Add(hand[i]);
                    straightHand.Add(hand[i + 1]);
                    straightHand = straightHand.Distinct(new DistinctFaceComparer()).ToList();
                    if (straightHand.Count == 5)
                    {
                        straightHand = straightHand.OrderByDescending(c => c.Face).ToList();
                        return straightHand;
                    }
                }
                else
                {
                    straightHand = new List<PlayingCard>();
                }
            }
            return hand.Where(c =>
            c.Face == Face.Ace
            || c.Face == Face.Two
            || c.Face == Face.Three
            || c.Face == Face.Four
            || c.Face == Face.Five)
                .Select(c => c)
                .OrderByDescending(c => c.Face).ToList();
        }
        public static List<PlayingCard> ReturnFlushHand(List<PlayingCard> sevenCardHand)
        {
            var suitCounter = SuitCounter(sevenCardHand);
            Suit suit = suitCounter.Where(c => c.Value >= 5).Select(c => c.Key).First();
            var flushHand = sevenCardHand.Where(c => c.Suit == suit).OrderByDescending(c => c.Face).Take(5).ToList();
            return flushHand;
        }
        #endregion

        public static Rank GetRank(List<PlayingCard> sevenCardHand) =>
            HasRoyalFlush(sevenCardHand)
            ? Rank.RoyalFlush
            : HasStraightFlush(sevenCardHand)
            ? Rank.StraightFlush
            : HasFourOfAKind(sevenCardHand)
            ? Rank.FourOfAKind
            : HasFullHouse(sevenCardHand)
            ? Rank.FullHouse
            : HasFlush(sevenCardHand)
            ? Rank.Flush
            : HasStraight(sevenCardHand)
            ? Rank.Straight
            : HasThreeOfAKind(sevenCardHand)
            ? Rank.ThreeOfAKind
            : HasTwoPair(sevenCardHand)
            ? Rank.TwoPair
            : HasOnePair(sevenCardHand)
            ? Rank.OnePair
            : Rank.HighCard;

        public static List<PlayingCard> GetHand(List<PlayingCard> sevenCardHand, Rank rank)
        {
            var hand = new List<PlayingCard>();
            switch (rank)
            {
                case Rank.HighCard:
                    hand = ReturnHighCardHand(sevenCardHand, 5);
                    break;
                case Rank.OnePair:
                    hand = ReturnOfAKindHand(sevenCardHand, 2);
                    break;
                case Rank.TwoPair:
                    hand = ReturnOfAKindHand(sevenCardHand, 2);
                    break;
                case Rank.ThreeOfAKind:
                    hand = ReturnOfAKindHand(sevenCardHand, 3);
                    break;
                case Rank.Straight:
                    hand = ReturnStraightHand(sevenCardHand);
                    break;
                case Rank.Flush:
                    hand = ReturnFlushHand(sevenCardHand);
                    break;
                case Rank.FullHouse:
                    hand = ReturnOfAKindHand(sevenCardHand, 3);
                    break;
                case Rank.FourOfAKind:
                    hand = ReturnOfAKindHand(sevenCardHand, 4);
                    break;
                case Rank.StraightFlush:
                case Rank.RoyalFlush:
                    hand = ReturnFlushHand(sevenCardHand);
                    hand = ReturnStraightHand(hand);
                    break;
                default:
                    hand = ReturnHighCardHand(sevenCardHand, 5);
                    break;
            }
            return hand;
        }
    }
}
