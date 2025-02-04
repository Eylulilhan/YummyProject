using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ContactInfoController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList(); 
            return View(values);
        }

        [HttpGet]   
        public ActionResult UpdateContact(int id)
        {
            var values = context.ContactInfos.Find(id);

            if (values == null)
            {
               
                TempData["ErrorMessage"] = "İletişim bilgisi bulunamadı.";
                return RedirectToAction("Index"); 
            }

            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                var values= context.ContactInfos.Find(contactInfo.ContactInfoId);
                if (values != null)
                {
                    values.Address = contactInfo.Address;
                    values.Email = contactInfo.Email;
                    values.PhoneNumber = contactInfo.PhoneNumber;
                    values.MapUrl = contactInfo.MapUrl;
                    values.OpenHours = contactInfo.OpenHours;

                    context.SaveChanges();
                    TempData["SuccessMessage"] = "İletişim bilgileri başarıyla güncellendi.";
                    return RedirectToAction("Index");  
                }
                else
                {
                    TempData["ErrorMessage"] = "İletişim bilgisi bulunamadı.";
                    return RedirectToAction("Index");  
                }
            }

            TempData["ErrorMessage"] = "Geçersiz giriş. Lütfen tüm alanları kontrol edin.";
            return View(contactInfo);
        }

    }
    }
