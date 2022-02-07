using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class TitleSimplified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string IdInApi { get; set; }
        [Required]
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string IMDbRating { get; set; }
        public HashSet<Similars> Similar { get; set; }
    }
}
