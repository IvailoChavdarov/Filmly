using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class UserFavouritesVM : IUserPageModel
    {
        public ApplicationUser UserData { get; set; }
        public List<Titles> Favourites { get; set; }
    }
}
