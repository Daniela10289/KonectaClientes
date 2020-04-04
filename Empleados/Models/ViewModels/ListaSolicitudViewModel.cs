using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empleados.Models.ViewModels
{
    public class ListaSolicitudViewModel
    {
        public int Id_solicitud { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Resumen { get; set; }
        public int Id_em { get; set; }

    }
}