using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.StaticClasses
{
    public static class Validators
    {
        public static List<string> AvailableRankings { get; } = new List<string>() {"Top250Movies", "Top250TVs", "MostPopularMovies", "MostPopularTVs"};
        public static List<string> BonusRankings { get; } = new List<string>() { "ActionTitles", "FantasyTitles", "Anime", "ComedyTitles", "FamilyTitles", "HorrorTitles", "RomanceTitles", "DocumentaryTitles", "DramaTitles" };
        public static List<string> AnimeRankings { get; } = new List<string>() { "Top250Anime", "MostPopularAnime" };
    }
}
