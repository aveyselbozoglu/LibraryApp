using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.Entities.ModelViews;
using LibraryApp.WebApp.NotifyModels;
using System.Web.Mvc;
using LibraryApp.WebApp.Filters;
using LibraryApp.WebApp.Models;

namespace LibraryApp.WebApp.Controllers
{
    [Auth]
    public class BookController : Controller
    {
        private BusinessLayerResult<Book> blResultBook = new BusinessLayerResult<Book>();
        private BusinessLayerResult<Borrow> blResultBorrow = new BusinessLayerResult<Borrow>();
        private BusinessLayerResult<Category> blResultCategory = new BusinessLayerResult<Category>();

        [AuthAdmin]
        public ActionResult AddBook()
        {
            blResultCategory.BlResultList = new CategoryManager().GetCategories();

            if (blResultCategory.BlResultList != null)
            {
                ViewBag.Categories = new SelectList(blResultCategory.BlResultList, "Id", "Name");

                // todo BOOKVIEWMODELLE OLMADI , ÇÜNKÜ VIEWMODELDE KATEGORi var direk , database modelimizde category_id olarak tutuluyor.
            }

            return View();
        }

        [AuthAdmin]
        [HttpPost]
        public ActionResult AddBook(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                var blResultBook = new BookManager().AddBook(addBookViewModel);

                if (blResultBook.ErrorMessageObj.Count > 0)
                {
                    ErrorViewModel errorViewModel = new ErrorViewModel()
                    {
                        Items = blResultBook.ErrorMessageObj,
                        RedirectingUrl = "/Book/AddBook"
                    };
                    return View("Error", errorViewModel);
                }
                OkViewModel okViewModel = new OkViewModel()
                {
                    Title = "Yeni kitap eklendi.."
                };

                return View("Ok", okViewModel);
            }
            //ViewBag.Categories = new SelectList(blResultCategory.BlResultList, "Id", "Name");
            return View(addBookViewModel);
        }

        [AuthAdmin]
        public ActionResult DeleteBook(int? id)
        {
            blResultBook = new BookManager().RemoveBookById(id);

            if (blResultBook.ErrorMessageObj.Count > 0)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    RedirectingUrl = "/Home/BookList",
                    Items = blResultBook.ErrorMessageObj
                };
                return View("Error", errorViewModel);
            }

            return RedirectToAction("BookList", "Home");
        }

        public ActionResult LentBookById(int id)
        {
            BookManager bookManager = new BookManager();
            blResultBorrow = bookManager.LentBookById(id);
            if (blResultBorrow.BlResult == null)
            {
                OkViewModel okViewModel = new OkViewModel()
                {
                    Title = "Kitap iade ettiniz..",
                    RedirectingUrl = "/User/ShowProfile"
                };
                return View("Ok", okViewModel);
            }

            ErrorViewModel errorViewModel = new ErrorViewModel()
            {
                Items = blResultBorrow.ErrorMessageObj,
            };
            return View("Error", errorViewModel);
        }

        public ActionResult RentBookById(int id)
        {
            
            BookManager bookManager = new BookManager();
            blResultBorrow = bookManager.RentBookById(id, CurrentSession.User);

            if (blResultBorrow.BlResult == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Items = blResultBorrow.ErrorMessageObj,
                };
                return View("Error", errorViewModel);
            }
            OkViewModel okViewModel = new OkViewModel()
            {
                RedirectingUrl = "/User/ShowProfile",
                Title = "Kitap ödünç alındı , lütfen 15 gün içinde iade ediniz.."
            };
            return View("Ok", okViewModel);
        }
    }
}