using System;
using System.Collections.Generic;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models.Entities
{
    public partial class PokerWinners
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortHandSyntax { get; set; }
        public string HandDescription { get; set; }
        public DateTime Date { get; set; }
    }
}
