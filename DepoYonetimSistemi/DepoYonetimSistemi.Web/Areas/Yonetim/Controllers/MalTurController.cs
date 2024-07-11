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
    public class MalTurController : Controller
    {
        public ActionResult Index()
        {
            using (UnitOfWork uow = new UnitOfWork())
                return View(uow.MalTurRepository.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Insert(MalTur model)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.MalTurRepository.Add(model);
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
                var item = uow.MalTurRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Update(MalTur model)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.MalTurRepository.Update(model);
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
                var item = uow.MalTurRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(MalTur model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.MalTurRepository.Delete(model.Id);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}