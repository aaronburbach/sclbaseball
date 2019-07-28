using System;
using SclBaseball.Logic.Shared;

namespace SclBaseball.ViewModels
{
    public class GameViewModel
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
        public Enums.GameType Type { get; set; }
        public string GameClass { get; set; }
        public bool HasBeenPlayed => PlayedDate.HasValue;
        public bool IsPostponed => InningsPlayed == -1;
        public string RadioStationText => IsOnRadio ? $"({RadioStation})" : "";
        public string PostponedText => IsPostponed ? " - PPD" : "";
        public string ScheduledGameText => GetGameText();

        private string GetGameText()
        {
            var gameText = "";

            gameText = $"{AwayTeam} ";
            gameText += $"{((HasBeenPlayed && !IsPostponed) ? $"{AwayScore.ToString()} " : "")}";
            gameText += $"@ {HomeTeam} ";
            gameText += $"{((HasBeenPlayed && !IsPostponed) ? $"{HomeScore.ToString()} " : "")}";

            return gameText;
        }
    }
}