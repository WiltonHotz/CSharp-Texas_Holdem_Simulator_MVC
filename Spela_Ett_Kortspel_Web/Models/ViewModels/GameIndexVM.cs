using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spela_Ett_Kortspel_Web.Models.ViewModels
{
    public class GameIndexVM
    {
        public WinnersIndexVM[] WinnersList { get; set; }
        public GameCreateVM CreateGameForm { get; set; }

    }
}
