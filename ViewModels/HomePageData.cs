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
    }
}
