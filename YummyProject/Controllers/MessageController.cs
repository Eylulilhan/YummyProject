using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class MessageController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.messages.Where(x => x.IsRead == false).ToList(); ;
            return View(values);
        }
        public ActionResult DeleteMessage(int id)
        {
            var values = context.messages.Find(id);
            context.messages.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DetayMessage(int id)
        {
            var values = context.messages.Find(id);
            return View("DetayMessage", values);
        }
        [HttpPost]
        public ActionResult DetayMessage(Message message)
        {
            var values = context.messages.Find(message.MessageId);
            values.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReadMessages()
        {
            var values = context.messages.Where(x => x.IsRead == true).ToList();
            return View("ReadMessages", values);

        }
    }
}