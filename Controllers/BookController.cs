using Ebook_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebook_Application.Controllers
{
    public class BookController : Controller
    {
        public ActionResult ManageBook()
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {

                    return View(database.Books.ToList());
                }
            }
            return new HttpNotFoundResult();

        }

        public ActionResult AddBook(Book model)
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {
                    ModelState.Clear();
                    model.CategoryList = database.Categories.ToList();
                }
                return View(model);
            }
            return new HttpNotFoundResult();


        }
        [HttpPost]
        public ActionResult AddBookToDB()
        {
            if (User.IsInRole("Admin"))
            {
                var model = new Book();
                TryUpdateModel<Book>(model);
                if (model.UploadedImage != null)
                {
                    Random randomnumber = new Random();
                    string ImageName = model.BookCode + randomnumber.Next() + Path.GetExtension(model.UploadedImage.FileName);
                    model.UploadedImage.SaveAs(Server.MapPath("~/Content/BookImages/" + ImageName));
                    model.Image = ImageName;

                }
                using (var database = new EbookContext())
                {
                    database.Books.AddOrUpdate(model);
                    database.SaveChanges();
                    Debug.WriteLine(model.UploadedImage.FileName.ToString());
                    return View(model);
                }
            }
            return new HttpNotFoundResult();

        }



        public ActionResult EditBook(int Id)
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {
                    var book = database.Books.Where(item => item.BookId == Id).First();
                    return View(book);
                }
            }
            return new HttpNotFoundResult();

        }

        public ActionResult DeleteBook(int Id)
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {
                    var book = database.Books.Where(item => item.BookId == Id).First();
                    database.Books.Remove(book);
                    database.SaveChanges();
                    return RedirectToAction("Index","Home");

                }
            }
            return new HttpNotFoundResult();

        }

        public ActionResult UserList()
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new ApplicationDbContext())
                {
                    List<ApplicationUser> ListOfUsers = database.Users.ToList();
                    return View(ListOfUsers);
                }
            }
            return new HttpNotFoundResult();

        }
    }
}