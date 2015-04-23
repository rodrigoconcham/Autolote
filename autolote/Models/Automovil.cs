using autolote.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autolote.Controllers
{
    public class Automovil
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ModeloId { get; set; }
        public Modelos Modelo { get; set; }
        [Required]
        public int TiposId { get; set; }
        public Tipos tipos { get; set; }
        [Display(Name ="Tiene AC")]
        public bool TieneAireAcondicionado { get; set; }
        public string Comentarios { get; set; }
        [Display(Name = "Año")]
        public int Anio { get; set; }
        public string Color { get; set; }
        [Display(Name = "Fecha Publicacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
  
         public DateTime FechaPublicacion { get; set; }
        public string Email { get; set; }

        public List<AutomovilImagenes> AutomovilImagenes { get; set; }
    }
}