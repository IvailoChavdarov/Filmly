using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class AppUser_FavouritePairVM:IViewModelWithBreadcrumb
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Titles[] Favourites { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public BreadcrumbData BreadcrumbData { get; set; }
    }
}
