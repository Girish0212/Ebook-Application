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

        public ActionResult CategoryBook(string CategoryName)
        {
            using (var database = new EbookContext())
            {
                List<Book> books = database.Books.Where(x => x.CategoryName.Contains(CategoryName)).ToList();
                ViewBag.Search = CategoryName;
                return View(books);
            }
           
        }
        [Authorize]
        public ActionResult Favourite()
        {
            using (var database = new EbookContext())
            {
               var lists = database.WishLists.ToList().FindAll(item => item.UserEmail == User.Identity.Name);
                var favbooks = new List<Book>();
                foreach(var faVbook in lists)
                {
                    var book = database.Books.ToList().Find(item => item.BookName == faVbook.BookName);
                    favbooks.Add(book);

                }
                return View(favbooks);
            }
           
        }
        //        //public ActionResult AddFavourite()
        //        //{
        //        //    return View();
        //        //}

        public ActionResult AddFavourite(string BookName)
        {
            try
            {
                //Default message to user
                TempData["message"] = "This Book is already on your wishlist!";

                using (var database = new EbookContext())
                {
                    //Check if game is already in user's wishlist
                    IQueryable<WishList> wishList = database.WishLists.Where(w => w.UserEmail == User.Identity.Name && w.BookName == BookName);
                    if (wishList.Count() == 0)
                    {
                        //Add new wishlist item if user does not have one for this game
                        TempData["message"] = "Book was added to your wishlist!";
                        WishList newWishList = new WishList();
                        newWishList.BookName = BookName;
                        newWishList.UserEmail = User.Identity.Name;


                        database.WishLists.Add(newWishList);
                        database.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                TempData["message"] = "Could not add to wish list: " + e.Message;
            }

            return RedirectToAction("Favourite", "View");
        }


        public ActionResult Remove(string bookname)
        {
           
                using (var database = new EbookContext())
                {
                    var remove = database.WishLists.Where(item => item.BookName == bookname).First();
          
                database.WishLists.Remove(remove);
                database.SaveChanges();
                return RedirectToAction("Favourite", "View");

                }
           

        }
    }
}