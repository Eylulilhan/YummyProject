﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    [AllowAnonymous]    
    public class UILayoutController : Controller
    {
        YummyContext db = new YummyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.SocialMedias.ToList();  
            return PartialView(values);   
        }
    }
}