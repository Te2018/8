using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Uploads"));
            var query = from f in di.EnumerateFiles()
                        select new DownloadFile
                        {
                            Filename=f.Name,
                            Filesize=f.Length,
                            UploadTime=f.CreationTime
                        };
            return View(query);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach(HttpPostedFileBase f in files)
            {
                string Filename = Path.GetFileName(f.FileName);
                string TargetFilename = Path.Combine(Server.MapPath("~/Uploads"), Filename);
                f.SaveAs(TargetFilename);
            }
            ViewBag.Message = "檔案上傳成功!";
            return RedirectToAction("Index");
        }

        public FileResult Download(string Filename)
        {
            string DownloadFilename = Path.Combine(Server.MapPath("~/Uploads"),Filename);
            return File(DownloadFilename, MediaTypeNames.Application.Octet);
        }
    }
}