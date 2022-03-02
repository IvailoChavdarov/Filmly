using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class TitleDetailsVM : IViewModelWithBreadcrumb
    {
        public int IdInDb { get; set; }
        public string IdInApi { get; set; }
        public Titles TitleFullData { get; set; }
        public bool InUserFavourites { get; set; }
        public bool InUserWatchList { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
        public List<Images> Images { get; set; }
        public string IMDbURL
        {
            get { return $"https://www.imdb.com/title/{this.TitleFullData.IdInApi}"; }
        }
        public string[] Awards
        {
            get { return this.TitleFullData.Awards.Split('|').ToArray(); }
        }
        public string[] StarsNames
        {
            get { return this.TitleFullData.Stars.Split(',').ToArray(); }
        }
        public List<Actors> Stars { get; set; }
        public List<TitleSimplified> Similars { get; set; }
    }
}
