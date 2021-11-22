using CommonSolution.DTO.Clientes;
using CommonSolution.DTO.Envios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvioController : ControllerBase
    {
        [HttpGet("GetListadoEnvios")]
        public List<Object> GetListadoEnvios()
        {
            List<Object> objList = new List<object>();

            Object obj = new 
            {
                Id = 2,
                FechaAgregado = DateTime.Now
            };


            objList.Add(obj);

            return objList;
        }

        [HttpPost("PostNuevoEnvio")]
        public string Post(object data)
        {
            //Paso JSON a DataHolder
            EnvioDataHolder envioDH = JsonConvert.DeserializeObject<EnvioDataHolder>(data.ToString());


            //LLamar a clase de logica pasandole el DH y se encarga de validar y crear envio


            //Cerrar modal segun lo que se devuelva
            return "SuccessTT";
        }
    }
}
