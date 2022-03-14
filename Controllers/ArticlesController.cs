using Filmly.StaticClasses;
using Filmly.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Create(string id)
        {
            if (id == "interestingfacts")
            {
                return RedirectToAction("createfact");
            }
            else if (id == "history")
            {
                return RedirectToAction("createevent");
            }
            return RedirectToAction("createfact");
        }
        [HttpGet]
        [Authorize(Roles = "Administrator,Researcher")]
        public IActionResult CreateFact()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator, Researcher")]
        public IActionResult CreateFact(InterestingFact interestingFact)
        {
            if (ModelState.IsValid)
            {
                JSONHelper.WriteInLocalData<InterestingFact>(interestingFact, "InterestingFacts");
                return RedirectToAction("interestingfacts", "home");
            }
            return View(interestingFact);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Researcher")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Administrator, Researcher")]
        public IActionResult CreateEvent(HistoryEvent historyEvent)
        {
            if (ModelState.IsValid)
            {
                JSONHelper.WriteInLocalData<HistoryEvent>(historyEvent, "CinemaHistory");
                return RedirectToAction("history", "home");
            }
            return View(historyEvent);
        }
    }
}
