using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace autolote.Models
{
    public class Marcas
    {
        
        [Key]
        public int MarcaId { get; set; }
         [Required(ErrorMessage = "Ingrese la descripción de la marca")]
         [Display(Name = "Marca")] 
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public  virtual ICollection<Modelos> ListaModelos { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper ImagenSubida { get; set; }




    }
}