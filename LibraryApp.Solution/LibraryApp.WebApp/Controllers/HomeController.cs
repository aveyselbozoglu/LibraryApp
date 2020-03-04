using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
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
            Test um = new Test();
            var z = um.GetUserList();
            return View(z);
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
    }
}