using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClienteWebOsel.Models;
using ClienteWebOsel.ViewModels;

namespace ClienteWebOsel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ClienteServicioPintura csp = new ClienteServicioPintura();
            ViewBag.listaPinturas = csp.LeerTodos();
            return View();
        }
    }
}