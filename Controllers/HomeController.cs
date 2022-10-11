using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        MERContext NewsDctx = new MERContext();
        
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Cookies["NewsUser"] != null)
            {
                Session["id"] = Request.Cookies["NewsUser"].Values["id"];
                return RedirectToAction("Add", "News", new { id = Session["id"].ToString() });
            }
            return RedirectToAction("SelectAllNews","News");
        }
    }
}