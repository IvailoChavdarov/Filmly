using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Filmly.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUser_Favourites = new HashSet<ApplicationUser_Favourites>();
            this.ApplicationUser_WatchList = new HashSet<ApplicationUser_ToWatch>();
        }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public string ProfileImage { get; set; }
        public HashSet<ApplicationUser_Favourites> ApplicationUser_Favourites { get; set; }
        public HashSet<ApplicationUser_ToWatch> ApplicationUser_WatchList { get; set; }
        public HashSet<DiscussionComment> UserComments { get; set; }
        public HashSet<Article> ArticlesWritten { get; set; }
    }
}
