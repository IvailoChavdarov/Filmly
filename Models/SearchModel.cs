using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    [NotMapped]
    public class SearchModel
    {
        [Required]
        public string Title { get; set; }
    }
}
