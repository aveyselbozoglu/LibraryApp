using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
using LibraryApp.Entities.ModelViews;
using LibraryApp.WebApp.NotifyModels;
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

            // return View();
            BookManager testBookManager = new BookManager();
            testBookManager.GetBookList();
            return View();
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

        public ActionResult BookListAvailable()
        {
            var bookManager = new BookManager();

            return View(bookManager.GetBookListAvailable());
        }

        public ActionResult BookByCategory(int? id)
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

                if (res.ErrorMessageObj.Count > 0)
                {
                    res.ErrorMessageObj.ForEach(x => ModelState.AddModelError("", x.Message));

                    //res.Errors.ForEach(x => ModelState.AddModelError("Errors from database", x));
                    return View(registerViewModel);
                }

                OkViewModel okViewModel = new OkViewModel();
                okViewModel.Items.Add(new ErrorMessageObj()
                {
                    Code = ErrorMessageCode.EmailOrPassWrong,
                    Message = "Kayıt işleminiz Başarılı",
                });

                okViewModel.RedirectingUrl = "/Home/LoginUser";
                //return RedirectToAction("Index");
                return View("Ok", okViewModel);
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
                    if (res.ErrorMessageObj.Count > 0)
                    {
                        res.ErrorMessageObj.ForEach(x => ModelState.AddModelError(" ", x.Message));

                        //res.Errors.ForEach(x => ModelState.AddModelError("Errors from database",x));
                        return View(loginViewModel);
                    }

                    Session["login"] = res.BlResult;

                    OkViewModel okViewModel = new OkViewModel()
                    {
                        Title = "Giriş yaptınız"
                    };
                    //return RedirectToAction("Index");
                    return View("Ok", okViewModel);
                }
            }

            return View(loginViewModel);
        }

        public ActionResult LogOut()
        {
            if (Session["login"] != null)
                Session.RemoveAll();

            return RedirectToAction("Index");
        }
    }
}