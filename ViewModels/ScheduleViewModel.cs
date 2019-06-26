using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SclBaseball.ViewModels
{
    public class ScheduleViewModel
    {
        public DateTime ScheduledDate { get; set; }
        public DateTime? PlayedDate { get; set; }
        public Single InningsPlayed { get; set; }
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsOnRadio { get; set; }
        public string RadioStation { get; set; }
        public bool IsLeagueGame { get; set; }
    }
}