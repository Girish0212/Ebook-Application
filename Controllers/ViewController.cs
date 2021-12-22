using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebook_Application.Models;



namespace Ebook_Application.Controllers
{
    public class ViewController : Controller
    {
        [HttpPost]
        public ActionResult Search(string search)
        {

            using (var database = new EbookContext())
            {
                List<Book> books = database.Books.Where(x => x.BookName.Contains(search)).ToList();
                ViewBag.Search = search;
                return View(books);
            }
        }

        public ActionResult BookView(Book book)
        {
            return View(book);
        }
    }
}