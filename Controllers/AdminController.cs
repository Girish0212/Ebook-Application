using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebook_Application.Models;

namespace Ebook_Application.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Manage()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }return new HttpNotFoundResult();
        }

        public ActionResult ManageCategory()
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {

                    return View(database.Categories.ToList());
                }
            }
            return new HttpNotFoundResult();
           
        }

        public ActionResult AddCategory()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return new HttpNotFoundResult();
        }

        public ActionResult AddCategoryToDB(Category category)
        {
            if (User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    if (category.UploadedCategoryImage != null)
                    {
                    Random randomnumber = new Random();
                    string ImageName = category.CategoryCode + randomnumber.Next() + Path.GetExtension(category.UploadedCategoryImage.FileName);
                    category.UploadedCategoryImage.SaveAs(Server.MapPath("~/CategoryImages/" + ImageName));
                    category.CategoryImage = ImageName;
                    }
               
                    using (var database = new EbookContext())
                    {
                        database.Categories.AddOrUpdate(category);
                        database.SaveChanges();
                        Debug.WriteLine(category.UploadedCategoryImage.FileName.ToString());
                        return View(category);
                    }
                }
                else
                {
                    return View("AddCategory", category);
                }
            }
            return new HttpNotFoundResult();
            

        }

        public ActionResult EditCategory(int Id)
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {
                    var category = database.Categories.Where(item => item.CategoryId == Id).First();
                    return View(category);
                }
            }
            return new HttpNotFoundResult();
            


        }
        public ActionResult DeleteCategory(int Id)
        {
            if (User.IsInRole("Admin"))
            {
                using (var database = new EbookContext())
                {
                    var category = database.Categories.Where(item => item.CategoryId == Id).First();
                    database.Categories.Remove(category);
                    database.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            return new HttpNotFoundResult();
           
        }

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
                    model.UploadedImage.SaveAs(Server.MapPath("~/BookImages/" + ImageName));
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
                    return RedirectToAction("Index");

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