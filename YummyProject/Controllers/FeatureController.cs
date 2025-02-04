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
    [Authorize]
    public class FeatureController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.features.ToList();
            return View(values);
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = context.features.Find(id);
            context.features.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Feature feature, HttpPostedFileBase VideoFile, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (VideoFile != null)
                {
                    string videoName = Path.GetFileName(VideoFile.FileName);
                    string videoPath = Path.Combine(Server.MapPath("~/videos/"), videoName);
                    VideoFile.SaveAs(videoPath);
                    feature.VideoUrl = "/videos/" + videoName;
                }
                if (ImageFile != null)
                {
                    string imageName = Path.GetFileName(ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                    ImageFile.SaveAs(imagePath);
                    feature.ImageUrl = "/imagess/" + imageName;
                }
                context.features.Add(feature);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            context.features.Add(feature);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = context.features.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature feature, HttpPostedFileBase VideoFile, HttpPostedFileBase ImageFile)
        {
            var value = context.features.Find(feature.FeatureId);  

            if (ModelState.IsValid)
            {
                if (VideoFile != null)
                {
                    string videoName = Path.GetFileName(VideoFile.FileName);
                    string videoPath = Path.Combine(Server.MapPath("~/videos/"), videoName);
                    VideoFile.SaveAs(videoPath);
                    feature.VideoUrl = "/videos/" + videoName;
                }
                if (ImageFile != null)
                {
                    string imageName = Path.GetFileName(ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/imagess/"), imageName);
                    ImageFile.SaveAs(imagePath);
                    feature.ImageUrl = "/imagess/" + imageName;
                }
                value.Title = feature.Title;
                value.Description = feature.Description;
                value.ImageUrl = feature.ImageUrl;
                value.VideoUrl = feature.VideoUrl;  
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            value.Title = feature.Title;
            value.Description = feature.Description;
            value.ImageUrl = feature.ImageUrl;
            value.VideoUrl = feature.VideoUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}