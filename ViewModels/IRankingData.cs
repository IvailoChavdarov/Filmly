using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public interface IRankingData:IViewModelWithBreadcrumb
    {
        public List<IRankingTitle> Entries { get; }
        public string RankingName { get; set; }
        public string Image { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
    public interface IRankingTitle
    {
        public string Title { get; set; }
        public string IMDbRating { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
    }
}
