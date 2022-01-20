namespace Ebook_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        [Required]
        [StringLength(50)]
        public string BookName { get; set; }

        
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
