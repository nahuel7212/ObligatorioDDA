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

        public ActionResult AgregarNuevoEnvio(EnvioDataHolder dto)
        {
            //LEnvioController envioController = new LEnvioController();
            //List<string> erroresList = envioController.AgregarEnvio(dto);

            /*
            if (erroresList.Count != 0)
            {
                foreach (string error in erroresList)
                {
                    ModelState.AddModelError("ErrorGeneral", error);
                }
            }
            else
            */
            EnvioDataHolder x = dto;

            ModelState.Clear();
            ModelState.AddModelError("SuccessGeneral", "Envio registrado");

            return View("AgregarEnvio");
        }

    }
}
