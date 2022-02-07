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
        public bool? Success { get; set; }
        public Titles TitleFullData { get; set; }
        public bool InUserFavourites { get; set; }
        public bool InUserWatchList { get; set; }
        public string Change { get; set; }
        public string Target { get; set; }
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
