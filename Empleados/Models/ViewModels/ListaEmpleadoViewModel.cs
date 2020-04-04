using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empleados.Models.ViewModels
{
    public class ListaEmpleadoViewModel
    {

        public int Id_empleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public int Salario { get; set; }

    }
}