using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmly.Models
{
    public class DiscussionComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }
        [Required]
        public int DiscussionId { get; set; }
        public int? ParentCommentId { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DiscussionComment ParentComment { get; set; }
        public Discussion Discussion { get; set; }
        public HashSet<DiscussionComment> ChildrenComents { get; set; }
    }
}
