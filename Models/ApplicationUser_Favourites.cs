using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class ApplicationUser_Favourites
    {
        [Key]
        public string ApplicationUserID { get; set; }
        [Key]
        public int TitleId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Titles Title { get; set; }
    }
}
