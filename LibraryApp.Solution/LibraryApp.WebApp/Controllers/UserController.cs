using System.Web;
using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.WebApp.NotifyModels;
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

            businessLayerResultUser = userManager.GetUserById(currentUser.Id);

            if (businessLayerResultUser.ErrorMessageObj.Count > 0)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = businessLayerResultUser.ErrorMessageObj,
                };
                return View("Error", errorViewModel);
            }

            AddressManager addressManager = new AddressManager();
            var businessLayerResultAddress = addressManager.GetAllAddressesByUserId(currentUser.Id);

            TempData["addresses"] = businessLayerResultAddress.BlResultList;

            return View(businessLayerResultUser.BlResult);
        }

        public ActionResult EditProfile()
        {
            User user = Session["login"] as User;

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User modelUser,HttpPostedFileBase ProfileImage)
        {
            //ModelState.Remove("ProfileImageFileName");

            BusinessLayerResult<User> businessLayerResultUser = new BusinessLayerResult<User>();
            UserManager userManager = new UserManager();
            if (ModelState.IsValid)
            {
                if (ProfileImage != null &&
                    (ProfileImage.ContentType == "image/jpg" ||
                    ProfileImage.ContentType == "image/jpeg" ||
                    ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{modelUser.Id}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"/Images/{filename}"));
                    modelUser.ProfileImageFileName = filename;
                }
                   
                businessLayerResultUser = userManager.UpdateUser(modelUser);

                if (businessLayerResultUser.ErrorMessageObj.Count > 0)
                {
                    ErrorViewModel errorViewModel = new ErrorViewModel()
                    {
                        Items = businessLayerResultUser.ErrorMessageObj,
                        RedirectingUrl = "/User/ShowProfile"
                    };
                    return View("Error", errorViewModel);
                }

                Session["login"] = businessLayerResultUser.BlResult;
                OkViewModel okViewModel = new OkViewModel()
                {
                    Title = "Kullanıcı güncellendi",
                    RedirectingUrl = "/User/ShowProfile"
                };
                return View("Ok", okViewModel);
            }
            else
            {
                return View(modelUser);
            }
        }

        public ActionResult RemoveProfile(int id)
        {
            UserManager user = new UserManager();
            BusinessLayerResult<User> businessLayerResult = user.RemoveUserById(id);
            if (businessLayerResult.ErrorMessageObj.Count > 0)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    RedirectingUrl = "/User/ShowProfile",
                    Items = businessLayerResult.ErrorMessageObj
                };
                return View("Error", errorViewModel);
            }

            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}