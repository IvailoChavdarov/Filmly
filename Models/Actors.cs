using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class Actors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
            public string IdInAPI { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string Image { get; set; }
            public string Summary { get; set; }
            public string BirthDate { get; set; }
            public string DeathDate { get; set; }
            public string Awards { get; set; }
            public string Height { get; set; }
            public HashSet<Titles_Actors> CastMovies { get; set; }
    }
}
