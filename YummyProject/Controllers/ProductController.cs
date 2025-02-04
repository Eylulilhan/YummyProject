using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Migrations;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProductController : Controller
    {
     
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Products.Include("Category").ToList();
            return View(values);
        }

        public ActionResult DeleteProduct(int id)
        {
           var values =context.Products.Find(id);
            context.Products.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var categoryList = context.Categories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                product.ImageUrl = "/imagess/" + imageName;
            }
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = context.Products.Find(id);
            var categoryList = context.Categories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View("UpdateProduct", product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase ImageFile)
        {
            var values = context.Products.Find(product.ProductId);
            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                product.ImageUrl = "/imagess/" + imageName;
            }
            values.ImageUrl= product.ImageUrl;
            values.ProductName = product.ProductName;
            values.Ingredients = product.Ingredients;
            values.Price = product.Price;
            values.CategoryId = product.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");   

        }   
    }
}