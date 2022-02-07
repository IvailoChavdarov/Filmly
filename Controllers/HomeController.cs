﻿using Filmly.Models;
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

namespace Filmly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            HomePageData newsInfo = new HomePageData();
            var ComingSoonWithImages = JSONHelper.GetLocalDataAsObject<NewTitleCollection>("ComingSoon");
            ComingSoonWithImages.Items = ComingSoonWithImages.Items.Where(x => x.Image != "https://imdb-api.com/images/128x176/nopicture.jpg").ToArray();
            newsInfo.ComingSoon = ComingSoonWithImages;
            NewTitleCollection InTheatersWithImages = JSONHelper.GetLocalDataAsObject<NewTitleCollection>("InTheaters");
            InTheatersWithImages.Items = InTheatersWithImages.Items.Where(x => x.Image != "https://imdb-api.com/images/128x176/nopicture.jpg").ToArray();
            newsInfo.InTheaters = InTheatersWithImages;
            BoxOfficeWeekendData BoxOfficesRanked = JSONHelper.GetLocalDataAsObject<BoxOfficeWeekendData>("BoxOffice");
            BoxOfficesRanked.Items = BoxOfficesRanked.Items.OrderByDescending(x => x.Gross).ToArray();
            newsInfo.WeekendBoxOffice = BoxOfficesRanked;
            APIHelper.DailyDataRefill();
            return View(newsInfo);
        }
        public IActionResult News()
        {
            List<NewsItem> Details = new List<NewsItem>();
            string searchFor = "cinema";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://news.google.com/news?q="+ searchFor + "&output=rss");

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
                        DataObj.Title = dtRow["title"].ToString();
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
        public IActionResult Contacts()
        {
            ContactsVM data = new ContactsVM();
            data.BreadcrumbData = new BreadcrumbData()
            {
                ControllerName = "Home",
                ControllerPublicName = "Home",
                ActionName = "contacts",
                ActionPublicName = "Contact us"
            };
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddImage()
        {
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
