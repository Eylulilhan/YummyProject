using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefSocialController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            var values = context.ChefSocials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddChefSocial()
        {
            var Cheflist = context.chefs.ToList();
            List<SelectListItem> chef  = (from x in Cheflist
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.ChefId.ToString()
                                               }).ToList();
            ViewBag.Chef = chef;
            return View();
        }
        [HttpPost]
        public ActionResult AddChefSocial(ChefSocial chefSocial)
        {
            context.ChefSocials.Add(chefSocial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DeleteChefSocial(int id)
        {
           
            var chefSocial = context.ChefSocials.FirstOrDefault(x => x.ChefSocialId == id);

            if (chefSocial != null)
            {
                
                bool isLinkedToOtherChef = context.chefs.Any(c => c.ChefId == chefSocial.ChefId);

                if (isLinkedToOtherChef)
                {
                    TempData["ErrorMessage"] = "Bu sosyal medya hesabı başka bir işlemle bağlantılı olduğu için silinemez.";
                }
                else
                {
                    
                    context.ChefSocials.Remove(chefSocial);
                    context.SaveChanges();
                    TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla silindi.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Sosyal medya hesabı bulunamadı.";
            }

            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateChefSocial(int id)
        {
            
            var chefSocial = context.ChefSocials.FirstOrDefault(x => x.ChefSocialId == id);

          
            if (chefSocial == null)
            {
                TempData["ErrorMessage"] = "Sosyal medya hesabı bulunamadı.";
                return RedirectToAction("Index");
            }

            
            return View(chefSocial);
        }

        [HttpPost]
        public ActionResult UpdateChefSocial(ChefSocial chefSocial)
        {
           
            var existingChefSocial = context.ChefSocials.FirstOrDefault(x => x.ChefSocialId == chefSocial.ChefSocialId);

           
            if (existingChefSocial == null)
            {
                TempData["ErrorMessage"] = "Sosyal medya hesabı bulunamadı.";
                return RedirectToAction("Index");
            }

           
            existingChefSocial.Url = chefSocial.Url;
            existingChefSocial.SocialMediaName = chefSocial.SocialMediaName;
            existingChefSocial.Icon = chefSocial.Icon;
            existingChefSocial.ChefId = chefSocial.ChefId;

         
            context.SaveChanges();

         
            TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla güncellendi.";

            return RedirectToAction("Index");
        }


    }

}
