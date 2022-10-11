using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Controllers
{
    public class CatogeryController : Controller
    {
        MERContext NewsDctx = new MERContext();
        // GET: Catogery
        public ActionResult Index()
        {
           List<catogery> c = NewsDctx.catogeries.ToList();

            return View();
        }
    }
}