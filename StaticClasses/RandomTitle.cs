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
            {"tt0899258", "D.Gray-man" },
            {"tt5954268", "D.Gray-man Hallow" },
            {"tt0120737", "The Lord of the Rings: The Fellowship of the Ring" },
            {"tt0167261", "The Lord of the Rings: The Two Towers" },
            {"tt0167260", "The Lord of the Rings: The Return of the King" },
            {"tt9335498", "Demon Slayer: Kimetsu no Yaiba" },
            {"tt1355642", "Fullmetal Alchemist: Brotherhood" },
            {"tt0877057", "Death Note" },
            {"tt12343534", "Jujutsu Kaisen" },
            {"tt13196080", "Tokyo Revengers" },
            {"tt5626028", "My Hero Academia" },
            {"tt4508902", "One Punch Man" },
            {"tt5370118", "Konosuba: God's Blessing on This Wonderful World!" },
            {"tt7366338", "Chernobyl" },
            {"tt0337898", "Brigada" },
            {"tt2930610", "The kitchen" },
            {"tt0120812", "Rush hour" },
            {"tt0266915", "Rush hour 2" },
            {"tt0293564", "Rush hour 3" },
            {"tt0126029", "Shrek" },
            {"tt0298148", "Shrek 2" },
            {"tt0417299", "Avatar: The Last Airbender" },
            {"tt4154756", "Avengers: Infinity War" },
            {"tt0848228", "The Avengers" },
            {"tt0903624", "The Hobbit: An Unexpected Journey" },
            {"tt2369135", "Need for Speed" },
            {"tt0232500", "The Fast and the Furious" },
            {"tt1013752", "Fast & Furious" },
            {"tt1001471", "Eon Kid" },
            {"tt0278238", "Samurai Jack" },
            {"tt1392170", "The Hunger Games" },
            {"tt2560140", "Attack on Titan" },
            {"tt12415546", "Attack on Titan: Chronicle" },
            {"tt3007512", "The Water Diviner" },
            {"tt0091431", "Armour of God" },
            {"tt0327437", "Around the World in 80 Days" },
            {"tt0363771", "The Chronicles of Narnia: The Lion, the Witch and the Wardrobe" },
            {"tt0892769", "How to Train Your Dragon" },
            {"tt0268380", "Ice Age" },
            {"tt1080016", "Ice Age: Dawn of the Dinosaurs" },
            {"tt0441773", "Kung Fu Panda" },
            {"tt1431045", "Deadpool" },
            {"tt0325980", "Pirates of the Caribbean: The Curse of the Black Pearl" },
            {"tt1660055", "Scooby-Doo! Mystery Incorporated" },
            {"tt0290057", "Scooby-Doo and the Cyber Chase" },
            {"tt1951264", "The Hunger Games: Catching Fire" },
            {"tt0087928", "Police Academy" },
            {"tt1291150", "Teenage Mutant Ninja Turtles" },
            {"tt0477347", "Night at the Museum" }
        };
        public static string GetRandomTitleId()
        {
            Random random = new Random();
            return RandomTitle.RandomTitles.ElementAt(random.Next(0, RandomTitle.RandomTitles.Count)).Key;
        }
    }
}
