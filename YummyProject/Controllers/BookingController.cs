using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class BookingController : Controller
    {
       
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Bookings.Where(e => e.IsApproved == false).ToList();

            return View(values);
        }
        public ActionResult DeleteBooking(int id)
        {
            var values = context.Bookings.Find(id);
            context.Bookings.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]   
        public ActionResult DetayBooking(int id)
        {
            var values = context.Bookings.Find(id);
            return View("DetayBooking", values);    
        }
        [HttpPost]
        public ActionResult DetayBooking(Booking booking)
        {
            var values = context.Bookings.Find(booking.BookingId);
            values.IsApproved = true;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]   
        public ActionResult ApprovedBooking()
        {
            var values = context.Bookings.Where(e => e.IsApproved == true).ToList();
            return View("ApprovedBooking", values);
        }   

    }
}