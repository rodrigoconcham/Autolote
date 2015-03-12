using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autolote.Models;

namespace autolote.Controllers
{
    public class TiposController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Tipos/

        public ActionResult Index()
        {
            return View(db.Tipos.ToList());
        }

        //
        // GET: /Tipos/Details/5

        public ActionResult Details(int id = 0)
        {
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        //
        // GET: /Tipos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tipos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipos tipos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos);
        }

        //
        // GET: /Tipos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        //
        // POST: /Tipos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tipos tipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos);
        }

        //
        // GET: /Tipos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tipos tipos = db.Tipos.Find(id);
            if (tipos == null)
            {
                return HttpNotFound();
            }
            return View(tipos);
        }

        //
        // POST: /Tipos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos tipos = db.Tipos.Find(id);
            db.Tipos.Remove(tipos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ListaTipos()
        {
            var listaTipos = db.Tipos;

            if (!listaTipos.Any())
            {
                return HttpNotFound();
            }

            return PartialView(listaTipos);
          }


    }
}