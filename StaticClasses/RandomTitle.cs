using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.StaticClasses
{
    public static class RandomTitle
    {
        //key - id in imDb, value - title
        private static Dictionary<string, string> RandomTitles = new Dictionary<string, string>() {
            {"a", "a" }
        };
        public static string GetRandomTitleId()
        {
            Random random = new Random();
            return RandomTitle.RandomTitles.ElementAt(random.Next(0, RandomTitle.RandomTitles.Count)).Key;
        }
    }
}
