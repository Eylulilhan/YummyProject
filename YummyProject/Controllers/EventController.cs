using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class EventController : Controller
    {
       YummyContext context = new YummyContext();   
        public ActionResult Index()
        {
            var values = context.events.ToList();  
            return View(values);
        }
        public ActionResult DeleteEvent(int id)
        {
            var values = context.events.Find(id);
            context.events.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(Event model, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
               
                string imageName = Path.GetFileName(ImageFile.FileName);

                
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);

               
                if (!Directory.Exists(Server.MapPath("~/imagess/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/imagess/"));
                }

               
                ImageFile.SaveAs(imagePath);

                
                model.ImageUrl = "/imagess/" + imageName;
            }

           
            context.events.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}