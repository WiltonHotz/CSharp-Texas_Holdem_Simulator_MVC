using Spela_Ett_Kortspel_Viktor_Hoerwing.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing
{
    public class Judge
    {
        public static List<Participant> AllParticipants { get; set; }
        public static List<IGrouping<Rank, Participant>> RankGroups { get; set; }
        public static List<Participant> PlayersInWinningOrder { get; set; }

        public Judge()
        {
            AllParticipants = new List<Participant>();
            RankGroups = new List<IGrouping<Rank, Participant>>();
            PlayersInWinningOrder = new List<Participant>();
        }

        public void OrderParticipants()
        {
            AllParticipants = AllParticipants.OrderBy(p => p.Hand.Rank).ToList();
        }

        public void JudgeByRank()
        {
            RankGroups = AllParticipants.GroupBy(p => p.Hand.Rank).ToList();
        }
    }
}
