using News.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        MERContext dp = new MERContext();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SelectAllNews()
        {
            List<news> lst = dp.news.OrderByDescending(e => e.date).ToList();

            return View(lst);
        }
        public ActionResult Add()
        {
            List<catogery> s = dp.catogeries.ToList();
            SelectList ss = new SelectList(s, "id", "name");
            ViewData["aa"] = ss;
            ViewBag.cat = s;
            return View();
        }
        [HttpPost]
        public ActionResult Add(news news, HttpPostedFileBase httpPosted)
        {


            if (ModelState.IsValid)

            {
                if (httpPosted.FileName != "")
                {
                    httpPosted.SaveAs(Server.MapPath("~/img/") + httpPosted.FileName);
                    news.photo = httpPosted.FileName;
                }
                if (Session["id"] != null)
                {
                    news.user_id = int.Parse(Session["id"].ToString());
                }
                dp.news.Add(news);
                dp.SaveChanges();
            }
            return RedirectToAction("Add");
        }
        public ActionResult SelectByUser()
        {
            int id = int.Parse(Session["id"].ToString());
            List<news> n = dp.news.Where(e => e.user_id == id).ToList();
            return View(n);
        }
        public ActionResult SelectByCatogery(int id)
        {
            List<news> n = dp.news.Where(e => e.catogery_id == id).OrderByDescending(e => e.date).ToList();
            return View("SelectAllNews", n);
        }
        public ActionResult MoreInfo(int id)
        {
            news n = dp.news.Where(i => i.id == id).SingleOrDefault();

            return View(n);
        }

        public ActionResult Edit(int id)
        {
            news news = dp.news.Where(n => n.id == id).SingleOrDefault();
            if (news != null)
            {
                List<catogery> s = dp.catogeries.ToList();
                SelectList ss = new SelectList(s, "id", "name");
                ViewBag.cat = ss;
                return View(news);
            }
            return RedirectToAction("SelectByUser");
        }
        [HttpPost]
        public ActionResult Edit(news news, HttpPostedFileBase httpPosted)
        {
            news ne = dp.news.Where(n => n.id == news.id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                if (httpPosted != null)
                {
                    httpPosted.SaveAs(Server.MapPath("~/img/") + httpPosted.FileName);
                    ne.photo = httpPosted.FileName;
                }


                ne.title = news.title;
                ne.pref = news.pref;
                ne.desc = news.desc;
                ne.catogery_id = news.catogery_id;
                ne.date = news.date;

                dp.SaveChanges();
            }
            return RedirectToAction("SelectByUser");
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                dp.news.Remove(dp.news.Where(n => n.id == id).SingleOrDefault());
                dp.SaveChanges();
            }

            return RedirectToAction("SelectByUser");
        }
        public ActionResult allcat()
        {
            ViewBag.cat = dp.catogeries.ToList();
            return PartialView();

        }

    }
}