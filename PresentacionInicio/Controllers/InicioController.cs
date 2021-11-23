using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionInicio.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Envios()
        {
            return Redirect("https://localhost:44361/");
        }

    }
}
