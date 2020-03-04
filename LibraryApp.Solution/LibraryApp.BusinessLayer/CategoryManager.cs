using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;

namespace LibraryApp.BusinessLayer
{
    public class CategoryManager
    {
        private Repository<Category> repositoryCategory = new Repository<Category>();
        public List<Category> GetCategories()
        {

            
            return (repositoryCategory.List());

        }

        public Category GetBookListByCategoryId(int? id)
        {
            return repositoryCategory.Find(c =>  c.Id == id.Value);
            
        }

    }
}
