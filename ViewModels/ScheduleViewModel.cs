using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SclBaseball.ViewModels
{
    public class ScheduleViewModel
    {
        public DateTime ScheduledDate { get; set; }
        public string HeaderClass { get; set; }
        public List<GameViewModel> ScheduledGames { get; set; }
    }
}