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
        [Authorize]
        public IActionResult Index()
        {
            UserWatchlistVM userWatchlistData = new UserWatchlistVM();
            userWatchlistData.ToWatch = _db.User_WatchList.Where(user_watchlist => user_watchlist.ApplicationUserID == _userManager.FindByNameAsync(User.Identity.Name).Result.Id).Select(pair => pair.Title).ToList();
            userWatchlistData.UserData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(userWatchlistData);
        }
        // Render user's favourites list
        [Authorize]
        public IActionResult Favourites()
        {
            UserFavouritesVM userFavouritesData = new UserFavouritesVM();
            userFavouritesData.Favourites = _db.User_Favourites.Where(user_favourite => user_favourite.ApplicationUserID == _userManager.FindByNameAsync(User.Identity.Name).Result.Id).Select(pair => pair.Title).ToList();
            userFavouritesData.UserData = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(userFavouritesData);
        }
        public IActionResult FavouritesOf(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("favourites");
            }
            var user = _userManager.FindByNameAsync(name).Result;
            if (user==null)
            {
                return View(new FavouritesOfVM()
                {
                    ErrorMessage = "This user doesn't exist."
                });
            }
            if (user.IsPublic)
            {
                FavouritesOfVM user_Favourites_Pair = new FavouritesOfVM()
                {
                    Name = user.FirstName +" " +user.LastName,
                    Image = user.ProfileImage,
                    Favourites = _db.User_Favourites
                    .Where(user_favourite => user_favourite.ApplicationUser.UserName == name)
                    .Select(pair => pair.Title)
                    .ToArray()
                    
            };
            if (User.Identity.IsAuthenticated)
            {
                user_Favourites_Pair.UserData = _userManager.FindByNameAsync(User.Identity.Name).Result;
                if (user_Favourites_Pair.UserData== user)
                {
                    user_Favourites_Pair.SameUser = true;
                }
            }
                return View(user_Favourites_Pair);
            }
            else
            {
                return View(new FavouritesOfVM()
                {
                    ErrorMessage = "This user's collections are private."
                });
            }
            
        }
    }
}
