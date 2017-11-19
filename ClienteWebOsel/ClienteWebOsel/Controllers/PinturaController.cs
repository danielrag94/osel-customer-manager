using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteWebOsel.Models;
using ClienteWebOsel.ViewModels;

namespace ClienteWebOsel.Controllers
{
    public class PinturaController : Controller
    {
        // GET: Pintura
        public ActionResult Index()
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            ViewBag.listaPinturas = csp.LeerTodos();
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {            
            return View("Crear");
        }

        [HttpPost]
        public ActionResult Crear(ViewModelsPintura vmp)
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            csp.Crear(vmp.Pintura);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(string id)
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            csp.Eliminar(csp.LeerPorId(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(string id)
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            ViewModelsPintura vmp = new ViewModelsPintura();
            vmp.Pintura = csp.LeerPorId(id);
            return View("Editar", vmp);
        }

        [HttpPost]
        public ActionResult Editar(ViewModelsPintura vmp)
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            csp.Editar(vmp.Pintura);            
            return RedirectToAction("Index");
        }
    }
}