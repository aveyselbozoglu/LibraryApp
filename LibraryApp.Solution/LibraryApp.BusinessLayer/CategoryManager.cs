using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
using System.Collections.Generic;

namespace LibraryApp.BusinessLayer
{
    public class CategoryManager
    {
        private Repository<Category> repositoryCategory = new Repository<Category>();
        private Repository<Book> repositoryBook = new Repository<Book>();
        private Repository<Borrow> repositoryBorrow = new Repository<Borrow>();
        private BusinessLayerResult<Category> businessLayerResultCategory = new BusinessLayerResult<Category>();

        public List<Category> GetCategories()
        {
            return (repositoryCategory.List());
        }

        public Category GetBookListByCategoryId(int? id)
        {
            return repositoryCategory.Find(c => c.Id == id.Value);
        }

        public BusinessLayerResult<Category> AddCategory(Category category)
        {
            if (category != null)
            {
                Category checkCategory = repositoryCategory.Find(x => x.Name == category.Name);
                if (checkCategory == null)
                {
                    repositoryCategory.Insert(category);
                    businessLayerResultCategory.BlResult = category;
                }
                else
                {
                    businessLayerResultCategory.AddError(ErrorMessageCode.CategoryAlreadyExisted, "Var olan bir kategoriyi ekleyemezsiniz.");
                }
            }
            return businessLayerResultCategory;
        }

        public BusinessLayerResult<Category> DeleteCategory(int? id)
        {
            if (id != null)
            {
                var checkCategory = repositoryCategory.Find(x => x.Id == id);

                if (checkCategory != null)
                {
                    var booksRelatedCategory = repositoryBook.List(x => x.Category.Id == id);

                    if (booksRelatedCategory.Count > 0)
                    {
                        foreach (var bookRelatedCategory in booksRelatedCategory)
                        {
                            var borrows = repositoryBorrow.List(x => x.Book.Id == bookRelatedCategory.Id);

                            if (borrows.Count > 0)
                            {
                                foreach (var borrow in borrows)
                                {
                                    repositoryBorrow.Delete(borrow);
                                }
                            }

                            repositoryBook.Delete(bookRelatedCategory);
                        }
                    }

                    int checkDeleteCategory = repositoryCategory.Delete(checkCategory);

                    if (checkDeleteCategory != 0)
                    {
                        businessLayerResultCategory.BlResult = checkCategory;
                    }
                }
                else
                {
                    businessLayerResultCategory.AddError(ErrorMessageCode.CategoryNotFound, "Sİlinecek kategori bulunamadı");
                }
            }

            return businessLayerResultCategory;
        }
    }
}