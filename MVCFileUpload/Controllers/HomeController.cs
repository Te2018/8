using MVCFileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OKK()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult OKK(string aaa)
        {
            CartsEntities dc = new CartsEntities();

            Accept c = new Accept();

            c.acceptAstring = aaa + "OKK";

            dc.Accept.Add(c);

            //var bbb = dc.Accept.Find(Id)

            //Data.ig_id = dc.InfoGroupp.Where(x => x.ig_name == VGroup).Select(x => x.ig_id).FirstOrDefault();
            //dc.Accept.Find(IDependencyReso
            //)//

            dc.SaveChanges();


            var b = aaa;
            ViewBag.bb = b;
            return RedirectToAction("OKK");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}