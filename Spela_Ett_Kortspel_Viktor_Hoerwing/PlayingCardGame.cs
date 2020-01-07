using Spela_Ett_Kortspel_Viktor_Hoerwing.Participants;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public class PlayingCardGame
    {
        public List<Participant> PlayersInWinningOrder { get; set; }
        public static int id = 0;
        public PlayingCardGame(string name, int numberOfOpponents = 1)
        {
            PlayingCardDeck deck = new PlayingCardDeck();
            Judge judge = new Judge();

            var (player, opponents, table) = CreatePlayersAndTable(deck, numberOfOpponents);
            player.Name = name;
            GetHands(player, opponents, table);

            judge.OrderParticipants();

            //ListHands(player, opponents);

            judge.JudgeByRank();

            AddWinningOrder();

            PlayersInWinningOrder = new List<Participant>();
            PlayersInWinningOrder = Judge.PlayersInWinningOrder;

            id = 0;

            //Console.WriteLine(player.Hand.ImageBuilder(player.TwoCardHandShortHandSyntax));
            //PrintPlayersInWinningOrder();
        }

        //private static void PrintPlayersInWinningOrder()
        //{
        //    Console.WriteLine("\nCount PlayersInWinningOrder:");
        //    Console.WriteLine(Judge.PlayersInWinningOrder.Count());

        //    Console.WriteLine("\nPlayersInWinningOrder:");
        //    foreach (var p in Judge.PlayersInWinningOrder)
        //    {
        //        Console.WriteLine("\n" + p.Name + " with ID " + p.Id + " has rank " + p.Hand.Rank);
        //        foreach (var card in p.Hand.BestFiveCardHand)
        //        {
        //            Console.WriteLine(card);
        //        }
        //    }
        //}

        public static void AddWinningOrder()
        {
            foreach (var g in Judge.RankGroups)
            {
                foreach (var p in g.JudgeGroup())
                {
                    Judge.PlayersInWinningOrder.Add(p);
                }
            }
        }

        //public static void ListHands(Participant player, List<Participant> opponents)
        //{
        //    foreach (var p in Judge.AllParticipants)
        //    {
        //        Console.WriteLine($"{p.Name} with id {p.Id} has {p.Hand.Rank}");
        //    }

        //    Console.WriteLine("Player with id " + player.Id + " has rank: " + player.Hand.Rank);
        //    foreach (var card in player.Hand.BestFiveCardHand)
        //    {
        //        Console.WriteLine(card);
        //    }
        //    foreach (var opponent in opponents)
        //    {
        //        Console.WriteLine("Opponent with id " + opponent.Id + " has rank: " + opponent.Hand.Rank);
        //        foreach (var card in opponent.Hand.BestFiveCardHand)
        //        {
        //            Console.WriteLine(card);
        //        }
        //    }
        //}

        public static void GetHands(Participant player, List<Participant> opponents, Table table)
        {
            player.GetHand(table);
            foreach (var opponent in opponents)
            {
                opponent.GetHand(table);
            }
        }

        public static (Participant, List<Participant>, Table) CreatePlayersAndTable(PlayingCardDeck deck, int numberOfOpponents)
        {
            Participant player = new Player("Viktor", deck, 2, id++);
            List<Participant> opponents = new List<Participant>();

            for (int i = 0; i < numberOfOpponents; i++)
            {
                opponents.Add(new Player("Opponent", deck, 2, id++));
            }
            Table table = new Table("Table", deck, 5, id++);

            return (player, opponents, table);
        }
    }
}
