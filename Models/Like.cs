using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewArena.Models
{
    public class Like
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Liked at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime LikeAddedAt { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }


    }
}