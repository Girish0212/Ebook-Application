namespace Ebook_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Book
    {
        [Required]
        [Column(TypeName = "numeric")]
        public decimal BookId { get; set; }

        [Required]
       
        [StringLength(40)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(20)]
        public string BookCode { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^(?!.*([ ])\\1)(?!.*([A-Za-z])\\2{2})\\w[a-zA-Z ]*$")]
        public string BookName { get; set; }

        [Required]
       
        [StringLength(500)]
        public string Description { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Image { get; set; }

        [NotMapped]
        public List<Category> CategoryList { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadedImage { get; set; }

        [NotMapped]
        public List<Book> Books { get; set; }
    }
}
