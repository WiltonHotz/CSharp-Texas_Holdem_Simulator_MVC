using Microsoft.AspNetCore.Mvc;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spela_Ett_Kortspel_Web.Views.Shared.Components.WinnersIndex
{
    public class WinnersIndexViewComponent : ViewComponent
    {
        private ParticipantsService service;
        public WinnersIndexViewComponent(ParticipantsService service)
        {
            this.service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            IEnumerable<WinnersIndexVM> winners = await service.GetAllWinnersVMAsync();

            switch(sortOrder)
            {
                case "name_desc":
                    winners = winners.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    winners = winners.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    winners = winners.OrderByDescending(s => s.Date);
                    break;
                default:
                    winners = winners.OrderBy(s => s.Name);
                    break;
            }
            return View(winners);
        }
    }
}
