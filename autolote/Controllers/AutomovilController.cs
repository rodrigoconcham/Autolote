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

[Authorize(Roles="Admin")]
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
                FechaPublicacion =  DateTime.Now


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

            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", automovil.ModelosId);
            return View(automovil);
        }

        //
        // GET: /Automovil/Edit/5

        public ActionResult Edit(Automovil automovil)

        {
        if (ModelState.IsValid) 
        {

            var automovilOriginal = db.Automovils
            .Include("Modelo")
            .Include("Modelo.Marcas")
            .Include("tipos")
            .Include("AutomovilImagenes")
            .FirstOrDefault(r => r.Id == automovil.Id);

            var autoMovilEntry = db.Entry(automovilOriginal);
            autoMovilEntry.CurrentValues.SetValues(automovil);


            if (automovil.AutomovilImagenes !=  null && automovil.AutomovilImagenes.Any())

            {
                foreach (var imagen in automovil.AutomovilImagenes)
                {

                  if (imagen.ImagenEliminada)

                  {

                   var imagenOriginal = automovilOriginal.AutomovilImagenes.FirstOrDefault(r => r.Id == imagen.Id);
         
                   automovilOriginal.AutomovilImagenes.Remove(imagenOriginal);
                     
                  }

                  else

                  {

                      string fileName = Guid.NewGuid().ToString();


                      imagen.UrlImagenMiniatura= new  GuardarImagen().ResizeAndSave(fileName,null , Tamanos.Miniatura, false);
                      imagen.UrlImagenMediana =  new  GuardarImagen().ResizeAndSave(fileName,null, Tamanos.Miniatura, false);
                         

                      automovilOriginal.AutomovilImagenes.Add(new AutomovilImagenes()
                      {

                          UrlImagenMiniatura = imagen.UrlImagenMiniatura,
                          UrlImagenMediana  = imagen.UrlImagenMediana

                   });

                }

               }

             }
        
             db.SaveChanges();
             return RedirectToAction("Index"); 
    
           }
        
            return View(automovil);
                 
        }

        //
        // POST: /Automovil/Edit/5

        

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
                             on t.TipoId equals a.TipoId  into joined
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

        public ActionResult ListaModelosPorAutomovil(int id)
        {
            var autoMovil = db.Automovils
                .Include("Modelo")
                .Include("Modelo.Marcas")
                .FirstOrDefault(r => r.Id == id);

            if (autoMovil != null)
                
            {

                var marcaId = autoMovil.Modelo.MarcaId;

                var query = (from m in db.Modelos.Where(r => r.MarcaId == marcaId)
                             join a in db.Automovils.Where(r => r.Id == id)
                             on m.ModelosId equals a.Modelo.ModelosId into joined
                             from a in joined.DefaultIfEmpty()
                             select new

                             {
                                 Id = m.ModelosId,
                                 Modelo = m.Descripcion,
                                 selected = a != null


                             });

                return Json(query, JsonRequestBehavior.AllowGet);

            }
            
        return RedirectToAction("Index");
        
      }

        public ActionResult Detalle(int id)
        {


            var automovil = db.Automovils
           // AutoMovil automovil = db.Automovils
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


    }
    
}