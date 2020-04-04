using Empleados.Models;
using Empleados.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empleados.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        public ActionResult Index()
        {
            List<ListaSolicitudViewModel> lst;
            using (EMPLEADOSEntities db = new EMPLEADOSEntities())
            {
                lst = (from d in db.tblSolicitudes
                       select new ListaSolicitudViewModel()
                       {
                           Id_solicitud = d.Id_solicitud,
                           Codigo = d.Codigo,
                           Descripcion = d.Descripcion,
                           Resumen = d.Resumen,
                           //Id_em = d.Id_Empleado_s
                           
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(SolicitudViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EMPLEADOSEntities db = new EMPLEADOSEntities())
                    {
                        var oTabla = new tblSolicitudes();
                        oTabla.Codigo = model.Codigo;
                        oTabla.Descripcion = model.Descripcion;
                        oTabla.Resumen = model.Resumen;
                        oTabla.Id_Empleado_s = 123;

                        db.tblSolicitudes.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Solicitud/");
                }
                return View(model);

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            SolicitudViewModel model = new SolicitudViewModel();
            using (EMPLEADOSEntities db = new EMPLEADOSEntities())
            {
                var oTabla = db.tblSolicitudes.Find(id);
                model.Id_solicitud = oTabla.Id_solicitud;
                model.Codigo = oTabla.Codigo;
                model.Descripcion = oTabla.Descripcion;
                model.Resumen = oTabla.Resumen;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(SolicitudViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EMPLEADOSEntities db = new EMPLEADOSEntities())
                    {
                        var oTabla = db.tblSolicitudes.Find(model.Id_solicitud);
                        oTabla.Id_solicitud = model.Id_solicitud;
                        oTabla.Codigo = model.Codigo;
                        oTabla.Descripcion = model.Descripcion;
                        oTabla.Resumen = model.Resumen;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Solicitud/");
                }
                return View(model);

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }

}