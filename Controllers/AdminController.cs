using Filmly.Data;
using Filmly.Models;
using Filmly.StaticClasses;
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
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        //Dependency injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var adminControllerData = new AdministrationIndexVM();
            adminControllerData.UsersRoles = new List<UserRole>();

            foreach (var user in _userManager.Users)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, "Researcher"))
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }

                adminControllerData.UsersRoles.Add(userRole);
            }
            adminControllerData.HistoryEvents = JSONHelper.GetLocalDataAsListOfObjects<HistoryEvent>("CinemaHistory");
            adminControllerData.InterestingFacts = JSONHelper.GetLocalDataAsListOfObjects<InterestingFact>("InterestingFacts");

            return View(adminControllerData);
        }
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditUsersInRole(AdministrationIndexVM model)
        {
            var role = await _roleManager.FindByNameAsync("Researcher");

            for (int i = 0; i < model.UsersRoles.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model.UsersRoles[i].UserId);

                IdentityResult result = null;

                if (model.UsersRoles[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model.UsersRoles[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.UsersRoles.Count - 1))
                        continue;
                    else
                        return RedirectToAction("index");
                }
            }

            return RedirectToAction("index");
        }
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Administrator")]
        public IActionResult RemoveFact(string factTitle)
        {
            var interestingFacts = JSONHelper.GetLocalDataAsListOfObjects<InterestingFact>("InterestingFacts");
            var factToRemove = interestingFacts.Where(x => x.FactTitle == factTitle).First();
            interestingFacts.Remove(factToRemove);
            JSONHelper.RewriteLocalData(interestingFacts, "InterestingFacts");
            return RedirectToAction("interestingfacts", "home");
        }
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Administrator")]
        public IActionResult RemoveEvent(string eventTitle)
        {
            var historyEvents = JSONHelper.GetLocalDataAsListOfObjects<HistoryEvent>("CinemaHistory");
            var eventToRemove = historyEvents.Where(x => x.EventTitle == eventTitle).First();
            historyEvents.Remove(eventToRemove);
            JSONHelper.RewriteLocalData(historyEvents, "CinemaHistory");
            return RedirectToAction("history", "home");
        }
    }
}
