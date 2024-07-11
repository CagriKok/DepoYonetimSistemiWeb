using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.EntityLayer;
using DepoYonetimSistemi.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DepoYonetimSistemi.Web.Filters
{
    public class YetkiAttribute : FilterAttribute, IAuthorizationFilter
    {
        public KullaniciYetkiler Rol { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.Cookies[".auth"] != null)
            {
                string eposta = FormsAuthentication.Decrypt(filterContext.RequestContext.HttpContext.Request.Cookies[".auth"].Value).Name;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Kullanici user = uow.KullaniciRepository.GetItemWithEPosta(eposta);
                    if (user != null)
                    {
                        user.Parola = "";
                        filterContext.HttpContext.Session["user"] = user;
                        if (user.Yetkiler == Rol || user.Yetkiler == KullaniciYetkiler.Admin)
                        {
                            return;
                        }
                    }
                }
            }
            filterContext.Result = new ViewResult()
            {
                ViewName = "YetkisizErisim"
            };
        }
    }
}