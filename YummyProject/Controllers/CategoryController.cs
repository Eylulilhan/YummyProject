using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class CategoryController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            var values = context.Categories.ToList();   
            return View(values);
        }
        public ActionResult DeleteCategory(int id)
        {
           
            var isCategoryUsedInProduct = context.Products.Any(p => p.CategoryId == id);

            if (isCategoryUsedInProduct)
            {
                TempData["ErrorMessage"] = "Bu kategori bir ürüne bağlı olduğu için silinemez.";
            }
            else
            {
                var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Kategori bulunamadı.";
                }
            }

            // Index sayfasına yönlendir
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
            return RedirectToAction("Index");
        }   
    }
}