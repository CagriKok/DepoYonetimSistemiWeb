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
    [Kimlik,Yetki(Rol = EntityLayer.Enums.KullaniciYetkiler.User)]
    public class DepoHareketController : Controller
    {
        public ActionResult Index(int depoId = 0)
        {
          using(UnitOfWork uow = new UnitOfWork())
            {
                List<Depo> depolar = new List<Depo>() { new Depo { Id = 0, Ad = "Hepsi" } };
                depolar.AddRange(uow.DepoRepository.GetAll());
                ViewBag.Depolar = new SelectList(depolar, "Id", "Ad", depoId);

                if (depoId == 0)
                    return View(uow.DepoHareketRepository.ToListFull());
                else
                    return View(uow.DepoHareketRepository.ToListFull(depoId));
            }
        }

        public ActionResult Insert()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ViewBag.Depolar = new SelectList(uow.DepoRepository.GetAll(), "Id", "Ad");
                ViewBag.MalTurleri = new SelectList(uow.MalTurRepository.GetAll(), "Id", "Ad");

                return View(new DepoHareket());
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Insert(DepoHareket model)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.DepoHareketRepository.Add(model);
                    if (uow.SaveChanges() > 0)
                        return RedirectToAction("Index");
                }
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                ViewBag.Depolar = new SelectList(uow.DepoRepository.GetAll(), "Id", "Ad");
                ViewBag.MalTurleri = new SelectList(uow.MalTurRepository.GetAll(), "Id", "Ad");
                return View(new DepoHareket());
            }
        }
        public ActionResult Update(int id = 0)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
               var item = uow.DepoHareketRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Depolar = new SelectList(uow.DepoRepository.GetAll(), "Id", "Ad");
                    ViewBag.MalTurleri = new SelectList(uow.MalTurRepository.GetAll(), "Id", "Ad");
                    return View(item);
                }
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Update(DepoHareket model)
        {
            if (ModelState.IsValid)
            {
                using(UnitOfWork uow = new UnitOfWork())
                {
                    uow.DepoHareketRepository.Update(model);
                    if (uow.SaveChanges() > 0)
                        return RedirectToAction("Index");
                }
            }

            using(UnitOfWork uow = new UnitOfWork())
            {
                ViewBag.Depolar = new SelectList(uow.DepoRepository.GetAll(), "Id", "Ad");
                ViewBag.MalTurleri = new SelectList(uow.MalTurRepository.GetAll(), "Id", "Ad");
                return View(model);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
               var item = uow.DepoHareketRepository.GetItemFull(id);
               if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(DepoHareket model)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                uow.DepoHareketRepository.Delete(model.Id);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}