using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class Discussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Topic { get; set; }
        public string Content { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Theme { get; set; }
        [Required]
        public string DateCreated { get; set; }
        public string CreatorId { get; set; }
        public HashSet<DiscussionComment> Comments { get; set; }
        public ApplicationUser Creator { get; set; }
    }
}
