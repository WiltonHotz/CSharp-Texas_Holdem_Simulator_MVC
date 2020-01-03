using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels
{
    public class GameCreateVM
    {
        [Display(Name ="Number of opponents")]
        public SelectListItem[] NumberOfOpponents { get; set; }
        [Range(1,8)]
        public int SelectedNumberOfOpponents { get; set; }
    }
}
