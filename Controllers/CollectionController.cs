using Filmly.Data;
using Filmly.Models;
using Filmly.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        //Dependency injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public CollectionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        // Render user's watchlist
        public IActionResult Index()
        {
            var userWatchList = _db.User_WatchList.Where(user_watchlist => user_watchlist.ApplicationUserID == _userManager.FindByNameAsync(User.Identity.Name).Result.Id).Select(pair => pair.Title).ToArray();
            return View(userWatchList);
        }

        // Render user's favourites list
        public IActionResult Favourites()
        {
                var userFavourites = _db.User_Favourites.Where(user_favourite => user_favourite.ApplicationUserID == _userManager.FindByNameAsync(User.Identity.Name).Result.Id).Select(pair => pair.Title).ToArray();
                return View(userFavourites);
        }
        public IActionResult FavouritesOf(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user==null)
            {
                return View(new AppUser_FavouritePairVM()
                {
                    ErrorMessage = "This user doesn't exist."
                });
            }
            if (user.IsPublic)
            {
                AppUser_FavouritePairVM user_Favourites_Pair = new AppUser_FavouritePairVM()
                {
                    Name = user.LastName,
                    Image = user.ProfileImage,
                    Favourites = _db.User_Favourites.Where(user_favourite => user_favourite.ApplicationUserID == id).Select(pair => pair.Title).ToArray()
                };
                return View(user_Favourites_Pair);
            }
            else
            {
                return View(new AppUser_FavouritePairVM()
                {
                    ErrorMessage = "This user's collections are private."
                });
            }
            
        }
    }
}
