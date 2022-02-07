using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class ActorDataAPIModel
    {

            public string Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string Image { get; set; }
            public string Summary { get; set; }
            public string BirthDate { get; set; }
            public string DeathDate { get; set; }
            public string Awards { get; set; }
            public string Height { get; set; }
            public KnownFor[] KnownFor { get; set; }
            public CastMovies[] CastMovies { get; set; }
            public string ErrorMessage { get; set; }
    }
    public class KnownFor
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }
    }

    public class CastMovies
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    }
}
