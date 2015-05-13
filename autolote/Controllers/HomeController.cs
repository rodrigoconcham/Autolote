using autolote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autolote.Controllers
{
    public class HomeController : Controller
    {

        private DBContext db = new DBContext();

        public ActionResult Administracion()
        {
            return View();
        }

        
        
        
        
        
        public ActionResult Index()
        {

            ViewBag.Mensaje = "Ultimos 10 automoviles";


            var automovilImagenes = (from a in db.Automovils
               .Include("Modelo")
               .Include("Modelo.Marcas")
               .Include("Tipo")
              .Include("AutomovilImagenes")
                                     where a.AutomovilImagenes.Any()
                                    orderby a.FechaPublicacion descending
                                    select a).Take(10);

            return View(automovilImagenes);

      
          
        }





        [HttpPost]
        public ActionResult Index(int TiposId=0, int MarcasId =0, int ModelosId=0, int AnioInicio =0, int AnioFin=0)
        {

            ViewBag.Mensaje = "Resultado de busqueda";

            var autMoviles = db.Automovils
            .Include("Modelo")
            .Include("Modelo.Marcas")
            .Include("Tipo")
            .Include("AutomovilImagenes").AsQueryable();

            if (TiposId !=0)
            {
                autMoviles = autMoviles.Where(r => r.TipoId == TiposId);
             }
          
            if (MarcasId !=0)
            {
                autMoviles = autMoviles.Where(r => r.Modelo.ModelosId == MarcasId);
             }

            if (ModelosId !=0)
            {
               autMoviles = autMoviles.Where(r => r.ModelosId == ModelosId); 
            }

            autMoviles = autMoviles.Where(r => r.Anio >= AnioInicio && r.Anio <= AnioFin);

            return View(autMoviles);

        }





        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Inicio()
        {
            ViewBag.Message = "Pagina de inicio";
            return View();     
      
        }





        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
