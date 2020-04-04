using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empleados.Models.ViewModels
{
    public class SolicitudViewModel
    {
        [Required]
        [Display(Name = "id")]
        public int Id_solicitud { get; set; }
        [Required]
        [Display(Name = "Código de solicitud")]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Resumen")]
        public string Resumen { get; set; }
        [Required]
        [Display(Name = "id_em")]
        public int id_em { get; set; }
    }
}