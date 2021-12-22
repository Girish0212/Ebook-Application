namespace Ebook_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Column(TypeName = "numeric")]
        public decimal CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryCode { get; set; }

        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
    }
}
