using Spela_Ett_Kortspel_Viktor_Hoerwing.Participants;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public class Hand
    {
        public List<PlayingCard> SevenCardHand { get; set; }
        public Rank Rank { get; set; }
        public List<PlayingCard> BestFiveCardHand { get; set; }
        public int H1 { get; set; }
        public int H2 { get; set; }
        public int H3 { get; set; }
        public int H4 { get; set; }
        public int H5 { get; set; }
        public int PairValue1 { get; set; }
        public int PairValue2 { get; set; }
        public string HandDescription { get; set; }
        public string ShortHandSyntax { get; set; }
        public string HTMLSHS { get; set; }
        public Hand(Participant participant, Table table)
        {
            var tempParticipantCards = participant.Cards;
            var tempTableCards = table.Cards;
            tempParticipantCards.AddRange(tempTableCards);

            SevenCardHand = new List<PlayingCard>(tempParticipantCards.OrderByDescending(c => c.Face));
            Rank = HandRank.GetRank(SevenCardHand);
            BestFiveCardHand = new List<PlayingCard>(HandRank.GetHand(SevenCardHand, Rank));
            HandDescription = GetHandDescription(BestFiveCardHand);
            ShortHandSyntax = GetShortHandSyntax(BestFiveCardHand);
            HTMLSHS = ImageBuilder(ShortHandSyntax);
            GetHandValue();
        }
        public static string ImageBuilder(string input)
        {
            input = input.ToUpper();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length-1; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append("<img src=\"/images/");
                    sb.Append(input[i]);
                    sb.Append(input[i+1]);
                    sb.Append($".jpg\" alt=\"{input[i]}{input[i+1]}\" />");
                }
            }
            return sb.ToString();
        }
        private string GetShortFace(Face face)
        {
            switch(face)
            {
                case Face.Two:
                default:
                    return "2";
                case Face.Three:
                    return "3";
                case Face.Four:
                    return "4";
                case Face.Five:
                    return "5";
                case Face.Six:
                    return "6";
                case Face.Seven:
                    return "7";
                case Face.Eight:
                    return "8";
                case Face.Nine:
                    return "9";
                case Face.Ten:
                    return "T";
                case Face.Jack:
                    return "J";
                case Face.Queen:
                    return "Q";
                case Face.King:
                    return "K";
                case Face.Ace:
                    return "A";
            }
        }
        public string GetShortHandSyntax(List<PlayingCard> hand)
        {
            string shortHand = "";
            foreach (var card in hand)
            {
                shortHand += GetShortFace(card.Face);
                int s = (int)card.Suit;
                ShortHandSuit shs = (ShortHandSuit)s;
                shortHand += shs.ToString();
            }
            return shortHand;
        }

        public string GetHandDescription(List<PlayingCard> hand)
        {
            switch (Rank)
            {
                case Rank.HighCard:
                default:
                    return $"{Rank}, {hand.First().Face} high";
                case Rank.OnePair:
                    return $"{Rank}, {hand.First().Face}s";
                case Rank.TwoPair:
                    return $"{Rank}, {hand.First().Face}s and {hand.Skip(2).First().Face}s";
                case Rank.ThreeOfAKind:
                    return $"{Rank}, {hand.First().Face}s";
                case Rank.Straight:
                    if (hand.Skip(1).First().Face == Face.Five)
                    {
                        return $"{Rank}, {hand.First().Face} through {hand.Skip(1).First().Face}";
                    }
                    else
                    {
                        return $"{Rank}, {hand.First().Face} high";
                    }
                case Rank.Flush:
                    return $"{Rank} ({hand.First().Suit}), {hand.First().Face} high";
                case Rank.FullHouse:
                    return $"{Rank}, {hand.First().Face}s over {hand.Skip(3).First().Face}s";
                case Rank.FourOfAKind:
                    return $"{Rank}, {hand.First().Face}s";
                case Rank.StraightFlush:
                    if (hand.Skip(1).First().Face == Face.Five)
                    {
                        return $"{Rank} ({hand.First().Suit}), {hand.First().Face} through {hand.Skip(1).First().Face}";
                    }
                    return $"{Rank} ({hand.First().Suit}), {hand.First().Face} high";
                case Rank.RoyalFlush:
                    return $"{Rank} ({hand.First().Suit})";
            }
        }

        public void GetHandValue()
        {
            switch (Rank)
            {
                case Rank.HighCard:
                case Rank.Flush:
                default:
                    H1 = (int)BestFiveCardHand.ElementAt(0).Face;
                    H2 = (int)BestFiveCardHand.ElementAt(1).Face;
                    H3 = (int)BestFiveCardHand.ElementAt(2).Face;
                    H4 = (int)BestFiveCardHand.ElementAt(3).Face;
                    H5 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
                case Rank.OnePair:
                    PairValue1 = BestFiveCardHand.Take(2).Sum(c => (int)c.Face);
                    H3 = (int)BestFiveCardHand.ElementAt(2).Face;
                    H4 = (int)BestFiveCardHand.ElementAt(3).Face;
                    H5 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
                case Rank.TwoPair:
                    PairValue1 = BestFiveCardHand.Take(2).Sum(c => (int)c.Face);
                    PairValue2 = BestFiveCardHand.Skip(2).Take(2).Sum(c => (int)c.Face);
                    H5 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
                case Rank.ThreeOfAKind:
                    PairValue1 = BestFiveCardHand.Take(3).Sum(c => (int)c.Face);
                    H4 = (int)BestFiveCardHand.ElementAt(3).Face;
                    H5 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
                case Rank.FullHouse:
                    PairValue1 = BestFiveCardHand.Take(3).Sum(c => (int)c.Face);
                    PairValue2 = BestFiveCardHand.Skip(3).Take(2).Sum(c => (int)c.Face);
                    break;
                case Rank.FourOfAKind:
                    PairValue1 = BestFiveCardHand.Take(4).Sum(c => (int)c.Face);
                    H5 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
                case Rank.Straight:
                case Rank.StraightFlush:
                case Rank.RoyalFlush:
                    H1 = (int)BestFiveCardHand.ElementAt(4).Face;
                    break;
            }
        }
    }
}
