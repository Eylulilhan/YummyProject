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
    public class TestimonialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList(); 
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial,HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                testimonial.ImageUrl = "/imagess/" + imageName;
            }   
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   


    }
}