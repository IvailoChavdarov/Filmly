using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    [NotMapped]
    public class NewTitleCollection
    {
        public NewTitle[] Items { get; set; }
        public string ErrorMessage { get; set; }
        public string LastUpdate { get; set; }
    }
    [NotMapped]
    public class NewTitle
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string ReleaseState { get; set; }
        public string Image { get; set; }
        public string RuntimeMins { get; set; }
        public string RuntimeStr { get; set; }
        public string Plot { get; set; }
        public string ContentRating { get; set; }
        public string ImDbRating { get; set; }
        public string ImDbRatingCount { get; set; }
        public string MetacriticRating { get; set; }
        public string Genres { get; set; }
        public Genre[] GenreList { get; set; }
        public string Directors { get; set; }
        public Director[] DirectorList { get; set; }
        public string Stars { get; set; }
        public Star[] StarList { get; set; }
    }
    [NotMapped]
    public class Genre
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    [NotMapped]
    public class Director
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    [NotMapped]
    public class Star
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
