using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            ViewBag.EventCount = context.events.Count();
            ViewBag.ProductCount = context.Products.Count();
            ViewBag.ChefCount = context.chefs.Count();
            ViewBag.ServiceCount = context.Services.Count();    
            return View();
        }
        public PartialViewResult DefaultFeature()
        {
            var values = context.features.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAbout()
        {
           var values = context.Abouts.ToList();    
           return PartialView(values);
        }
        public PartialViewResult DefaultProduct()
        {
            var values = context.Categories.ToList();
            return PartialView(values); 
        }
        [HttpGet]
        public PartialViewResult DefaultBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult DefaultBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
            return PartialView();   
        }
       

        [HttpGet]
        public PartialViewResult DefaultMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult DefaultMessage(Message message)
        {
            context.messages.Add(message);
            context.SaveChanges();
            return PartialView();
        }

        public PartialViewResult DefaultContentInfo()
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }   
        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEvent()
        {
            var values = context.events.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values); 
        }
        public PartialViewResult DefaultChefs()
        {
            var values = context.chefs.Include("ChefSocials").ToList();
            return PartialView(values);
        }

    }
}