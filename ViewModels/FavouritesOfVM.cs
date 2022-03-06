using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class FavouritesOfVM:IUserPageModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Titles[] Favourites { get; set; }
        public ApplicationUser UserData { get; set; }
        public bool SameUser { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
