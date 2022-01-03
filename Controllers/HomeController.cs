using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using Ebook_Application.Models;

namespace Ebook_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            using (var database = new EbookContext())
            {
                
                return View(database.Books.ToList());

            }
        }
        public ActionResult About()
        {
            using (var database = new EbookContext())
            {

                return View(database.Books.ToList());
            }
        }

        public ActionResult Genre()
        {
            using (var database = new EbookContext())
            {

                return View(database.Categories.ToList());
            }
        }
    }
}