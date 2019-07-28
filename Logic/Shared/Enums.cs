using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SclBaseball.Logic.Shared
{
    public class Enums
    {
        public enum GameType : byte
        {
            League = 0,
            NonLeague = 1,
            DistrictTournament = 2,
            StateTournament = 3,
            Exhibition = 4,
            Unknown = 5
        };
    }
}