﻿using Microsoft.AspNetCore.Mvc;
using Spela_Ett_Kortspel_Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models.ViewModels
{
    //[Bind(Prefix = nameof(GameIndexVM.WinnersList))]
    public class WinnersIndexVM
    {
        public string Name { get; set; }
        public string HTMLSHS { get; set; }
        public string HandDescription { get; set; }
        public DateTime Date { get; set; }
    }
}
