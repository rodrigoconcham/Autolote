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
    public class AutomovilController : Controller
    {
        private DBContext db = new DBContext();

        //
        // GET: /Automovil/

        public ActionResult Index()
        {

            return View(db.Automovils
                .Include("Modelo")
                .Include("Modelo.Marcas")
                .Include("tipos")
                .Include("AutomovilImagenes")
                .ToList());

        }

        //
        // GET: /Automovil/Details/5

        public ActionResult Details(int id = 0)
        {
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
  
            return View(automovil);
        }

        //
        // GET: /Automovil/Create

        public ActionResult Create()
        {

            var automovil = new Automovil()

            {
                FechaPublicacion = DateTime.Now

            };

            return View(automovil);

        } 

        //
        // POST: /Automovil/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automovils.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", automovil.ModeloId);
            return View(automovil);
        }

        //
        // GET: /Automovil/Edit/5

        public ActionResult Edit(int id = 0)
        {

            Automovil automovil = db.Automovils
            .Include("Modelo")
            .Include("Modelo.Marcas")
            .Include("tipos")
            .Include("AutomovilImagenes")
            .FirstOrDefault(r => r.Id == id);


            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);


         
        }

        //
        // POST: /Automovil/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", automovil.ModeloId);
            return View(automovil);
        }

        //
        // GET: /Automovil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Automovil automovil = db.Automovils.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        //
        // POST: /Automovil/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.Automovils.Find(id);
            db.Automovils.Remove(automovil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ListaTiposPorAutomovil(int id)
        {
            var tipos = db.Tipos;
            var autoMovil = db.Automovils.FirstOrDefault(r => r.Id == id);

            if (autoMovil != null)
            {
                var query = (from t in db.Tipos
                             join a in db.Automovils.Where(r => r.Id == id)
                             on t.TipoId equals a.TiposId into joined
                             from a in joined.DefaultIfEmpty()
                             select new

                             {
                                 Id = t.TipoId,
                                 Tipo = t.Descripcion,
                                 selected = a != null


                             });

                return Json(query, JsonRequestBehavior.AllowGet);

            }

            else
            {

                var query = (from t in db.Tipos

                             select new

                             {
                                 Id = t.TipoId,
                                 Tipo = t.Descripcion,
                                 selected = false



                             });



                return Json(query, JsonRequestBehavior.AllowGet);
            }




        }

    }
    
}