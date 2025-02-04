using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using System.Data.Entity;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    [Authorize] 
    public class DashboardController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            ViewBag.soupCount = context.Products.Count(x=>x.Category.CategoryName=="Çorbalar");

            ViewBag.mostExpensive = context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();

            ViewBag.avgPrice = context.Products.Average(x => x.Price);

            ViewBag.cheapestPrice = context.Products.OrderBy(x => x.Price).Select(x =>x.ProductName).FirstOrDefault();

            ViewBag.productsUnder50 = context.Products.Count(x => x.Price < 50);

            ViewBag.belowAveragePriceProducts = context.Products.Where(x => x.Price < context.Products.Average(p => p.Price))  .OrderBy(x => x.Price) .Select(x => x.ProductName).Take(3) .ToList();

            ViewBag.categoryCount = context.Categories.Count();

            ViewBag.productCount = context.Products.Count();

            ViewBag.soupCount = context.Products.Count(x => x.Category.CategoryName == "Çorbalar");

            return View();
        }
        public PartialViewResult GetProductDetails()
        {
            var products = context.Products.Include(p => p.Category).ToList();
            return PartialView(products);
        }
    }
}