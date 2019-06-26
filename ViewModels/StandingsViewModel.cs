using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SclBaseball.ViewModels
{
    public class StandingsViewModel
    {
        public string Team { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0.000}")]
        public decimal Percentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0.0}")]
        public decimal GamesBehind { get; set; }
        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }
        public int RunsScored { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0.00}")]
        public decimal RunsScoredPerGame { get; set; }
        public int RunsAllowed { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0.00}")]
        public decimal RunsAllowedPerGame { get; set; }
        public int GamesPlayed { get; set; }
    }
}