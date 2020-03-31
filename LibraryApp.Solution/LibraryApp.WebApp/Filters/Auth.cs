using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LibraryApp.WebApp.Models;

namespace LibraryApp.WebApp.Filters
{
    public class Auth:FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User == null)
            {
                //filterContext.Result = new HttpStatusCodeResult(404,"login");
                filterContext.Result = new RedirectResult("~/Home/LoginUser");
            }
        }
    }
}