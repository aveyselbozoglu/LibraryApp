using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using System.Collections.Generic;

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
            return repositoryCategory.Find(c => c.Id == id.Value);
        }
    }
}