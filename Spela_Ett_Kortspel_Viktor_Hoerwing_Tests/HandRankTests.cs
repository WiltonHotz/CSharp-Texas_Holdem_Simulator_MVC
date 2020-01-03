using Spela_Ett_Kortspel_Viktor_Hoerwing;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing_Tests
{
    public class HandRankTests
    {
        #region HighCard
        [Fact]
        public void CanGetHighCardHand()
        {
            // arrange
            var cards = GetHighCardHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.HighCard);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        #endregion
        #region HasOfAKind
        [Fact]
        public void HasOfAKindReturnsTrueAndFalseCorrectly()
        {
            // arrange
            var noPairCards = GetHighCardHand();
            var pairCards = GetOnePairHand();
            var threeOfAKindsCards = GetThreeOfAKindHand();

            // act
            var noPairCardsReturnsFalseOnPair = HandRank.HasOnePair(noPairCards);
            var pairCardsReturnsTrueOnPair = HandRank.HasOnePair(pairCards);
            var pairCardsReturnsFalseOnThreeOfAKind = HandRank.HasThreeOfAKind(pairCards);
            var threeOfAKindsCardsReturnsTrueOnthreeOfAKind = HandRank.HasThreeOfAKind(threeOfAKindsCards);
            var threeOfAKindsCardsReturnsFalseOnPair = HandRank.HasOnePair(threeOfAKindsCards);


            // assert
            Assert.False(noPairCardsReturnsFalseOnPair);
            Assert.False(pairCardsReturnsFalseOnThreeOfAKind);
            Assert.True(pairCardsReturnsTrueOnPair);
            Assert.True(threeOfAKindsCardsReturnsTrueOnthreeOfAKind);
            Assert.False(threeOfAKindsCardsReturnsFalseOnPair);
        }
        [Fact]
        public void CanGetOnePairRank()
        {
            // arrange
            var cards = GetOnePairHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.OnePair, rank);
        }

        [Fact]
        public void CanGetOnePairHand()
        {
            // arrange
            var cards = GetOnePairHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.OnePair);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetTwoPairRank()
        {
            // arrange
            var cards = GetTwoPairHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.TwoPair, rank);
        }

        [Fact]
        public void CanGetTwoPairHand()
        {
            // arrange
            var cards = GetTwoPairHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.TwoPair);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetFuckedTwoPairRank()
        {
            // arrange
            var cards = GetFuckedTwoPairHand().OrderByDescending(c => c.Face).ToList();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.TwoPair, rank);
        }

        [Fact]
        public void CanGetFuckedTwoPairHand()
        {
            // arrange
            var cards = GetFuckedTwoPairHand().OrderByDescending(c => c.Face).ToList();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
        };

            // act
            var hand = HandRank.GetHand(cards, Rank.TwoPair);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetThreeOfAKindRank()
        {
            // arrange
            var cards = GetThreeOfAKindHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.ThreeOfAKind, rank);
        }

        [Fact]
        public void CanGetThreeOfAKindHand()
        {
            // arrange
            var cards = GetThreeOfAKindHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.ThreeOfAKind);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        [Fact]
        public void CanGetFullHouseRank()
        {
            // arrange
            var cards = GetFullHouseHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.FullHouse, rank);
        }

        [Fact]
        public void CanGetFullHouseHand()
        {
            // arrange
            var cards = GetFullHouseHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.FullHouse);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetFuckedFullHouseRank()
        {
            // arrange
            var cards = GetFullHouseHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.FullHouse, rank);
        }

        [Fact]
        public void CanGetFuckedFullHouseHand()
        {
            // arrange
            var cards = GetFuckedFullHouseHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.FullHouse);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetFourOfAKindRank()
        {
            // arrange
            var cards = GetFourOfAKindHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.FourOfAKind, rank);
        }

        [Fact]
        public void CanGetFourOfAKindHand()
        {
            // arrange
            var cards = GetFourOfAKindHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.FourOfAKind);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        #endregion
        #region Straights
        [Fact]
        public void CanGetNormalStraightRank()
        {
            // arrange
            var cards = GetNormalStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetNormalStraightHand()
        {
            // arrange
            var cards = GetNormalStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetAceHighStraightRank()
        {
            // arrange
            var cards = GetAceHighStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetAceHighStraightHand()
        {
            // arrange
            var cards = GetAceHighStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Diamonds}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }

        [Fact]
        public void CanGetAceLowStraightRank()
        {
            // arrange
            var cards = GetAceLowStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetAceLowStraightHand()
        {
            // arrange
            var cards = GetAceLowStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        [Fact]
        public void CanGetFuckedNormalStraightRank()
        {
            // arrange
            var cards = GetFuckedNormalStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetFuckedNormalStraightHand()
        {
            // arrange
            var cards = GetFuckedNormalStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new DistinctFaceComparer());
        }

        [Fact]
        public void CanGetFuckedAceHighStraightRank()
        {
            // arrange
            var cards = GetFuckedAceHighStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetFuckedAceHighStraightHand()
        {
            // arrange
            var cards = GetFuckedAceHighStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Diamonds}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new DistinctFaceComparer());
        }

        [Fact]
        public void CanGetFuckedAceLowStraightRank()
        {
            // arrange
            var cards = GetFuckedAceLowStraightHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Straight, rank);
        }

        [Fact]
        public void CanGetFuckedAceLowStraightHand()
        {
            // arrange
            var cards = GetFuckedAceLowStraightHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Straight);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        [Fact]
        public void CanNotGetFourCardStraightHand()
        {
            // arrange
            var normalFourCardStraight = GetFourCardNormalStraightHand();
            var aceHighFourCardStraight = GetFourCardAceHighStraightHand();
            var aceLowFourCardStraight = GetFourCardAceLowStraightHand();

            // act
            var nrank = HandRank.GetRank(normalFourCardStraight);
            var ahrank = HandRank.GetRank(aceHighFourCardStraight);
            var alrank = HandRank.GetRank(aceLowFourCardStraight);

            // assert
            Assert.NotEqual(Rank.Straight, nrank);
            Assert.NotEqual(Rank.Straight, ahrank);
            Assert.NotEqual(Rank.Straight, alrank);
        }
        #endregion
        #region Flushes
        [Fact]
        public void CanGetFlushRank()
        {
            // arrange
            var cards = GetFlushHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Flush, rank);
        }

        [Fact]
        public void CanGetFlushHand()
        {
            // arrange
            var cards = GetFlushHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Flush);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        [Fact]
        public void CanGetFuckedFlushRank()
        {
            // arrange
            var cards = GetFuckedFlushHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.Flush, rank);
        }

        [Fact]
        public void CanGetFuckedFlushHand()
        {
            // arrange
            var cards = GetFuckedFlushHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.Flush);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        #endregion
        #region Straight Flushes
        [Fact]
        public void CanGetStraightFlushRank()
        {
            // arrange
            var sfcards = GetNormalStraightFlushHand();
            var alsfcards = GetAceLowStraightFlushHand();

            // act
            var sfrank = HandRank.GetRank(sfcards);
            var alsfrank = HandRank.GetRank(alsfcards);

            // assert
            Assert.Equal(Rank.StraightFlush, sfrank);
            Assert.Equal(Rank.StraightFlush, alsfrank);
        }

        [Fact]
        public void CanGetStraightFlushHand()
        {
            // arrange
            var sfcards = GetNormalStraightFlushHand();
            var alsfcards = GetAceLowStraightFlushHand();
            var expectedHandCount = 5;
            var expectedSFHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades}
            };
            var expectedALSFHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades}
            };

            // act
            var sfhand = HandRank.GetHand(sfcards, Rank.StraightFlush);
            var alsfhand = HandRank.GetHand(alsfcards, Rank.StraightFlush);

            // assert
            Assert.Equal(expectedHandCount, sfhand.Count);
            Assert.Equal(expectedHandCount, alsfhand.Count);
            Assert.Equal(expectedSFHand, sfhand, new PlayingCard());
            Assert.Equal(expectedALSFHand, alsfhand, new PlayingCard());
        }

        [Fact]
        public void CanGetRoyalFlushRank()
        {
            // arrange
            var cards = GetRoyalStraightFlushHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.RoyalFlush, rank);        }

        [Fact]
        public void CanGetRoyalFlushHand()
        {
            // arrange
            var cards = GetRoyalStraightFlushHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.RoyalFlush);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        [Fact]
        public void CanGetSuitConflictStraightFlushRank()
        {
            // arrange
            var sfcards = GetNormalStraightFlushSuitConflictHand();
            var alsfcards = GetAceLowStraightFlushSuitConflictHand();

            // act
            var sfrank = HandRank.GetRank(sfcards);
            var alsfrank = HandRank.GetRank(alsfcards);

            // assert
            Assert.Equal(Rank.StraightFlush, sfrank);
            Assert.Equal(Rank.StraightFlush, alsfrank);
        }

        [Fact]
        public void CanGetSuitConflictStraightFlushHand()
        {
            // arrange
            var sfcards = GetNormalStraightFlushSuitConflictHand();
            var alsfcards = GetAceLowStraightFlushSuitConflictHand();
            var expectedHandCount = 5;
            var expectedSFHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.King, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Hearts}
            };
            var expectedALSFHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Hearts}
            };

            // act
            var sfhand = HandRank.GetHand(sfcards, Rank.StraightFlush);
            var alsfhand = HandRank.GetHand(alsfcards, Rank.StraightFlush);

            // assert
            Assert.Equal(expectedHandCount, sfhand.Count);
            Assert.Equal(expectedHandCount, alsfhand.Count);
            Assert.Equal(expectedSFHand, sfhand, new PlayingCard());
            Assert.Equal(expectedALSFHand, alsfhand, new PlayingCard());
        }

        [Fact]
        public void CanGetSuitConflictRoyalFlushRank()
        {
            // arrange
            var cards = GetRoyalSuitConflictHand();

            // act
            var rank = HandRank.GetRank(cards);

            // assert
            Assert.Equal(Rank.RoyalFlush, rank);
        }

        [Fact]
        public void CanGetSuitConflictRoyalFlushHand()
        {
            // arrange
            var cards = GetRoyalSuitConflictHand();
            var expectedHandCount = 5;
            var expectedHand = new List<PlayingCard>
            {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.King, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Hearts}
            };

            // act
            var hand = HandRank.GetHand(cards, Rank.RoyalFlush);

            // assert
            Assert.Equal(expectedHandCount, hand.Count);
            Assert.Equal(expectedHand, hand, new PlayingCard());
        }
        #endregion
        #region Hand Descriptions and Shorthand syntaxes
        [Fact]
        public void CanGetCorrectHandDescriptionsAndShorthandSyntaxes()
        {
            // arrange
            var hc = GetHighCardHand();
            var hcDesc = "HighCard, King high";
            var hcSH = "KsQhJsTs8h";
            var op = GetOnePairHand();
            var opDesc = "OnePair, Eights";
            var opSH = "8s8hKsQhJs";
            var tp = GetTwoPairHand();
            var tpDesc = "TwoPair, Kings and Eights";
            var tpSH = "KsKc8s8hJs";
            var t = GetThreeOfAKindHand();
            var tDesc = "ThreeOfAKind, Eights";
            var tSH = "8s8h8dKsQc";
            var ns = GetNormalStraightHand();
            var nsDesc = "Straight, King high";
            var nsSH = "KcQsJsTs9s";
            var als = GetAceLowStraightHand();
            var alsDesc = "Straight, Ace through Five";
            var alsSH = "Ac5s4d3h2s";
            var f = GetFlushHand();
            var fDesc = "Flush (Spades), Jack high";
            var fSH = "JsTs8s6s2s";
            var fh = GetFullHouseHand();
            var fhDesc = "FullHouse, Eights over Queens";
            var fhSH = "8s8h8dQsQc";
            var q = GetFourOfAKindHand();
            var qDesc = "FourOfAKind, Eights";
            var qSH = "8s8h8d8cKs";
            var nsf = GetNormalStraightFlushHand();
            var nsfDesc = "StraightFlush (Spades), King high";
            var nsfSH = "KsQsJsTs9s";
            var alsf = GetAceLowStraightFlushHand();
            var alsfDesc = "StraightFlush (Spades), Ace through Five";
            var alsfSH = "As5s4s3s2s";
            var r = GetRoyalStraightFlushHand();
            var rDesc = "RoyalFlush (Spades)";
            var rSH = "AsKsQsJsTs";

            // act
            var hcHand = HandRank.GetHand(hc, Rank.HighCard);
            var opHand = HandRank.GetHand(op, Rank.OnePair);
            var tpHand = HandRank.GetHand(tp, Rank.TwoPair);
            var tHand = HandRank.GetHand(t, Rank.ThreeOfAKind);
            var nsHand = HandRank.GetHand(ns, Rank.Straight);
            var alsHand = HandRank.GetHand(als, Rank.Straight);
            var fHand = HandRank.GetHand(f, Rank.Flush);
            var fhHand = HandRank.GetHand(fh, Rank.FullHouse);
            var qHand = HandRank.GetHand(q, Rank.FourOfAKind);
            var nsfHand = HandRank.GetHand(nsf, Rank.StraightFlush);
            var alsfHand = HandRank.GetHand(alsf, Rank.StraightFlush);
            var rHand = HandRank.GetHand(r, Rank.RoyalFlush);

            // assert
            Assert.Equal(GetHandDescriptionTest(hcHand, Rank.HighCard), hcDesc);
            Assert.Equal(GetHandDescriptionTest(opHand, Rank.OnePair), opDesc);
            Assert.Equal(GetHandDescriptionTest(tpHand, Rank.TwoPair), tpDesc);
            Assert.Equal(GetHandDescriptionTest(tHand, Rank.ThreeOfAKind), tDesc);
            Assert.Equal(GetHandDescriptionTest(nsHand, Rank.Straight), nsDesc);
            Assert.Equal(GetHandDescriptionTest(alsHand, Rank.Straight), alsDesc);
            Assert.Equal(GetHandDescriptionTest(fHand, Rank.Flush), fDesc);
            Assert.Equal(GetHandDescriptionTest(fhHand, Rank.FullHouse), fhDesc);
            Assert.Equal(GetHandDescriptionTest(qHand, Rank.FourOfAKind), qDesc);
            Assert.Equal(GetHandDescriptionTest(nsfHand, Rank.StraightFlush), nsfDesc);
            Assert.Equal(GetHandDescriptionTest(alsfHand, Rank.StraightFlush), alsfDesc);
            Assert.Equal(GetHandDescriptionTest(rHand, Rank.RoyalFlush), rDesc);

            Assert.Equal(GetShortHandSyntaxTest(hcHand), hcSH);
            Assert.Equal(GetShortHandSyntaxTest(opHand), opSH);
            Assert.Equal(GetShortHandSyntaxTest(tpHand), tpSH);
            Assert.Equal(GetShortHandSyntaxTest(tHand), tSH);
            Assert.Equal(GetShortHandSyntaxTest(nsHand), nsSH);
            Assert.Equal(GetShortHandSyntaxTest(alsHand), alsSH);
            Assert.Equal(GetShortHandSyntaxTest(fHand), fSH);
            Assert.Equal(GetShortHandSyntaxTest(fhHand), fhSH);
            Assert.Equal(GetShortHandSyntaxTest(qHand), qSH);
            Assert.Equal(GetShortHandSyntaxTest(nsfHand), nsfSH);
            Assert.Equal(GetShortHandSyntaxTest(alsfHand), alsfSH);
            Assert.Equal(GetShortHandSyntaxTest(rHand), rSH);

        }
        #endregion
        // --------------------------- HELPER METHODS -------------------------//
        #region Helper Description and Shorthand Syntax Methods
        private string GetShortFaceTest(Face face)
        {
            switch (face)
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
        private string GetShortHandSyntaxTest(List<PlayingCard> BestFiveCardHand)
        {
            string shortHand = "";
            foreach (var card in BestFiveCardHand)
            {
                shortHand += GetShortFaceTest(card.Face);
                int s = (int)card.Suit;
                ShortHandSuit shs = (ShortHandSuit)s;
                shortHand += shs.ToString();
            }
            return shortHand;
        }

        private string GetHandDescriptionTest(List<PlayingCard> BestFiveCardHand, Rank Rank)
        {
            switch (Rank)
            {
                case Rank.HighCard:
                default:
                    return $"{Rank}, {BestFiveCardHand.First().Face} high";
                case Rank.OnePair:
                    return $"{Rank}, {BestFiveCardHand.First().Face}s";
                case Rank.TwoPair:
                    return $"{Rank}, {BestFiveCardHand.First().Face}s and {BestFiveCardHand.Skip(2).First().Face}s";
                case Rank.ThreeOfAKind:
                    return $"{Rank}, {BestFiveCardHand.First().Face}s";
                case Rank.Straight:
                    if (BestFiveCardHand.Skip(1).First().Face == Face.Five)
                    {
                        return $"{Rank}, {BestFiveCardHand.First().Face} through {BestFiveCardHand.Skip(1).First().Face}";
                    }
                    else
                    {
                        return $"{Rank}, {BestFiveCardHand.First().Face} high";
                    }
                case Rank.Flush:
                    return $"{Rank} ({BestFiveCardHand.First().Suit}), {BestFiveCardHand.First().Face} high";
                case Rank.FullHouse:
                    return $"{Rank}, {BestFiveCardHand.First().Face}s over {BestFiveCardHand.Skip(3).First().Face}s";
                case Rank.FourOfAKind:
                    return $"{Rank}, {BestFiveCardHand.First().Face}s";
                case Rank.StraightFlush:
                    if (BestFiveCardHand.Skip(1).First().Face == Face.Five)
                    {
                        return $"{Rank} ({BestFiveCardHand.First().Suit}), {BestFiveCardHand.First().Face} through {BestFiveCardHand.Skip(1).First().Face}";
                    }
                    return $"{Rank} ({BestFiveCardHand.First().Suit}), {BestFiveCardHand.First().Face} high";
                case Rank.RoyalFlush:
                    return $"{Rank} ({BestFiveCardHand.First().Suit})";
            }
        }
#endregion
        #region Helper Hand Methods

        public List<PlayingCard> GetHighCardHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetOnePairHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetTwoPairHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };

        public List<PlayingCard> GetFuckedTwoPairHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Clubs},
        };
        public List<PlayingCard> GetThreeOfAKindHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetNormalStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Seven, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetAceHighStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Seven, Suit = Suit.Hearts}
        };
        public List<PlayingCard> GetAceLowStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs}
        };
        public List<PlayingCard> GetFuckedNormalStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetFuckedAceHighStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Hearts}
        };
        public List<PlayingCard> GetFuckedAceLowStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Clubs}
        };
        public List<PlayingCard> GetFourCardNormalStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Seven, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetFourCardAceHighStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Seven, Suit = Suit.Hearts}
        };
        public List<PlayingCard> GetFourCardAceLowStraightHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs}
        };
        public List<PlayingCard> GetFlushHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades}
        };
        public List<PlayingCard> GetFuckedFlushHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades}
        };
        public List<PlayingCard> GetFullHouseHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetFuckedFullHouseHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetFourOfAKindHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetNormalStraightFlushHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Seven, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Diamonds}
        };
        public List<PlayingCard> GetAceLowStraightFlushHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades}
        };
        public List<PlayingCard> GetRoyalStraightFlushHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Eight, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Six, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Hearts}
        };
        public List<PlayingCard> GetNormalStraightFlushSuitConflictHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.King, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Nine, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Clubs},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Spades}
        };
        public List<PlayingCard> GetAceLowStraightFlushSuitConflictHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Three, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.Five, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Four, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Three, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Two, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Hearts}
        };
        public List<PlayingCard> GetRoyalSuitConflictHand() => new List<PlayingCard>
        {
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Spades},
            new PlayingCard() {Face = Face.King, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Jack, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Ten, Suit = Suit.Hearts},
            new PlayingCard() {Face = Face.Queen, Suit = Suit.Diamonds},
            new PlayingCard() {Face = Face.Ace, Suit = Suit.Hearts}
        };
        #endregion
    }
}
