using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            var values = context.chefs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(Chef chef, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                chef.ImageUrl = "/imagess/" + imageName;
            }
            context.chefs.Add(chef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChef(int id)
        {
            var values = context.chefs.Find(id);
            context.chefs.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var values = context.chefs.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef, HttpPostedFileBase ImageFile)
        {
            var values = context.chefs.Find(chef.ChefId);   

            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                chef.ImageUrl = "/imagess/" + imageName;
            }

            values.Name= chef.Name;  
            values.Title = chef.Title;  
            values.Description = chef.Description;
            values.ImageUrl = chef.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");   



        }   
    }
}