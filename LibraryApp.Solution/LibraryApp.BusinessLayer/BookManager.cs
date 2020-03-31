using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
using LibraryApp.Entities.ModelViews;
using System;
using System.Collections.Generic;

namespace LibraryApp.BusinessLayer
{
    public class BookManager
    {
        private Repository<Book> repositoryBook = new Repository<Book>();
        private Repository<Category> repositoryCategory = new Repository<Category>();
        private Repository<Borrow> repositoryBorrow = new Repository<Borrow>();

        private BusinessLayerResult<Book> businessLayerResultBook = new BusinessLayerResult<Book>();
        private BusinessLayerResult<Borrow> businessLayerResultBorrow = new BusinessLayerResult<Borrow>();

        public List<Book> GetBookList()
        {
            return repositoryBook.List();
        }

        public List<Book> GetBookListAvailable()
        {
            return repositoryBook.List(x => x.IsAvailable);
        }

        public BusinessLayerResult<Borrow> RentBookById(int? id, User user)
        {
            if (id == null)
            {
                businessLayerResultBorrow.AddError(ErrorMessageCode.BookNotFound, "Kitap bulunamadı");
                return businessLayerResultBorrow;
            }

            var checkBook = repositoryBook.Find(b => b.Id == id);

            if (checkBook != null)
            {
                if (!checkBook.IsAvailable)
                {
                    businessLayerResultBorrow.AddError(ErrorMessageCode.BookCantGetRented, "Ödünç alınmış bir kitapı ödünç alamazsınız..");
                    return businessLayerResultBorrow;
                }
                Borrow newBorrow = new Borrow()
                {
                    Book = checkBook,
                    BorrowedTime = DateTime.Now,
                    IsLent = false,
                    LentTime = DateTime.Now.AddHours(24 * 7),
                    User = user
                };

                int isInserted = repositoryBorrow.Insert(newBorrow);

                if (isInserted == 0)
                {
                    businessLayerResultBorrow.AddError(ErrorMessageCode.CouldNotBorrowed, "Kitap kiralanamadı");
                }
                else
                {
                    UpdateBookAfterBorrow(checkBook.Id);
                    businessLayerResultBorrow.BlResult = newBorrow;
                }
            }

            return businessLayerResultBorrow;
        }

        public void UpdateBookAfterBorrow(int? id)
        {
            if (id != null)
            {
                var checkBook = repositoryBook.Find(b => b.Id == id);

                checkBook.IsAvailable = !checkBook.IsAvailable;

                repositoryBook.Update(checkBook);
            }
        }

        public BusinessLayerResult<Borrow> LentBookById(int? id)
        {
            if (id == null)
            {
                businessLayerResultBorrow.AddError(ErrorMessageCode.BookNotFound, "Kitap bulunamadı");
            }
            else
            {
                Borrow checkBorrow = repositoryBorrow.Find(b => b.Id == id);

                if (checkBorrow != null)
                {
                    checkBorrow.IsLent = true;

                    repositoryBorrow.Update(checkBorrow);

                    UpdateBookAfterBorrow(checkBorrow.Book.Id);
                }
            }

            return businessLayerResultBorrow;
        }

        public BusinessLayerResult<Book> AddBook(AddBookViewModel addBookViewModel)
        {
            if (addBookViewModel != null)
            {
                var lstCategories = new CategoryManager().GetCategories();

                if (repositoryBook.Find(x => x.Isbn == addBookViewModel.Isbn) != null)
                {
                    businessLayerResultBook.AddError(ErrorMessageCode.IsbnAlreadyExists, "Bu ISBN veritabanında bulunmaktadır");
                    return businessLayerResultBook;
                }

                Book newBook = new Book()
                {
                    Name = addBookViewModel.Name,
                    Summary = addBookViewModel.Summary,
                    Author = addBookViewModel.Author,
                    PublishedDate = addBookViewModel.PublishedDate,
                    Language = addBookViewModel.Language,
                    PageCount = addBookViewModel.PageCount,
                    Isbn = addBookViewModel.Isbn,
                    CategoryId = addBookViewModel.CategoryId,
                    IsAvailable = addBookViewModel.IsAvailable,
                };

                var checkIsBookInserted = repositoryBook.Insert(newBook);

                if (checkIsBookInserted > 0)
                {
                    businessLayerResultBook.BlResult = newBook;
                }
                else
                {
                    businessLayerResultBook.AddError(ErrorMessageCode.BookCouldNotAdded, "Kitap eklenemedi..");
                }
            }

            return businessLayerResultBook;
        }

        public BusinessLayerResult<Book> RemoveBookById(int? id)
        {
            businessLayerResultBook.BlResult = repositoryBook.Find(x => x.Id == id);

            if (businessLayerResultBook.BlResult != null)
            {
                if (!businessLayerResultBook.BlResult.IsAvailable)
                {
                    businessLayerResultBook.AddError(ErrorMessageCode.BookCouldNotDeleted, "Kiralanmış kitabı silemezsiniz..");
                }
                else
                {
                    var borrowsRelatedBooks = repositoryBorrow.List(x => x.Book.Id == id);

                    if (borrowsRelatedBooks.Count > 0)
                    {
                        foreach (var borrowsRelatedBook in borrowsRelatedBooks)
                        {
                            repositoryBorrow.Delete(borrowsRelatedBook);
                        }
                    }

                    repositoryBook.Delete(businessLayerResultBook.BlResult);
                }
            }
            else
            {
                businessLayerResultBook.AddError(ErrorMessageCode.BookNotFound, "Silinecek kitap bulunamadı");
            }

            return businessLayerResultBook;
        }
    }
}