using BussinesLogic.LControllers;
using CommonSolution.DTO.Camiones;
using CommonSolution.DTO.Clientes;
using CommonSolution.DTO.Envios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionMVC.Controllers
{
    public class EnvioController : Controller
    {
        public ActionResult AgregarEnvio()
        {
            return View();
        }

        public ActionResult AgregarNuevoEnvio(EnvioDataHolder envioDT)
        {
            LEnvioController envioController = new LEnvioController();
            List<string> erroresList = envioController.AgregarEnvio(envioDT);

            if (erroresList.Count != 0)
            {
                foreach (string error in erroresList)
                {
                    ModelState.AddModelError("ErrorGeneral", error);
                }
            }
            else
            { 
                ModelState.Clear();
                ModelState.AddModelError("SuccessGeneral", "Envio registrado");
            }

            return View("AgregarEnvio");
        }
        public JsonResult GetPrecioTotal(EnvioDataHolder envioDT)
        {
            LEnvioController envioController = new LEnvioController();
            double precioTotal =  envioController.GetDatoPrecioTotal(envioDT);

            return Json(precioTotal, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult CargarMapaZona()
        {
            LZonaController zonaLController = new LZonaController();
            List<PuntosZona> puntosList = zonaLController.GetPuntosZona();

            return Json(puntosList, JsonRequestBehavior.AllowGet);
        }
    }
}
