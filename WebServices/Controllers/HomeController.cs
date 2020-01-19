using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonPH()
        {
            return View();
        }
        [HttpPost]
        public ActionResult JsonPH(List<Post> d)
        {
            ViewBag.Result = d;
            return View();
        }
    }
}