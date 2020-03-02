using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string WriterName { get; set; }
        public DateTime PublishedDate { get; set; }
        public int PageCount { get; set; }
        public string Isbn { get; set; }
        public string Language { get; set; }

        public virtual Category Category { get; set; }

        public List<Borrow> Borrows { get; set; }

        

    }
}
