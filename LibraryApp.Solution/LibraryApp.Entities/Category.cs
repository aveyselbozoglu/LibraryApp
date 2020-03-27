using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class Category : EntityBase
    {
        
        [Display(Name = "Adı"),
         Required, StringLength(50)]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public Category()
        {
            Books = new List<Book>();
        }
    }
}