using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class ThemedRanking
    {
            public string QueryString { get; set; }
            public Entries[] Results { get; set; }
            public object ErrorMessage { get; set; }
            public string LastUpdate { get; set; }
    }
    public class Entries
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RuntimeStr { get; set; }
        public string Genres { get; set; }
        public Genrelist[] GenreList { get; set; }
        public string ContentRating { get; set; }
        public string IMDbRating { get; set; }
        public string IMDbRatingVotes { get; set; }
        public object MetacriticRating { get; set; }
        public string Plot { get; set; }
        public string Stars { get; set; }
        public Starlist[] StarList { get; set; }
    }

    public class Genrelist
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Starlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
