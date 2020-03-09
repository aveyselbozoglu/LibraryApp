using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.BusinessLayer;
using LibraryApp.Entities;

namespace LibraryApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ShowProfile()
        {
            User currentUser = Session["login"] as User;

                UserManager userManager = new UserManager();
                BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();
                
                businessLayerResult=userManager.GetUserById(currentUser.Id);

                if (businessLayerResult.ErrorMessageObj.Count > 0)
                {
                    // todo : hata ekranı yönlendirmesi
                }

                return View(businessLayerResult.BlResult);
                

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
            BusinessLayerResult<User> businessLayerResult= user.RemoveUserById(id);
            if (businessLayerResult.ErrorMessageObj.Count > 0)
            {
                // todo : hata ekranı yönlendirmesi
            }

            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}