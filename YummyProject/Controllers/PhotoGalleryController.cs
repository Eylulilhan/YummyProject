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
    public class PhotoGalleryController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery photoGallery, HttpPostedFileBase ImageFile)
        {
            var values = context.Products.Find(photoGallery.PhotoGalleryId);
            if (ImageFile != null)
            {
                string imageName = Path.GetFileName(ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                ImageFile.SaveAs(imagePath);
                photoGallery.ImageUrl = "/imagess/" + imageName;
            }
            context.PhotoGalleries.Add(photoGallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   




    }
}