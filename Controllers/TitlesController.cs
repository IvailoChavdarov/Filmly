using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmly.Data;
using Filmly.Models;
using Filmly.StaticClasses;
using Filmly.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


using System.Data;

namespace Filmly.Controllers
{
    public class TitlesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        public TitlesController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index(string search, string type)
        {
            //if (string.IsNullOrEmpty(search))
            //{
                return RedirectToAction("Ranking", new { id = "top-250-movies" });
            //} else
            //{
            //    return View("SearchTitle", APIHelper.Search(search, type));
            //}
        }
        public IActionResult Search(string search, string type)
        {
            SearchResultVM data = new SearchResultVM();
            if (!string.IsNullOrEmpty(search))
            {
                data= APIHelper.Search(search, type);
            }
            else
            {
                data.Expression = null;
            }
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "titles",
                ControllerPublicName = "Titles",
                HiddenController = true,
                ActionName = "search",
                ActionPublicName ="Search",
                IdName = null,
                IdPublicName = search
            };
            return View(data);
        }
        [HttpGet]
        public IActionResult Cast(string id)
        {
            TitleCastVM data = new TitleCastVM();
            data.TitleData = APIHelper.GetTitleFullCast(id);
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "titles",
                ControllerPublicName = "Titles",
                ActionName = "details",
                ActionPublicName = data.TitleData.Title,
                IdName = id,
                HiddenAction = true,
                IdPublicName = "Cast"
                
            };
            return View(data);
        }
        [HttpGet]
        public IActionResult CastIn(string id)
        {
            ActorCastInVM data = new ActorCastInVM();
            data.ActorData = APIHelper.GetActorData(id);
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "titles",
                ControllerPublicName = "Titles",
                ActionName = "details",
                ActionPublicName = "Details",
                IdName = id,
                IdPublicName = data.ActorData.Name + " roles"
            };
            return View(data);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            if (id.StartsWith('n'))
            {
                return RedirectToAction("ActorDetails", new {id=id });
            }
            Titles TitleToRender = GetTitle(id);
            //tt2560140 - AoT IMDb ID
            if (TitleToRender.IdInApi== "tt2560140")
            {
                TitleToRender.IMDbRating = "10";
            }
            //var MovieInDb = _db.Titles.Where(x => x.IdInApi == id);
            TitleDetailsVM Response = new TitleDetailsVM() { TitleFullData = TitleToRender};
            if (User.Identity.IsAuthenticated)
            {
                var AppUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

                    Response.InUserFavourites = _db.User_Favourites.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleToRender.Id).ToArray().Length != 0;
                    Response.InUserWatchList = _db.User_WatchList.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleToRender.Id).ToArray().Length != 0;
                
            }
            Response.Images = _db.Images.Where(x => x.TitleId == TitleToRender.Id).ToList();
            Response.Stars = _db.Titles_Actors.Where(user_favourite => user_favourite.TitleId == TitleToRender.Id).Select(pair => pair.Actor).ToList();
            Response.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "titles",
                ControllerPublicName = "Titles",
                ActionName = "details",
                ActionPublicName = "Details",
                HiddenAction = true,
                IdName = id,
                IdPublicName = Response.TitleFullData.FullTitle
            };
            return View(Response);
        }
        [HttpGet]
        public IActionResult ActorDetails(string id)
        {
            ActorDetailsVM actorDetails = new ActorDetailsVM() {
                Data = GetActor(id)
            };
            actorDetails.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "titles",
                ControllerPublicName = "Titles",
                ActionName = "details",
                ActionPublicName = "Cinema's history",
                HiddenAction = true,
                HiddenController = true,
                IdName = id,
                IdPublicName = actorDetails.Data.Name
            };
            return View(actorDetails);
        }
        [HttpGet]
        public IActionResult Ranking(string id)
        {
            IRankingData rankingData;
            APIHelper.DailyDataRefill();
            if (Validators.AnimeRankings.Contains(NameSimplifiers.RankingNamesDictionary[id])||Validators.BonusRankings.Contains(NameSimplifiers.RankingNamesDictionary[id]))
            {
                rankingData = new ThemedRankingVM() { RankingName = NameSimplifiers.RankingNamesDictionaryUserView[id], Ranking = JSONHelper.GetLocalDataAsObject<ThemedRanking>(NameSimplifiers.RankingNamesDictionary[id]) };
            }
            else
            {
                rankingData = new TitleRankingVM() { RankingName = NameSimplifiers.RankingNamesDictionaryUserView[id], Ranking = JSONHelper.GetLocalDataAsObject<TitleRanking>(NameSimplifiers.RankingNamesDictionary[id]) };
            }

            rankingData.BreadcrumbData = new BreadcrumbData() { ControllerName = "titles", ControllerPublicName = "Titles", ActionName = "ranking", HiddenAction = true, IdName = id, IdPublicName = NameSimplifiers.RankingNamesDictionaryUserView[id] };
            rankingData.Image = id + ".jpg";
            return View(rankingData);
        }
        [HttpGet]
        public IActionResult ThemedRanking(string id)
        {
            ThemedRankingVM RankingData = new ThemedRankingVM() { RankingName = NameSimplifiers.RankingNamesDictionaryUserView[id], Ranking = JSONHelper.GetLocalDataAsObject<ThemedRanking>(NameSimplifiers.RankingNamesDictionary[id]) };
            RankingData.BreadcrumbData = new BreadcrumbData() { ControllerName = "titles", ControllerPublicName = "Titles", ActionName = "ranking", HiddenAction = true, IdName = id, IdPublicName = NameSimplifiers.RankingNamesDictionaryUserView[id] };
            if (!Validators.AnimeRankings.Contains(NameSimplifiers.RankingNamesDictionary[id]))
            {
                RankingData.Image = id+".jpg";
            }
            return View("Ranking", RankingData);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTo(string collection, string id, string title)
        {
            var AppUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            int InDatabaseId = TitleInDatabaseId(id);
            if (InDatabaseId == -1)
            {
                //_db.MoviesSimplified.Add(movieToAdd);
                _db.SaveChanges();
                InDatabaseId = TitleInDatabaseId(id);
            }
            if (collection=="favourites")
            {
                _db.User_Favourites.Add(new ApplicationUser_Favourites()
                {
                    ApplicationUser = AppUser,
                    TitleId = InDatabaseId
                });
            }
            else if (collection == "watchlist")
            {
                _db.User_WatchList.Add(new ApplicationUser_ToWatch()
                {
                    ApplicationUser = AppUser,
                    TitleId = InDatabaseId
                });
            }            
            _db.SaveChanges();
            
            if (collection == "favourites")
            {
                if (TitleInDatabaseId(id) >= 0 && _db.User_Favourites.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleInDatabaseId(id)).ToArray().Length != 0)
                {
                    TempData["notice"] = $"Successfully added {title} to your favourites!";
                    TempData["noticeBackground"] = "bg-success";
                }
                else
                {
                    TempData["notice"] = $"{title} was not successfully added to your favourites!";
                    TempData["noticeBackground"] = "bg-danger";
                }
                return RedirectToAction("Details", new { id = id });
            }
            else if (collection == "watchlist")
            {
                if (TitleInDatabaseId(id) >= 0 && _db.User_WatchList.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleInDatabaseId(id)).ToArray().Length != 0)
                {
                    TempData["notice"] = $"Successfully added {title} to your watchlist!";
                    TempData["noticeBackground"] = "bg-success";
                }
                else
                {
                    TempData["notice"] = $"{title} was not successfully added to your watchlist!";
                    TempData["noticeBackground"] = "bg-danger";
                }
                return RedirectToAction("Details", new { id = id });
            }
            throw new Exception();
            //Response.InUserFavourites = _db.User_WatchList.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.MovieId == TitleInDatabaseId(id)).ToArray().Length != 0;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFrom(string collection, string id, string title)
        {
            var AppUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            int InDatabaseId = TitleInDatabaseId(id);
            if (InDatabaseId == -1)
            {
                //_db.MoviesSimplified.Add(movieToAdd);
                
                InDatabaseId = TitleInDatabaseId(id);
                _db.SaveChanges();
            }
            if (collection == "favourites")
            {
                AppUser.ApplicationUser_Favourites.Remove(_db.User_Favourites.Where(x => x.ApplicationUserID == AppUser.Id && x.TitleId == InDatabaseId).First());
            }
            else if (collection == "watchlist")
            {
                AppUser.ApplicationUser_WatchList.Remove(_db.User_WatchList.Where(x => x.ApplicationUserID == AppUser.Id && x.TitleId == InDatabaseId).First());
            }
            _db.SaveChanges();

            if (collection == "favourites")
            {
                if (TitleInDatabaseId(id) >= 0 && _db.User_Favourites.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleInDatabaseId(id)).ToArray().Length == 0)
                {
                    TempData["notice"] = $"Successfully removed {title} from your favourites!";
                    TempData["noticeBackground"] = "bg-success";
                }
                else
                {
                    TempData["notice"] = $"{title} was not successfully removed from your favourites!";
                    TempData["noticeBackground"] = "bg-danger";
                }
                return RedirectToAction("details", new { id = id });
            }
            else if (collection == "watchlist")
            {
                if (TitleInDatabaseId(id) >= 0 && _db.User_WatchList.Where(x => x.ApplicationUserID == AppUser.Id).Where(x => x.TitleId == TitleInDatabaseId(id)).ToArray().Length == 0)
                {
                    TempData["notice"] = $"Successfully removed {title} from your watchlist!";
                    TempData["noticeBackground"] = "bg-success";
                }
                else
                {
                    TempData["notice"] = $"{title} was not successfully removed from your watchlist!";
                    TempData["noticeBackground"] = "bg-danger";
                }
                return RedirectToAction("details", new { id = id });
            }
            throw new Exception();
            
        }

        //Helper methods
        [HttpPost]
        private int AddTitleFromAPIToDB(string idInApi)
        {
            if (TitleInDatabaseId(idInApi)==-1)
            {
               var titleData = APIHelper.GetTitleFullData(idInApi);
                if (string.IsNullOrEmpty(titleData.ErrorMessage))
                {
                    Titles newTitle = new Titles()
                    {
                        TitleName = titleData.Title,
                        Image = titleData.Image,
                        IdInApi = titleData.Id,
                        OriginalTitle = titleData.OriginalTitle,
                        FullTitle = titleData.FullTitle,
                        Type = titleData.Type,
                        Year = titleData.Year,
                        ReleaseDate = titleData.ReleaseDate,
                        RuntimeStr = titleData.RuntimeStr,
                        Plot = titleData.Plot,
                        Awards = titleData.Awards,
                        Directors = titleData.Directors,
                        Writers = titleData.Writers,
                        Stars = titleData.Stars,
                        Genres = titleData.Genres,
                        Companies = titleData.Companies,
                        Countries = titleData.Countries,
                        Languages = titleData.Languages,
                        ContentRating = titleData.ContentRating,
                        IMDbRating = titleData.ImDbRating,
                        IMDbRatingVotes = titleData.ImDbRatingVotes,
                        TrailerLinkEmbed = titleData.Trailer.LinkEmbed,
                        Tagline = titleData.Tagline,
                        Keywords = titleData.Keywords
                    };
                    newTitle.Cast = new HashSet<Titles_Actors>();
                    newTitle.Images = new HashSet<Images>();
                    newTitle.Similar = new HashSet<Similars>();
                    foreach (var star in titleData.StarList)
                    {
                        Actors actor = new Actors();
                        if (ActorInDatabaseId(star.Id)==-1)
                        {
                            var actorData = APIHelper.GetActorData(star.Id);
                            if (string.IsNullOrEmpty(actorData.ErrorMessage))
                            {
                                actor=new Actors()
                                {
                                    IdInAPI = star.Id,
                                    Name = actorData.Name,
                                    Role = actorData.Role,
                                    Image = actorData.Image,
                                    Summary = actorData.Summary,
                                    BirthDate = actorData.BirthDate,
                                    DeathDate = actorData.DeathDate,
                                    Awards = actorData.Awards,
                                    Height = actorData.Height
                                };
                            }
                            newTitle.Cast.Add(new Titles_Actors()
                            {
                                Title = newTitle,
                                Actor = actor
                            });
                        }
                        else
                        {
                            newTitle.Cast.Add(new Titles_Actors()
                            {
                                Title = newTitle,
                                Actor = _db.Actors.Where(x => x.IdInAPI == star.Id).FirstOrDefault()
                            });
                        }


                    }
                    foreach (var similar in titleData.Similars)
                    {
                        TitleSimplified similarTitle = new TitleSimplified();
                        if (SimplifiedTitleInDbId(similar.Id) == -1)
                        {
                            similarTitle = new TitleSimplified()
                            {
                                IdInApi=similar.Id,
                                Title=similar.Title,
                                ImgURL=similar.Image,
                                IMDbRating=similar.ImDbRating
                            }; 
                        }
                        else
                        {
                            similarTitle = GetTitleSimplified(similar.Id);
                        }
                        newTitle.Similar.Add(new Similars()
                        {
                            Title = newTitle,
                            Similar = similarTitle
                        });
                    }
                    if (titleData.Images.Items.Count>27)
                    {
                        for (int i = 0; i < 27; i++)
                        {
                            var newImage = new Images()
                            {
                                ImgURL = titleData.Images.Items[i].Image,
                                ImgTitle = titleData.Images.Items[i].Title
                            };
                            newTitle.Images.Add(newImage);
                        }
                    }
                    else
                    {
                        foreach (var imageData in titleData.Images.Items)
                        {
                            var newImage = new Images()
                            {
                                ImgURL = imageData.Image,
                                ImgTitle = imageData.Title
                            };
                            newTitle.Images.Add(newImage);
                        }
                    }
                    _db.Titles.Add(newTitle);
                    _db.SaveChanges();
                }
            }
            return TitleInDatabaseId(idInApi);
        }
        [HttpGet]
        private int TitleInDatabaseId(string idInApi)
        {
            var TitleInDbAsArray = _db.Titles.Where(titleInDB => titleInDB.IdInApi == idInApi).ToArray();
            if (TitleInDbAsArray.Length>0)
            {
                return TitleInDbAsArray.FirstOrDefault().Id;
            }
            return -1;
        }
        [HttpGet]
        private Titles GetTitle(string idInApi)
        {
            int indexInDb = TitleInDatabaseId(idInApi);
            if (indexInDb == -1)
            {
                AddTitleFromAPIToDB(idInApi);
            }
            Titles title = _db.Titles.Where(x => x.IdInApi == idInApi).FirstOrDefault();
            return title;
        }
        [HttpGet]
        private Actors GetActor(string idInApi)
        {
            int indexInDb = ActorInDatabaseId(idInApi);
            if (indexInDb == -1)
            {
                AddActorFromAPIToDB(idInApi);
            }
            return _db.Actors.Where(x=>x.IdInAPI==idInApi).FirstOrDefault();
        }
        [HttpGet]
        private int ActorInDatabaseId(string idInApi)
        {
            var actorInDbAsArray = _db.Actors.Where(actorInDb => actorInDb.IdInAPI == idInApi).ToArray();
            if (actorInDbAsArray.Length > 0)
            {
                return actorInDbAsArray.FirstOrDefault().Id;
            }
            return -1;
        }
        [HttpPost]
        private int AddActorFromAPIToDB(string idInApi)
        {
            if (ActorInDatabaseId(idInApi) == -1)
            {
                var actorData = APIHelper.GetActorData(idInApi);
                if (string.IsNullOrEmpty(actorData.ErrorMessage))
                {
                    _db.Actors.Add(new Actors()
                    {
                        IdInAPI = idInApi,
                        Name = actorData.Name,
                        Role = actorData.Role,
                        Image = actorData.Image,
                        Summary =actorData.Summary,
                        BirthDate =actorData.BirthDate,
                        DeathDate = actorData.DeathDate,
                        Awards = actorData.Awards,
                        Height = actorData.Height
                    });
                    _db.SaveChanges();
                }
            }
            return ActorInDatabaseId(idInApi);
        }
        //[HttpPost]
        //private int AddSimplifiedTitleToDB(string id, string title, string imgURL, string rating)
        //{
        //    if (SimplifiedTitleInDbId(id)==-1)
        //    {
        //        _db.TitlesSimplified.Add(new TitleSimplified()
        //        {
        //            IdInApi=id,
        //            Title=title,
        //            ImgURL=imgURL,
        //            IMDbRating=rating
        //        });
        //        _db.SaveChanges();
        //    }
        //    return SimplifiedTitleInDbId(id);
        //}
        [HttpGet]
        private int SimplifiedTitleInDbId(string idInApi)
        {
            var simplifiedTitleInDbAsArray = _db.TitlesSimplified.Where(simplifiedTitle => simplifiedTitle.IdInApi == idInApi).ToArray();
            if (simplifiedTitleInDbAsArray.Length > 0)
            {
                return simplifiedTitleInDbAsArray.FirstOrDefault().Id;
            }
            return -1;
        }
        [HttpGet]
        public TitleSimplified GetTitleSimplified(string idInApi)
        {
           return _db.TitlesSimplified.Where(simplifiedTitle => simplifiedTitle.IdInApi == idInApi).FirstOrDefault();
        }
    }
}
