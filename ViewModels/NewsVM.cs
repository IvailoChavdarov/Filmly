using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class NewsVM:IViewModelWithBreadcrumb
    {
        public List<NewsItem> News { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }

    }
    public class NewsItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Item_id { get; set; }
        public string PubDate { get; set; }
        public string Description { get; set; }
    }
}
