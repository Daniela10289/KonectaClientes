using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empleados.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        [Required]
        [Display(Name = "Identificación")]
        public int Id_empleado { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true )]
        public DateTime FechaIngreso { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Salario")]
        public int Salario { get; set; }

    }
}