using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Filmly.ViewModels;
namespace Filmly.StaticClasses
{
    public static class JSONHelper
    {
        public static void WriteInLocalData<T>(T dataToAdd, string fileName)
        {
            List<T> _data = GetLocalDataAsListOfObjects<T>(fileName);
            if (_data==null)
            {
                _data = new List<T>();
            }
            _data.Add(dataToAdd);
            string json = System.Text.Json.JsonSerializer.Serialize(_data);
            File.WriteAllText(@$"./Data/LocalData/{fileName}.json", json);
        }
        public static void RewriteLocalData<T>(T dataToAdd, string fileName)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(dataToAdd);
            //replacing string, because original quality is heavy
            File.WriteAllText(@$"./Data/LocalData/{fileName}.json", json.Replace("images/original/", "images/240x330/"));
        }
        public static List<T> GetLocalDataAsListOfObjects<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(@$"./Data/LocalData/{fileName}.json"))
            {
               string json = r.ReadToEnd();
               return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
        public static T GetLocalDataAsObject<T>(string fileName)
        {
            using (StreamReader r = new StreamReader(@$"./Data/LocalData/{fileName}.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }

        }
        public static string GetLocalDataAsString(string fileName)
        {
            using (StreamReader r = new StreamReader(@$"./Data/LocalData/{fileName}.json"))
            {
                return r.ReadToEnd();
            }
        }
        public static RandomTitleData GetRandomTitleData()
        {
            var randomTitles = GetLocalDataAsListOfObjects<RandomTitleData>("RandomTitles");
            var _random = new Random();
            return randomTitles[_random.Next(0, randomTitles.Count)];
        }
    }
}
