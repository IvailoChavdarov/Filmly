using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.StaticClasses
{
    public static class Validators
    {
        public static List<string> AvailableRankings { get; } = new List<string>() {"Top250Movies", "Top250TVs", "MostPopularMovies", "MostPopularTVs"};
    }
}
