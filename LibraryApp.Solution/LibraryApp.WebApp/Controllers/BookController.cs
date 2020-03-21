using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.WebApp.NotifyModels;
using System.Web.Mvc;

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
            ;
        }
    }
}