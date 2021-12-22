using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebook_Application.Models;

namespace Ebook_Application.Controllers
{
    public class CartController : Controller
    {
        private List<CartModel> ListOfCartItems;
        Carts carts = new Carts();

        //public CartController()
        //{
        //    ListOfCartItems = new List<CartModel>();

        //}
        //public ActionResult AddToCart(Book Book)
        //{
        //    var model = new CartList();
        //    model.BookId = Book.BookId;
        //    model.UserEmail = User.Identity.Name;
        //    TryUpdateModel<CartList>(model);
        //    using (var database = new EbookContext())
        //    {
        //        database.Cart.AddOrUpdate(model);
        //        database.SaveChanges();
        //        return RedirectToAction("Index","Home");
        //    }
        //}
        //public ActionResult Cart()
        //{
        //    using (var database = new EbookContext())
        //    {

        //        return View(database.Cart.ToList());
        //    }
        //}

        //public ActionResult Cart(Book book)
        //{

        //    book.BookId ,User.Identity.Name
        //    return RedirectToAction("AddtoCart", book);
        //}
        //foreach(var data cartList){
        //    var data.cartBooks = 
        //    }
        public ActionResult AddToCart(string BookName, string BookPrice, string BookId, string Image, string CategoryName)
        {
            if (carts.CartModels == null)
            {
                carts.CartModels = new List<CartModel>();
            }
            CartModel cart = new CartModel();
            cart.BookName = BookName;
            cart.BookPrice = Convert.ToDouble(BookPrice);
            cart.BookId = Convert.ToInt32(BookId);
            cart.Image = Image;


            if (BookName != null)
            {
                carts.CartModels.Add(new CartModel() { BookName = BookName, BookPrice = Convert.ToDouble(BookPrice), BookId = Convert.ToInt32(BookId), Image = Image, CategoryName = CategoryName });
            }
            return View(carts);
        }
        //public ActionResult CartItem(Book book) { 

        //    //List<Book> ListOfBooks = new List<Book>();
        //    ListOfCartItems.Add(book);
        //    //return View(ListOfBooks);
        //}

        //public JsonResult Cart(string ItemId)
        //{
        //    return Json(data: "", JsonRequestBehavior.AllowGet);
        //}
        //EbookContext ctx = new EbookContext();
        //public ActionResult AddToCart(string BoookId)
        //{
        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        var product = ctx.Books.Find(BoookId);
        //        cart.Add(new Item()
        //        {
        //            Book = product,
        //        });
        //        Session["cart"] = cart;
        //    }
        //    else
        //    {
        //        List<Item> cart = (List<Item>)Session["cart"];
        //        var product = ctx.Books.Find(BoookId);
        //        cart.Add(new Item()
        //        {
        //            Book = product,

        //        });
        //        Session["cart"] = cart;
        //    }
        //    return View(Session["cart"]);
        //}


    }
}