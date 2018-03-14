using MVCFileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUpload.Controllers
{
    public class JJController : Controller
    {
        CartsEntities dc = new CartsEntities();
        // GET: JJ
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            var movies = new List<object>();
            movies.Add(new { Title = "Ghostbusters", Genre = "Comedy", Year = 1984 });
            return Json(movies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult lookat()
        {
            //var aaa= dc.Accept.Select(x=>x.Id).LastOrDefault();------>不行，Run到瀏覽器時才會跟我說Error
            var aaa = dc.Accept.OrderByDescending(x => x.Id).First();
            
            //var bbb=dc.Accept.Where(x=>x.Id).LastOrDefault();
            return View(aaa);
            //return View(bbb);
        }

    }
}