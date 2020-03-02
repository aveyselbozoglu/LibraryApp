using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Category : EntityBase
    {
        [Required,StringLength(50)]
        public string Name { get; set; }

        public List<Book> Books{ get; set; }

        public Category()
        {
            Books=  new List<Book>();
        }

    }
}
