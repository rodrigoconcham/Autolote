using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autolote.Models;
using autolote.Helper;

namespace autolote.Controllers
{
    public class MarcasController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Marcas/

        public ActionResult Index()
        {
            return View(db.Marcas.ToList());
        }

        //
        // GET: /Marcas/Details/5

        public ActionResult Details(int id = 0)
        {
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        //
        // GET: /Marcas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Marcas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marcas marcas)
        {
            if (ModelState.IsValid)
            {
                var guardarImagen = new GuardarImagen();

                string fileName = Guid.NewGuid().ToString();

                marcas.UrlImagen = guardarImagen.ResizeAndSave(fileName, marcas.ImagenSubida.InputStream, Tamanos.Miniatura, false);
                
                
                db.Marcas.Add(marcas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marcas);
        }

        //
        // GET: /Marcas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        //
        // POST: /Marcas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcas);
        }

        //
        // GET: /Marcas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        //
        // POST: /Marcas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marcas marcas = db.Marcas.Find(id);
            db.Marcas.Remove(marcas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}