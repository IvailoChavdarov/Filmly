using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    //Model of the JSON returned by API collection search (search by collection name)
    public class TitleRanking
        {
            //collection of the movies in the classation
            public RankingTitleItem[] Items { get; set; }
            public string LastUpdate { get; set; }
            public string ErrorMessage { get; set; }


    }
    //Classation Item (movie)
    public class RankingTitleItem
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public string Crew { get; set; }
        public string ImDbRating { get; set; }
        public string ImDbRatingCount { get; set; }
    }
    public class TitleRankingVM : IViewModelWithBreadcrumb
    {
        public string RankingName { get; set; }
        public TitleRanking Ranking { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
        public string Image { get; set; }
    } 
}

