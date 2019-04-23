using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GithubUserDetails.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try {
        //        return RedirectToAction ("Index");
        //    } catch {
        //        return View ();
        //    }
        //}
    }
}