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
    public class AboutController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);


        }
        [HttpPost]
        public ActionResult Edit(About model, HttpPostedFileBase ImageFile, HttpPostedFileBase VideoUrl, HttpPostedFileBase ImageUrl2)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var imagePath = Path.Combine(Server.MapPath("~/Imagess"), fileName);
                ImageFile.SaveAs(imagePath);
                model.ImageUrl = "/Imagess/" + fileName;
            }

            if (VideoUrl != null && VideoUrl.ContentLength > 0)
            {
                var fileName = Path.GetFileName(VideoUrl.FileName);
                var videoPath = Path.Combine(Server.MapPath("~/Videos"), fileName);
                VideoUrl.SaveAs(videoPath);
                model.VideoUrl = "/Videos/" + fileName;
            }

            if (ImageUrl2 != null && ImageUrl2.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ImageUrl2.FileName);
                var imagePath2 = Path.Combine(Server.MapPath("~/Imagess"), fileName);
                ImageUrl2.SaveAs(imagePath2);
                model.ImageUrl2 = "/Imagess/" + fileName;
            }

            var aboutInDb = context.Abouts.SingleOrDefault(a => a.AboutId == model.AboutId);
            if (aboutInDb == null)
            {
                return HttpNotFound();
            }

            aboutInDb.Item1 = model.Item1;
            aboutInDb.Item2 = model.Item2;
            aboutInDb.Item3 = model.Item3;
            aboutInDb.PhoneNumber = model.PhoneNumber;

            if (!string.IsNullOrEmpty(model.ImageUrl))
                aboutInDb.ImageUrl = model.ImageUrl;

            if (!string.IsNullOrEmpty(model.VideoUrl))
                aboutInDb.VideoUrl = model.VideoUrl;

            if (!string.IsNullOrEmpty(model.ImageUrl2))
                aboutInDb.ImageUrl2 = model.ImageUrl2;

            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}