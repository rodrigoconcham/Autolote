using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace autolote.Models
{
     public class AutomovilImagenes
    {

        [Key]
        public int Id { get; set; }
        public int AutomovilId { get; set; }
        public Automovil Automovil { get; set; }
        public string UrlImagenMiniatura { get; set; }
        public string UrlImagenMediana { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper ImagenSubida { get; set; }
        [NotMapped]
        public bool ImagenEliminada { get; set; }
        

    }
}
