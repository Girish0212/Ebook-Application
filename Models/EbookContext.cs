using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ebook_Application.Models
{
    public partial class EbookContext : DbContext
    {
        public EbookContext()
            : base("name=Ebook")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
       
        //public virtual DbSet<CartList> Cart { get; set; }


        
    }
}
