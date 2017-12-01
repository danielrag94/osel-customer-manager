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
        public ActionResult Crear(ViewModelsPintura vmp, string color)
        {
            string nuevocolor = color.Substring(1, 6);
            int intAgain = int.Parse(nuevocolor, System.Globalization.NumberStyles.HexNumber);
            ClienteServicioPintura csp = new ClienteServicioPintura();
            vmp.Pintura.Color = intAgain.ToString();
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
            string color = vmp.Pintura.Color.ToString();            
            int numero = int.Parse(color);            

            if (numero != null)
            {
                color = "#" + numero.ToString("X");
            }
            else
            {
                color = "";
            }
            ViewBag.color = color;
            return View("Editar", vmp);
        }

        [HttpPost]
        public ActionResult Editar(ViewModelsPintura vmp, string color)
        {            
            string nuevocolor = color.Substring(1, 6);
            int intAgain = int.Parse(nuevocolor, System.Globalization.NumberStyles.HexNumber);
            vmp.Pintura.Color = intAgain.ToString();
            ClienteServicioPintura csp = new ClienteServicioPintura();
            csp.Editar(vmp.Pintura);            
            return RedirectToAction("Index");
        }
    }
}