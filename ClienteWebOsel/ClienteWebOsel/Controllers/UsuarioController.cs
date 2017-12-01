using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteWebOsel.Models;
using ClienteWebOsel.ViewModels;

namespace ClienteWebOsel.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ClienteServicioUsuario csu = new ClienteServicioUsuario();
            ViewBag.listaUsuarios = csu.LeerTodos();
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View("Crear");
        }

        [HttpPost]
        public ActionResult Crear(ViewModelUsuario vmu)
        {
            ClienteServicioUsuario csu = new ClienteServicioUsuario();
            csu.Crear(vmu.Usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(string id)
        {
            ClienteServicioUsuario csu = new ClienteServicioUsuario();
            csu.Eliminar(csu.LeerPorId(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            ClienteServicioUsuario csu = new ClienteServicioUsuario();
            ViewModelUsuario vmu = new ViewModelUsuario();
            vmu.Usuario = csu.LeerPorId(id);
            return View("Editar", vmu);
        }

        [HttpPost]
        public ActionResult Editar(ViewModelUsuario vmu)
        {
            ClienteServicioUsuario csu = new ClienteServicioUsuario();
            csu.Editar(vmu.Usuario);
            return RedirectToAction("Index");
        }
    }
}