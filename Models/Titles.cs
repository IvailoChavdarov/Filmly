using Filmly.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Filmly.ViewModels.TitleExtendedData;

namespace Filmly.Models
{
    //Simplified way to get movie, which will be stored in SQL database and used in user collections (watchlist, favourites)
    
    public class Titles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string TitleName { get; set; }

        //URL of the image/cover of the movie
        [Required]
        public string Image { get; set; }

        //Id of the movie in IMDb-API
        [Required]
        public string IdInApi { get; set; }
            public string OriginalTitle { get; set; }
            public string FullTitle { get; set; }
            public string Type { get; set; }
            public string Year { get; set; }
            public string ReleaseDate { get; set; }
            public string RuntimeStr { get; set; }
            public string Plot { get; set; }
            public string Awards { get; set; }
            public string Directors { get; set; }
            public string Writers { get; set; }
            public string Stars { get; set; }
            public string Genres { get; set; }
            public string Companies { get; set; }
            public string Countries { get; set; }
            public string Languages { get; set; }
            public string ContentRating { get; set; }
            public string IMDbRating { get; set; }
            public string IMDbRatingVotes { get; set; }
            public string TrailerLinkEmbed { get; set; }
            public string Tagline { get; set; }
            public string Keywords { get; set; }
        public HashSet<ApplicationUser_Favourites> ApplicationUser_Favourites { get; set; }
        public HashSet<ApplicationUser_ToWatch> ApplicationUser_WatchList { get; set; }
        public HashSet<Titles_Actors> Cast { get; set; }
        public HashSet<Similars> Similar { get; set; }
        public HashSet<Images> Images { get; set; }
    }
}

