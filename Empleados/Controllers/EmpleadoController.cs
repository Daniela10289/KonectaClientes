using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Empleados.Models;
using Empleados.Models.ViewModels;

namespace Empleados.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<ListaEmpleadoViewModel> lst;
            using (EMPLEADOSEntities db = new EMPLEADOSEntities())
            {
                lst = (from d in db.tblEmpleados
                           select new ListaEmpleadoViewModel
                           {
                               Id_empleado = d.Id_empleado,
                               FechaIngreso = d.FechaIngreso,
                               Nombre = d.Nombre,
                               Salario = d.Salario
                           }).ToList();
            }
                return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EMPLEADOSEntities db = new EMPLEADOSEntities())
                    {
                        var oTabla = new tblEmpleados();
                        oTabla.Id_empleado = model.Id_empleado;
                        oTabla.FechaIngreso = model.FechaIngreso;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Salario = model.Salario;

                        db.tblEmpleados.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Empleado/");
                }
                return View(model);

            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            EmpleadoViewModel model = new EmpleadoViewModel();
            using (EMPLEADOSEntities db = new EMPLEADOSEntities())
            {
                var oTabla = db.tblEmpleados.Find(id);
                model.Id_empleado = oTabla.Id_empleado;
                model.Nombre = oTabla.Nombre;
                model.FechaIngreso = oTabla.FechaIngreso;
                model.Salario = oTabla.Salario;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EmpleadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EMPLEADOSEntities db = new EMPLEADOSEntities())
                    {
                        var oTabla = db.tblEmpleados.Find(model.Id_empleado);
                        oTabla.Id_empleado = model.Id_empleado;
                        oTabla.FechaIngreso = model.FechaIngreso;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Salario = model.Salario;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Empleado/");
                }
                return View(model);

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (EMPLEADOSEntities db = new EMPLEADOSEntities())
            {
                var oTabla = db.tblEmpleados.Find(id);
                db.tblEmpleados.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Empleado/");
        }
    }
}