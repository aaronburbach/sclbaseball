using SclBaseball.Migrations;
using System;
using System.ComponentModel.DataAnnotations;
using SclBaseball.Logic.Shared;

namespace SclBaseball.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Display(Name = "Date Scheduled")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledDate { get; set; }

        [Display(Name = "Date Played")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PlayedDate { get; set; }

        public Single InningsPlayed { get; set; }

        public string HomeTeam { get; set; }

        public int HomeScore { get; set; }

        public string AwayTeam { get; set; }

        public int AwayScore { get; set; }

        public string Location { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public bool IsOnRadio { get; set; }

        public string RadioStation { get; set; }

        public Enums.GameType Type { get; set; }
    }
}