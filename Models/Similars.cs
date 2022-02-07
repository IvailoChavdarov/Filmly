using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class Similars
    {
        [Key]
        public int TitleId { get; set; }
        [Key]
        public int SimilarId { get; set; }
        public Titles Title { get; set; }
        public TitleSimplified Similar { get; set; }
        
    }
}
