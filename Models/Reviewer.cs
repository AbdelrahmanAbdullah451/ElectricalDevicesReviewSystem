using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewArena.Models
{
    public class Reviewer : IdentityUser
    {
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Reviews Number")]
        public int ReviewsNumber { get; set; }

        [Display(Name = "Coins Number")]
        public int CoinsNumber { get; set; }

        [Display(Name = "Likes Number")]

        public virtual ICollection<Review> Reviews { get; set; }

    }


}