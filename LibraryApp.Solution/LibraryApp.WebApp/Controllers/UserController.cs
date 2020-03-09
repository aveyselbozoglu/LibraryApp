using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using System.Web.Mvc;

namespace LibraryApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ShowProfile()
        {
            User currentUser = Session["login"] as User;

            UserManager userManager = new UserManager();
            BusinessLayerResult<User> businessLayerResultUser = new BusinessLayerResult<User>();
            //BusinessLayerResult<Borrow> businessLayerResultBorrow = new BusinessLayerResult<Borrow>();

            //// deneme

            //var listOfBorrowsById = userManager.GetBorrowsByUserId(currentUser.Id);

            //TempData["ListOfDataById"] = listOfBorrowsById;

            //deneme son
            businessLayerResultUser = userManager.GetUserById(currentUser.Id);

            if (businessLayerResultUser.ErrorMessageObj.Count > 0)
            {
                // todo : hata ekranı yönlendirmesi
            }

            return View(businessLayerResultUser.BlResult);
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            return View();
        }

        public ActionResult RemoveProfile(int id)
        {
            UserManager user = new UserManager();
            BusinessLayerResult<User> businessLayerResult = user.RemoveUserById(id);
            if (businessLayerResult.ErrorMessageObj.Count > 0)
            {
                // todo : hata ekranı yönlendirmesi
            }

            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}