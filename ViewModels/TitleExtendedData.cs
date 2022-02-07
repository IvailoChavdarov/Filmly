using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    //Model of the JSON returned by exact API search (search by Id)
    public class TitleExtendedData
            {
            public string Id { get; set; }
            public string Title { get; set; }
            public string OriginalTitle { get; set; }
            public string FullTitle { get; set; }
            public string Type { get; set; }
            public string Year { get; set; }
            public string Image { get; set; }
            public string ReleaseDate { get; set; }
            public string RuntimeMins { get; set; }
            public string RuntimeStr { get; set; }
            public string Plot { get; set; }
            public string PlotLocal { get; set; }
            public bool PlotLocalIsRtl { get; set; }
            public string Awards { get; set; }
            public string Directors { get; set; }
            public object[] DirectorList { get; set; }
            public string Writers { get; set; }
            public object[] WriterList { get; set; }
            public string Stars { get; set; }
            public Star[] StarList { get; set; }
            public Actor[] ActorList { get; set; }
            public object FullCast { get; set; }
            public string Genres { get; set; }
            public Genre[] GenreList { get; set; }
            public string Companies { get; set; }
            public Company[] CompanyList { get; set; }
            public string Countries { get; set; }
            public Country[] CountryList { get; set; }
            public string Languages { get; set; }
            public Language[] LanguageList { get; set; }
            public string ContentRating { get; set; }
            public string ImDbRating { get; set; }
            public string ImDbRatingVotes { get; set; }
            public object MetacriticRating { get; set; }
            public object Ratings { get; set; }
            public object Wikipedia { get; set; }
            public object Posters { get; set; }
            public ImageData Images { get; set; }
            public TrailerData Trailer { get; set; }
            public BoxOffice BoxOffice { get; set; }
            public string Tagline { get; set; }
            public string Keywords { get; set; }
            public string[] KeywordList { get; set; }
            public Similar[] Similars { get; set; }
            public TvSeriesInfo TvSeriesInfo { get; set; }
            public object TvEpisodeInfo { get; set; }
            public string ErrorMessage { get; set; }

       
    }
    public class BoxOffice
    {
        public string Budget { get; set; }
        public string OpeningWeekendUSA { get; set; }
        public string GrossUSA { get; set; }
        public string CumulativeWorldwideGross { get; set; }
    }
    public class TvSeriesInfo
    {
        public string YearEnd { get; set; }
        public string Creators { get; set; }
        public Creator[] CreatorList { get; set; }
        public string[] Seasons { get; set; }
    }
    public class Creator
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Actor
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string AsCharacter { get; set; }
    }
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Country
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class Language
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class Similar
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public string Plot { get; set; }
        public string Directors { get; set; }
        public string Stars { get; set; }
        public string Genres { get; set; }
        public string ImDbRating { get; set; }
    }
}



