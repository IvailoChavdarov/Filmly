using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.StaticClasses
{
    public static class NameSimplifiers
    {
        public static Dictionary<string, string> RankingNamesDictionary { get; private set; } = new Dictionary<string, string>() {
            {"top-100-most-popular-movies", "MostPopularMovies" },
            {"top-100-most-popular-tv-series", "MostPopularTVs" },
            {"top-250-movies", "Top250Movies" },
            {"top-250-tv-shows", "Top250TVs" }
        };
        public static Dictionary<string, string> RankingNamesDictionaryUserView { get; private set; } = new Dictionary<string, string>() {
            {"top-100-most-popular-movies", "Top 100 most popular movies" },
            {"top-100-most-popular-tv-shows", "Top 100 most popular TV shows" },
            {"top-250-movies", "Top 250 best rated movies" },
            {"top-250-tv-shows", "Top 250 best rated TV shows" }
        };
        public static Dictionary<string, string> TypeNames { get; private set; } = new Dictionary<string, string>() {
            {"all", "SearchTitle" },
            {"movies", "SearchMovie" },
            {"series", "SearchSeries" },
            {"keywords", "SearchKeyword" },
            {"actors", "SearchName"}
        };
        public static Dictionary<int?, string> Months { get; private set; } = new Dictionary<int?, string>()
        {
            {1, "January" },
            {2, "February" },
            {3, "March" },
            {4, "April" },
            {5, "May" },
            {6, "June" },
            {7, "July" },
            {8, "August" },
            {9, "September" },
            {10, "October" },
            {11, "November" },
            {12, "December" }
        };

    }
}
