using SclBaseball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SclBaseball.Logic.Interfaces
{
    public interface IGameService
    {
        List<Game> GetGames(string term = null);
    }
}