﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autolote.Models
{
    public class Modelos
    {
        [Key]
        public int ModelosId { get; set; }
         [Required(ErrorMessage = "Ingrese la descripción del modelo")]
         [Display(Name = "Modelo")] 
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }
        public Marcas Marcas { get; set; }

    }
}