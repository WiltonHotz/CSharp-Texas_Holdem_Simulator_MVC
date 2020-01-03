using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spela_Ett_Kortspel_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels
{
    //[Bind(Prefix = nameof(GameIndexVM.CreateGameForm))]
    public class GameCreateVM
    {
        [Display(Name = "Number of opponents")]
        public List<SelectListItem> NumberOfOpponents { get; set; }
        [Range(1, 8)]
        public int SelectedNumberOfOpponents { get; set; }
    }
}
