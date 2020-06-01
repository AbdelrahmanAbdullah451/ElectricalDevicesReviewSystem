using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewArena.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Must be more than 5 charachters")]
        [Display(Name = "Product Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public int price { get; set; }

        [Required]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 20, ErrorMessage = "Must be more than 20 charachters")]
        [Display(Name = "Product Describtion")]
        public string ProductDescription { get; set; }

        [ForeignKey("Category")]
        public int category_id { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}