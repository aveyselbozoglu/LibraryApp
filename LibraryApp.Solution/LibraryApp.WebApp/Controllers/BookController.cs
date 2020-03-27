using System.Collections.Generic;
using System.Data;
using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.WebApp.NotifyModels;
using System.Web.Mvc;
using LibraryApp.Entities.ModelViews;

namespace LibraryApp.WebApp.Controllers
{
    public class BookController : Controller
    {
        private BusinessLayerResult<Borrow> blResultBorrow = new BusinessLayerResult<Borrow>();
        private BusinessLayerResult<Book> blResultBook = new BusinessLayerResult<Book>();
        private BusinessLayerResult<Category> blResultCategory = new BusinessLayerResult<Category>();




        
        public ActionResult RentBookById(int id)
        {
            User currentUser = Session["login"] as User;
            BookManager bookManager = new BookManager();
            blResultBorrow = bookManager.RentBookById(id, currentUser);

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
                Title = "Kitap ödünç alındı , lütfen 15 gün içinde iade ediniz.."
            };
            return View("Ok", okViewModel);
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

            return RedirectToAction("BookList","Home");
        }


        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}