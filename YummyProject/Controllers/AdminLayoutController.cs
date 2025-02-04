using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        YummyContext context = new YummyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Navbar()
        {
            var currentUser = Session["currentUser"]?.ToString();

            if (currentUser != null)
            {
                var admin = context.Admins.FirstOrDefault(x => x.UserName == currentUser);
                if (admin != null)
                {
                    ViewBag.NameSurname = admin.NameSurname;
                }
            }
            return PartialView();
        }


    }
}