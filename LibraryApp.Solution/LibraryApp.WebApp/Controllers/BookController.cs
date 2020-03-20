using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LibraryApp.BusinessLayer;
using LibraryApp.Entities;

namespace LibraryApp.WebApp.Controllers
{
    public class BookController : Controller
    {
        private BusinessLayerResult<Borrow> blResultBorrow = new BusinessLayerResult<Borrow>();
        private BusinessLayerResult<Book> blResultBook = new BusinessLayerResult<Book>();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book
        public ActionResult RentBookById(int? id)
        {
            if (id != null)
            {
                User currentUser= Session["login"] as User;
                BookManager bookManager = new BookManager();
                blResultBorrow=bookManager.RentBookById(id, currentUser);
                if (blResultBorrow.BlResult != null)
                {
                    TempData["message"] = "Kitap kiralandı";
                }
                
            }

            return RedirectToAction("ShowProfile", "User");
        }

        public ActionResult LentBookById(int? id)
        {
            if (id != null)
            {
                
                BookManager bookManager = new BookManager();
                blResultBorrow = bookManager.LentBookById(id);
                if (blResultBorrow.BlResult != null)
                {
                    TempData["message"] = "Kitap ödünç verildi";
                }
            }

            return RedirectToAction("ShowProfile", "User");
;        }
    }
}