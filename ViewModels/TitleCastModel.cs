using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.ViewModels
{
        public class TitleCastModel
        {
            public string ImDbId { get; set; }
            public string Title { get; set; }
            public string FullTitle { get; set; }
            public string Type { get; set; }
            public string Year { get; set; }
            public Directors Directors { get; set; }
            public Writers Writers { get; set; }
            public Actor[] Actors { get; set; }
            public Others[] Others { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class Directors
        {
            public string Job { get; set; }
            public BehindTheScenesCast[] Items { get; set; }
        }


        public class Writers
        {
            public string Job { get; set; }
            public BehindTheScenesCast[] Items { get; set; }
        }

        public class Others
        {
            public string Job { get; set; }
            public BehindTheScenesCast[] Items { get; set; }
        }

        public class BehindTheScenesCast
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

    }

