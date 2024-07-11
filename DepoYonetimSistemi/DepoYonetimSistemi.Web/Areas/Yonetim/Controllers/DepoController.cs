using DepoYonetimSistemi.DataAccessLayer;
using DepoYonetimSistemi.EntityLayer;
using DepoYonetimSistemi.EntityLayer.Enums;
using DepoYonetimSistemi.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoYonetimSistemi.Web.Areas.Yonetim.Controllers
{
    [Kimlik,Yetki(Rol = KullaniciYetkiler.Admin)]
    public class DepoController : Controller
    {
        public ActionResult Index()
        {
            using (UnitOfWork uow = new UnitOfWork())
                return View(uow.DepoRepository.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Insert(Depo model)
        {
            if (ModelState.IsValid)
            {
                using(UnitOfWork uow = new UnitOfWork())
                {
                    uow.DepoRepository.Add(model);
                    if (uow.SaveChanges() > 0) //Etkilenen Satır Sayısı 0 dan büyükse 
                        return RedirectToAction("Index");
                }
            }
            return View(model);

        }

        public ActionResult Update(int id = 0)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
              var item = uow.DepoRepository.GetItem(id);
                if (item == null)
                    return RedirectToAction("Index");
                else
                    return View(item);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Update(Depo model)
        {
            if (ModelState.IsValid)
            {
                using(UnitOfWork uow = new UnitOfWork())
                {
                    uow.DepoRepository.Update(model);
                    if (uow.SaveChanges() > 0)
                        return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id = 0)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
               var item = uow.DepoRepository.GetItem(id);
               if(item == null)
                    return RedirectToAction("Index");
               else
                    return View(item);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(Depo model)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
              uow.DepoRepository.Delete(model.Id);
              uow.SaveChanges();
              return RedirectToAction("Index");
            }
        }
    }
}