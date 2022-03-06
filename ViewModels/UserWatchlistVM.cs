using Filmly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
    public class UserWatchlistVM:IUserPageModel
    {
        public ApplicationUser UserData { get; set; }
        public List<Titles> ToWatch { get; set; }
    }
}
