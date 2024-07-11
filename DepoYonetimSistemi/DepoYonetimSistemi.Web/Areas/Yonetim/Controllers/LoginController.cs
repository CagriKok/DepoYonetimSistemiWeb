using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.EntityLayer;
using DepoYonetimSistemi.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DepoYonetimSistemi.Web.Areas.Yonetim.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(Kullanici model)
        {
            using (UnitOfWork uow = new UnitOfWork())
                if (uow.KullaniciRepository.Login(model.EPosta, model.Parola))
                {
                    var ticket = new FormsAuthenticationTicket(1,
                                                                model.EPosta,
                                                                DateTime.Now,
                                                                DateTime.Now.AddDays(1),
                                                                false,
                                                                model.EPosta);
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie cookie = new HttpCookie(".auth", encTicket);
                    Response.Cookies.Add(cookie);

                    Kullanici user = uow.KullaniciRepository.GetItemWithEPosta(model.EPosta);
                    if (user.Yetkiler == KullaniciYetkiler.User)
                        return RedirectToAction("Index", "DepoHareket");
                    else
                        return RedirectToAction("Index", "Dashboard");

                }
            ModelState.AddModelError("userinfo", "Kullanıcı adı ya da parola hatalı");
            return View();
        }


        public ActionResult LogOut()
        {
            Response.Cookies[".auth"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Login");
        }
    }
}