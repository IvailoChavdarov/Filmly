using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmly.Models;
using Filmly.ViewModels;
using RestSharp;

namespace Filmly.StaticClasses
{
    public static class APIHelper
    {
        //Public helper methods

        //Get full title information from IMDb-API by id of title
        public static TitleExtendedData GetTitleFullData(string id)
        {
            TitleExtendedData data = GetTitleExtended(id);
            data.Images = GetTitleImages(id);
            data.Trailer = GetTitleTrailer(id);
            return data;
        }
        private static TitleExtendedData GetTitleExtended(string id)
        {
            string URL = $"https://imdb-api.com/en/API/Title/{ConstantValues.APIKey}/{id}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<TitleExtendedData>(JSONResponse);
        }
        private static ImageData GetTitleImages(string id)
        {
            string URL = $"https://imdb-api.com/en/API/Images/{ConstantValues.APIKey}/{id}/Full";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<ImageData>(JSONResponse);
        }
        private static TrailerData GetTitleTrailer(string id)
        {
            string URL = $"https://imdb-api.com/en/API/Trailer/{ConstantValues.APIKey}/{id}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<TrailerData>(JSONResponse);
        }
        //Get MovieClassation from API by classation name
        public static TitleRanking GetRanking(string ranking)
        {
            if (Validators.AvailableRankings.Contains(ranking))
            {
                string URL = $"https://imdb-api.com/en/API/{ranking}/{ConstantValues.APIKey}";
                string JSONResponse = GetResponseContent(URL);
                return DeserializeStringTo<TitleRanking>(JSONResponse);
            }
            throw new ArgumentException($"Classation {ranking} is not available");
        }

        public static ThemedRanking GetBonusRanking(string ranking)
        {
            if (Validators.BonusRankings.Contains(ranking))
            {
                if (ranking.Contains("Anime"))
                {
                    string URL = $"https://imdb-api.com/API/AdvancedSearch/k_ygr1rofb?title_type=tv_series&num_votes=1000,&genres=animation&keywords=anime&sort=user_rating,desc";
                    string JSONResponse = GetResponseContent(URL);
                    return DeserializeStringTo<ThemedRanking>(JSONResponse);

                }
                else
                {
                    string URL = $"https://imdb-api.com/API/AdvancedSearch/k_ygr1rofb?title_type=tv_movie,tv_series&num_votes=10000,&genres={ranking}&sort=user_rating,desc";
                    string JSONResponse = GetResponseContent(URL);
                    return DeserializeStringTo<ThemedRanking>(JSONResponse);
                }

            }
            throw new ArgumentException($"Classation {ranking} is not available");
        }

        //Returns collection of movies coming soon, released soon
        public static NewTitleCollection GetComingSoon()
        {
                string URL = $"https://imdb-api.com/en/API/ComingSoon/{ConstantValues.APIKey}";
                string JSONResponse = GetResponseContent(URL);
                return DeserializeStringTo<NewTitleCollection>(JSONResponse);
        }
        public static NewTitleCollection GetMoviesInTheaters()
        {
            string URL = $"https://imdb-api.com/en/API/InTheaters/{ConstantValues.APIKey}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<NewTitleCollection>(JSONResponse);
        }
        //Returns search result
        public static SearchResultVM Search(string expression, string type)
        {
            if (expression=="s=")
            {
                return null;
            }
            else
            {
                if (type == null)
                {
                    type = "all";
                }
                string URL = $"https://imdb-api.com/en/API/{NameSimplifiers.TypeNames[type]}/{ConstantValues.APIKey}/{expression}";
                string JSONResponse = GetResponseContent(URL);
                var returnObj = DeserializeStringTo<SearchResultVM>(JSONResponse);
                return returnObj;
            }
        }
        
        //get movies with most box office for this weekend
        public static BoxOfficeWeekendData GetWeekendBoxOffice()
        {
            string URL = $"https://imdb-api.com/en/API/BoxOffice/{ConstantValues.APIKey}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<BoxOfficeWeekendData>(JSONResponse);
        }

        public static ActorDataAPIModel GetActorData(string id)
        {
            string URL = $"https://imdb-api.com/en/API/Name/{ConstantValues.APIKey}/{id}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<ActorDataAPIModel>(JSONResponse);
        }
        public static TitleCastModel GetTitleFullCast(string id)
        {
            string URL = $"https://imdb-api.com/en/API/FullCast/{ConstantValues.APIKey}/{id}";
            string JSONResponse = GetResponseContent(URL);
            return DeserializeStringTo<TitleCastModel>(JSONResponse);
        }
        public static ThemedRanking GetAnimeRanking(string ranking)
        {
            string URL = "";
            if (Validators.AnimeRankings.Contains(ranking))
            {
                if (ranking == "Top250Anime")
                {
                    URL = "https://imdb-api.com/API/AdvancedSearch/k_ygr1rofb?num_votes=1000,&genres=animation&countries=jp&keywords=anime&count=250&sort=user_rating,desc";
                }
                else
                {
                    URL = "https://imdb-api.com/API/AdvancedSearch/k_ygr1rofb?num_votes=1000,&genres=animation&countries=jp&keywords=anime&count=100";
                }
                string JSONResponse = GetResponseContent(URL);
                return DeserializeStringTo<ThemedRanking>(JSONResponse);
            }
            throw new ArgumentException($"Classation {ranking} is not available");
        }
        public static void DailyDataRefill()
        {
            foreach (var ranking in Validators.AvailableRankings)
            {
                if (JSONHelper.GetLocalDataAsObject<TitleRanking>(ranking).LastUpdate.ToString()!=DateTime.Today.ToString())
                {
                    TitleRanking newData = GetRanking(ranking);
                    newData.LastUpdate = DateTime.Today.ToString();
                    if (newData.ErrorMessage==null)
                    {
                        JSONHelper.RewriteLocalData<TitleRanking>(newData, ranking);
                    } 
                }
            }
            foreach (var bonusRanking in Validators.BonusRankings)
            {
                if (JSONHelper.GetLocalDataAsObject<ThemedRanking>(bonusRanking).LastUpdate.ToString() != DateTime.Today.ToString())
                {
                    ThemedRanking newData = GetBonusRanking(bonusRanking);
                    newData.LastUpdate = DateTime.Today.ToString();
                    if (newData.ErrorMessage == null)
                    {
                        JSONHelper.RewriteLocalData<ThemedRanking>(newData, bonusRanking);
                    }
                }
            }
            foreach (var animeRanking in Validators.AnimeRankings)
            {
                ThemedRanking ranking = JSONHelper.GetLocalDataAsObject<ThemedRanking>(animeRanking);
                if (ranking.LastUpdate.ToString() != DateTime.Today.ToString())
                {
                    ThemedRanking newData = GetAnimeRanking(animeRanking);
                    newData.LastUpdate = DateTime.Today.ToString();
                    if (newData.ErrorMessage == null)
                    {
                        JSONHelper.RewriteLocalData<ThemedRanking>(newData, animeRanking);
                    }
                }
            }
            if (JSONHelper.GetLocalDataAsObject<BoxOfficeWeekendData>("BoxOffice").LastUpdate.ToString() != DateTime.Today.ToString())
            {
                BoxOfficeWeekendData newData = GetWeekendBoxOffice();
                newData.LastUpdate = DateTime.Today.ToString();
                if (newData.ErrorMessage == null)
                {
                    JSONHelper.RewriteLocalData<BoxOfficeWeekendData>(newData, "BoxOffice");
                }
            }
            if (JSONHelper.GetLocalDataAsObject<NewTitleCollection>("ComingSoon").LastUpdate.ToString() != DateTime.Today.ToString())
            {
                NewTitleCollection newData = GetComingSoon();
                newData.LastUpdate = DateTime.Today.ToString();
                if (newData.ErrorMessage == null)
                {
                    JSONHelper.RewriteLocalData<NewTitleCollection>(newData, "ComingSoon");
                }
            }
            if (JSONHelper.GetLocalDataAsObject<NewTitleCollection>("InTheaters").LastUpdate.ToString() != DateTime.Today.ToString())
            {
                NewTitleCollection newData = GetMoviesInTheaters();
                newData.LastUpdate = DateTime.Today.ToString();
                if (newData.ErrorMessage == null)
                {
                    JSONHelper.RewriteLocalData<NewTitleCollection>(newData, "InTheaters");
                }
            }
        }
        //Private helper methods

        //Get JSON string content response by URL
        private static string GetResponseContent(string URL)
        {
            if (ConstantValues.UsingAPIData)
            {
                var client = new RestClient(URL);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            else
            {
                return GetResponseContent_TestData(URL);
            }

        }

        //Returns test example of the API response
        private static string GetResponseContent_TestData(string URL)
        {
            switch (URL)
            {
                case "https://imdb-api.com/en/API/Title/k_ygr1rofb/tt2560140":
                    return TestValues.Test_ResponseContentFullMovie;
                case "https://imdb-api.com/en/API/Top250Movies/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_Top250Movies;
                case "https://imdb-api.com/en/API/Top250TVs/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_Top250TVSeries;
                case "https://imdb-api.com/en/API/MostPopularMovies/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_Top100MostPopularMovies;
                case "https://imdb-api.com/en/API/MostPopularTVs/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_Top100MostPopularTVSeries;
                case "https://imdb-api.com/en/API/ComingSoon/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_ComingSoon;
                case "https://imdb-api.com/en/API/InTheaters/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_InTheaters;
                case "https://imdb-api.com/en/API/SearchTitle/k_ygr1rofb/attack on titan":
                    return TestValues.Test_ResponseContent_SearchTitle;
                case "https://imdb-api.com/en/API/SearchTitle/k_ygr1rofb/Attack on titan":
                    return TestValues.Test_ResponseContent_SearchTitle;
                case "https://imdb-api.com/en/API/Images/k_ygr1rofb/tt2560140/Full":
                    return TestValues.Test_ResponseContent_TitleImages;
                case "https://imdb-api.com/en/API/Trailer/k_ygr1rofb/tt2560140":
                    return TestValues.Test_ResponseContent_TitleTrailer;
                case "https://imdb-api.com/en/API/BoxOffice/k_ygr1rofb":
                    return TestValues.Test_ResponseContent_WeekendBoxOffice;
                default:
                    throw new ArgumentException("Return test fail");
            }
        }

        //Deserialize JSON string to .Net object of type T
        private static T DeserializeStringTo<T>(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
