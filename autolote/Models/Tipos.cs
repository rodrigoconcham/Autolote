using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autolote.Models
{
    public class Tipos
    {
        [Key]
        public int TipoId { get; set; }
        [Display(Name="Tipo")] 
        [Required(ErrorMessage="Ingrese la descripción")]
        public string Descripcion { get; set;}
        public string Comentario { get; set;} 
        

    }
}