using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
using System;
using System.Collections.Generic;

namespace LibraryApp.BusinessLayer
{
    public class BookManager
    {
        private Repository<Book> repositoryBook = new Repository<Book>();
        private Repository<Category> repositoryCategory = new Repository<Category>();
        private Repository<Borrow> repositoryBorrow = new Repository<Borrow>();

        //private BusinessLayerResult<Book> businessLayerResult = new BusinessLayerResult<Book>();
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
            }

            var checkBook = repositoryBook.Find(b => b.Id == id);

            if (checkBook != null)
            {
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
                if (checkBook.IsAvailable)
                {
                    checkBook.IsAvailable = false;
                }
                else
                {
                    checkBook.IsAvailable = true;
                }

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
    }
}