using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.Entities.ModelViews;
using System.Web.Mvc;

namespace LibraryApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Test um = new Test();
            //var z = um.GetUserList();
            return View();
            // return View();
        }

        public ActionResult CategoryList()
        {
            var categoryManager = new CategoryManager();

            return View(categoryManager.GetCategories());
        }

        public ActionResult BookList()
        {
            var bookManager = new BookManager();

            return View(bookManager.GetBookList());
        }

        public ActionResult Book(int? id)
        {
            CategoryManager categoryManager = new CategoryManager();
            if (id != null)
            {
                var catById = categoryManager.GetBookListByCategoryId(id);
                ViewBag.CategoryName = catById.Name;
                return View(catById.Books);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterViewModel registerViewModel)
        {
            //  UserManager userManager = new UserManager();
            if (ModelState.IsValid)
            {
                //  userManager.RegisterUser()
                UserManager userManager = new UserManager();
                BusinessLayerResult<User> res = userManager.RegisterUser(registerViewModel);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("Errors from database", x));
                    return View(registerViewModel);
                }

                return RedirectToAction("Index");
            }
            return View(registerViewModel);
        }

        public ActionResult LoginUser()
        {
            return View();
        }
          
        [HttpPost]
        public ActionResult LoginUser(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                BusinessLayerResult<User> res = userManager.LoginUser(loginViewModel);

                if (res != null)
                {
                    if (res.Errors.Count > 0)
                    {
                        res.Errors.ForEach(x => ModelState.AddModelError("Errors from database",x));
                        return View(loginViewModel);
                    }

                    Session["login"] = res.BlResult;
                    return RedirectToAction("Index");
                }
            }

            return View(loginViewModel);
        }

        public ActionResult LogOut()
        {
            if(Session["login"] != null)
                Session.RemoveAll();

            return RedirectToAction("Index");
        }
    }

}