using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class HomePageData
    {
        public NewTitleCollection InTheaters { get; set; }
        public NewTitleCollection ComingSoon { get; set; }
        public BoxOfficeWeekendData WeekendBoxOffice { get; set; }
        public List<RankingTitleItem> Top10MostPopularMovies { get; set; }
        public List<RankingTitleItem> Top10BestMovies { get; set; }
        public List<RankingTitleItem> Top10MostPopularTVSeries { get; set; }
        public List<RankingTitleItem> Top10BestTVSeries { get; set; }
        public List<Entries> Top10BestAnime { get; set; }
        public List<Entries> Top10MostPopularAnime { get; set; }
    }
}
