using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class Titles_Actors
    {
        [Key]
        public int TitleId { get; set; }
        public Titles Title { get; set; }

        [Key]
        public int ActorId { get; set; }
        public Actors Actor { get; set; }
    }
}
