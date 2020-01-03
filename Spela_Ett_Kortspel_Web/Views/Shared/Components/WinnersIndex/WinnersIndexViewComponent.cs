using Microsoft.AspNetCore.Mvc;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models;
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await service.GetAllWinnersVMAsync());
        }
    }
}
