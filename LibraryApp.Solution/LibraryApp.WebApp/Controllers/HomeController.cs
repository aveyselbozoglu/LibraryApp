using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.BusinessLayer;
using LibraryApp.Entities;

namespace LibraryApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserManager um = new UserManager();
            var z = um.GetUserList();
            return View(z);
        }
    }
}