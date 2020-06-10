using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewArena.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "Review title")]
        public string ReviewTitle { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "Review Pros")]
        public string Pros { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "Review Cons")]
        public string Cons { get; set; }

        [Required]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Review Image")]
        public string ReviewImage { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 20, ErrorMessage = "Must be more than 20 charachters")]
        [Display(Name = "Review Describtion")]
        public string ReviewDescription { get; set; }

        [Display(Name = "Added at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public  System.DateTime AddedAt { get; set; }

        [Display(Name ="Likes")]
        public int LikesNumber { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }



        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}