using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var details = TokenHelper.GetTokenDetails();
            if (details != null && details.ContainsKey("access_token"))
            {
                ViewBag.Token = details["access_token"];
            }

            return View();
        }

       
    }
}