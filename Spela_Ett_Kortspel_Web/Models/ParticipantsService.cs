using Microsoft.AspNetCore.Mvc.Rendering;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.Entities;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels;
using Spela_Ett_Kortspel_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models
{
    public class ParticipantsService
    {
        private readonly ParticipantContext context;
        public ParticipantsService(ParticipantContext context)
        {
            this.context = context;
        }
        //public GameIndexVM GetGameIndexVM()
        //{
        //    return new GameIndexVM()
        //    {
        //        CreateGameForm = GetDropDownItems(),
        //        WinnersList = GetAllWinners()
        //    };
        //}
        public IEnumerable<WinnersIndexVM> GetAllWinners()
        {
            return context.PokerWinners
                .Select(o => new WinnersIndexVM
                {
                    Name = o.Name,
                    HTMLSHS = Hand.ImageBuilder(o.ShortHandSyntax),
                    HandDescription = o.HandDescription,
                    Date = o.Date
                })
                .ToList();
        }

        internal void AddWinnerToDatabase(Participant participant)
        {
            if(participant.Id == 0)
            {
                context.PokerWinners.Add(new PokerWinners
                {
                    Name = participant.Name,
                    ShortHandSyntax = participant.Hand.ShortHandSyntax,
                    HandDescription = participant.Hand.HandDescription,
                    Date = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        public Task<IEnumerable<WinnersIndexVM>> GetAllWinnersVMAsync()
        {
            return Task.Run(() => GetAllWinners());
        }

        public List<Participant> StartGame(string name, int numberOfOpponents)
        {
            PlayingCardGame game = new PlayingCardGame(name, numberOfOpponents);
            return game.PlayersInWinningOrder;
        }

        public GameCreateVM GetDropDownItems()
        {
            return new GameCreateVM
            {
                NumberOfOpponents = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "Select Number of Opponents" },
                    new SelectListItem { Value = "1", Text = "1" },
                    new SelectListItem { Value = "2", Text = "2" },
                    new SelectListItem { Value = "3", Text = "3" },
                    new SelectListItem { Value = "4", Text = "4" },
                    new SelectListItem { Value = "5", Text = "5" },
                    new SelectListItem { Value = "6", Text = "6" },
                    new SelectListItem { Value = "7", Text = "7" },
                    new SelectListItem { Value = "8", Text = "8" },
                }
            };
        }
    }
}
