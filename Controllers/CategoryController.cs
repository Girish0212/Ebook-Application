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
    public class CategoryController : Controller
    {
        // GET: Category
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
                        category.UploadedCategoryImage.SaveAs(Server.MapPath("~/Content/CategoryImages/" + ImageName));
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
                    return RedirectToAction("Index","Home");

                }
            }
            return new HttpNotFoundResult();

        }
    }
}