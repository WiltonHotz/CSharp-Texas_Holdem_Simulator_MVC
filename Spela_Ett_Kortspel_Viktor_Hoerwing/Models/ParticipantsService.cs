using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.Entities;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models
{
    public class ParticipantsService
    {
        private readonly ParticipantContext context;
        public ParticipantsService(ParticipantContext context)
        {
            this.context = context;
        }
        public WinnersIndexVM[] GetAllWinners()
        {
            return context.PokerWinners
                .Select(o => new WinnersIndexVM
                {
                    Name = o.Name,
                    ShortHandSyntax = o.ShortHandSyntax,
                    HandDescription = o.HandDescription,
                    Date = o.Date
                })
                .OrderBy(o => o.Date)
                .ToArray();
        }
    }
}
