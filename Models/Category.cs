namespace Ebook_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Category
    {
        [Required(ErrorMessage = "Category Id is required.")]
        [Column(TypeName = "numeric")]
        public decimal CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryCode { get; set; }

        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
      
        public string CategoryImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadedCategoryImage { get; set; }
    }
}
