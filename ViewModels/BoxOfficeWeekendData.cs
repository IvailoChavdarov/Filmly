using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class BoxOfficeWeekendData
    {
            public WeekendBoxOffice[] Items { get; set; }
            public string ErrorMessage { get; set; }
            public string LastUpdate { get; set; }
    }
    public class WeekendBoxOffice
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Weekend { get; set; }
        public string Gross { get; set; }
        public string Weeks { get; set; }
    }

}
