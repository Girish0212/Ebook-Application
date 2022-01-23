using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebook_Application.Controllers
{
    public class UploadAndDownloadController : Controller
    {
        // GET: UploadAndDownload
        public ActionResult UploadBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBook(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/App_Data/UploadedBooks"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
        [Authorize]
        public ActionResult DownloadBook(string fileName)
        {
            
            //Build the File Path.
            string path = Server.MapPath("~/App_Data/UploadedBooks/"+ fileName +".pdf");
            FileInfo file = new FileInfo(path);
            
           
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}