using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class ThemedRankingVM:IViewModelWithBreadcrumb, IRankingData
    {
        public string RankingName { get; set; }
        //public ThemedRanking Ranking { get; set; }
        public ThemedRanking Ranking { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
        public string Image { get; set; }
        public List<IRankingTitle> Entries { get { return this.Ranking.Results.ToList<IRankingTitle>(); } }
    }
}
