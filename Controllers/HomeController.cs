using Filmly.Models;
using Filmly.StaticClasses;
using Filmly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace Filmly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;

            //added for starting the project from another device
            //CreateAdminRole();
            //CreateResearcherRole();
            //CreateModeratorRole();
        }

        public IActionResult Index()
        {
            APIHelper.DailyDataRefill();
            HomePageData data = new HomePageData();
            var ComingSoonWithImages = JSONHelper.GetLocalDataAsObject<NewTitleCollection>("ComingSoon");
            ComingSoonWithImages.Items = ComingSoonWithImages.Items.Where(x => x.Image != "https://imdb-api.com/images/128x176/nopicture.jpg").ToArray();
            data.ComingSoon = ComingSoonWithImages;

            NewTitleCollection InTheatersWithImages = JSONHelper.GetLocalDataAsObject<NewTitleCollection>("InTheaters");
            InTheatersWithImages.Items = InTheatersWithImages.Items.Where(x => x.Image != "https://imdb-api.com/images/128x176/nopicture.jpg").ToArray();
            data.InTheaters = InTheatersWithImages;

            BoxOfficeWeekendData BoxOfficesRanked = JSONHelper.GetLocalDataAsObject<BoxOfficeWeekendData>("BoxOffice");
            BoxOfficesRanked.Items = BoxOfficesRanked.Items.OrderByDescending(x => x.Gross).ToArray();
            data.WeekendBoxOffice = BoxOfficesRanked;

            data.Top10MostPopularMovies = JSONHelper.GetLocalDataAsObject<TitleRanking>(NameSimplifiers.RankingNamesDictionary["top-100-most-popular-movies"]).Items.Take(10).ToList();
            data.Top10BestMovies = JSONHelper.GetLocalDataAsObject<TitleRanking>(NameSimplifiers.RankingNamesDictionary["top-250-movies"]).Items.Take(10).ToList();

            data.Top10MostPopularTVSeries = JSONHelper.GetLocalDataAsObject<TitleRanking>(NameSimplifiers.RankingNamesDictionary["top-100-most-popular-tv-series"]).Items.Take(10).ToList();
            data.Top10BestTVSeries = JSONHelper.GetLocalDataAsObject<TitleRanking>(NameSimplifiers.RankingNamesDictionary["top-250-tv-series"]).Items.Take(10).ToList();

            data.Top10MostPopularAnime = JSONHelper.GetLocalDataAsObject<ThemedRanking>(NameSimplifiers.RankingNamesDictionary["top-100-most-popular-anime"]).Results.Take(10).ToList();
            data.Top10BestAnime = JSONHelper.GetLocalDataAsObject<ThemedRanking>(NameSimplifiers.RankingNamesDictionary["top-250-anime"]).Results.Take(10).ToList();
            return View(data);
        }
        public IActionResult News(string id)
        {
            string searchFor = "cinema";
            if (!string.IsNullOrEmpty(id))
            {
                searchFor = id;
            }
            List<NewsItem> Details = new List<NewsItem>();
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://news.google.com/news?q="+ searchFor + "&output=rss");
            request.Headers.Add("Cache-Control: no-store");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == "")
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string newsData = readStream.ReadToEnd();

                //Declare DataSet for putting data in it.
                DataSet ds = new DataSet();
                StringReader reader = new StringReader(newsData);
                ds.ReadXml(reader);
                DataTable dtGetNews = new DataTable();

                if (ds.Tables.Count > 3)
                {
                    dtGetNews = ds.Tables["item"];

                    foreach (DataRow dtRow in dtGetNews.Rows)
                    {
                        NewsItem DataObj = new NewsItem();
                        DataObj.Title = Regex.Replace(dtRow["title"].ToString(), "<.*?>", String.Empty);
                        DataObj.Link = dtRow["link"].ToString();
                        DataObj.Item_id = dtRow["item_id"].ToString();
                        DataObj.PubDate = dtRow["pubDate"].ToString();
                        DataObj.Description = dtRow["description"].ToString();
                        Details.Add(DataObj);
                    }
                }
            }
            NewsVM data = new NewsVM();
            data.News = Details.ToList();
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "home",
                ControllerPublicName = "Home",
                ActionName = "news",
                ActionPublicName = "News about " + searchFor
            };
            return View(data);
        }
        public IActionResult History()
        {
            HistoryEventsVM data = new HistoryEventsVM();
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "home",
                ControllerPublicName = "Home",
                ActionName = "history",
                ActionPublicName = "Cinema's history"
            };
            return View(data);
        }
        public IActionResult InterestingFacts()
        {
            InterestingFactsVM data = new InterestingFactsVM();
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "Home",
                ControllerPublicName = "Home",
                ActionName = "interestingfacts",
                ActionPublicName = "Interesting facts"
            };

            return View(data);
        }
        public IActionResult Developer()
        {
            StaticPagesData breadcrumb = new StaticPagesData();
            breadcrumb.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "Home",
                ControllerPublicName = "Home",
                ActionName = "developer",
                ActionPublicName = "Developer"
            };
            return View(breadcrumb);
        }
        public IActionResult Privacy()
        {
            StaticPagesData breadcrumb = new StaticPagesData();
            breadcrumb.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "Home",
                ControllerPublicName = "Home",
                ActionName = "privacy",
                ActionPublicName = "Privacy"
            };
            return View(breadcrumb);
        }
        public IActionResult Documentation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
