using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;

namespace LibraryApp.BusinessLayer
{
    public class BookManager
    {
        private Repository<Book> repositoryBook = new Repository<Book>();
        private Repository<Category> repositoryCategory = new Repository<Category>();

        public List<Book> GetBookList()
        {
           return repositoryBook.List();
        }

       
    }
}
