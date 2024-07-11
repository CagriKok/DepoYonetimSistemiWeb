using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.EntityLayer;
using DepoYonetimSistemi.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoYonetimSistemi.Web.Areas.Yonetim.Controllers
{
    [Kimlik,Yetki(Rol = EntityLayer.Enums.KullaniciYetkiler.Admin)]
    public class KullaniciController : Controller
    {
        public ActionResult Index()
        {
            using (UnitOfWork uow = new UnitOfWork())
                return View(uow.KullaniciRepository.GetAll());
        }

        public ActionResult Insert()
        {
            return View(new Kullanici());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Insert(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.KullaniciRepository.Add(model);
                    if (uow.SaveChanges() > 0)
                        return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Update(int id = 0)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var item = uow.KullaniciRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.KullaniciRepository.Update(model);
                    if (uow.SaveChanges() > 0)
                        return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id = 0)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var item = uow.KullaniciRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(Kullanici model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.KullaniciRepository.Delete(model.Id);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}