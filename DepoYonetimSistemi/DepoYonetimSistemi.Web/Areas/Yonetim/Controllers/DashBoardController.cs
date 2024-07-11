using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.Web.Filters;
using DepoYonetimSistemi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoYonetimSistemi.Web.Areas.Yonetim.Controllers
{
    [Kimlik, Yetki(Rol = EntityLayer.Enums.KullaniciYetkiler.Admin)]

    public class DashBoardController : Controller
    {
        public ActionResult Index()
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                DashBoardModel model = new DashBoardModel()
                {
                    DepoAdet = uow.DepoRepository.GetCount(),
                    BugunHareketleri = uow.DepoHareketRepository.GetBugunkuHareketler(),
                    TopCikisAdet = uow.DepoHareketRepository.GetToplamCikisAdet(),
                    TopGirisAdet = uow.DepoHareketRepository.GetToplamGirisAdet(),
                };
                return View(model);
            }
        }
    }
}