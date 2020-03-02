using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;

namespace LibraryApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new DatabaseContext();
            var user  = db.Users.ToList();

            return View(user);
        }
    }
}