using CommonSolution.DTO;
using CommonSolution.DTO.Camiones;
using CommonSolution.DTO.Clientes;
using CommonSolution.DTO.Envios;
using CommonSolution.DTO.Funcionarios;
using CommonSolution.DTO.Precios;
using CommonSolution.DTO.TiposPago;
using CommonSolution.ENUM;
using CommonSolution.Interface.Precio;
using CommonSolution.Interface.TipoPago;
using CommonSolution.Validation;
using DataAccess.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.LControllers
{
    public class LEnvioController
    {
        private Repositories repositories;

        public LEnvioController()
        {
            repositories = new Repositories();
        }
        
        public List<string> AgregarEnvio(EnvioDataHolder envioDT)
        {
            List<string> erroresList = ValidarDatosEnvio(envioDT);

            if (erroresList.Count == 0)
            {
                Envio envio = PasarDatosObjetoEnvio(envioDT);
                repositories.

            }

            return erroresList;
        }


        public List<string> ValidarDatosEnvio(EnvioDataHolder envioDT)
        {
            ValidacionNumero validacionNumero = new ValidacionNumero();
            ValidacionTexto validacionTexto = new ValidacionTexto();
            List<string> erroresList = new List<string>();


            #region Remitente
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.RemitenteId.ToString(), "Id remitente"));

            //Existe
            //Llamar a repo

            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.RemitenteId.ToString(), 255,"Id remitente"));
            #endregion

            #region Destinatario
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.RemitenteId.ToString(), "Destinatario"));

            //Existe
            //Llamar a repo

            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.RemitenteId.ToString(), 255, "Destinatario"));
            #endregion

            #region Descripcion contenido
            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.RemitenteId.ToString(), 255, "Descripcion contenido"));
            #endregion

            #region Peso total
            //Maximo caracteres
            erroresList.Add(validacionNumero.ValorMinimo(long.Parse(envioDT.PesoTotal.ToString()), 0, "Peso total"));
            #endregion

            #region Nombre zona
            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.NombreDireccion, 255, "Nombre direccion"));
            #endregion

            #region Funcionario responsable
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.FuncionarioResponsable, "Funcionario responsable"));

            //Existe
            //Llamar a repo
            #endregion

            #region Tipo de pago
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.TipoPago, "Tipo de pago"));
            #endregion


            //Filtro lista
            erroresList = erroresList.Where(w => !string.IsNullOrEmpty(w)).Distinct().ToList();

            return erroresList;
        }   // <----- Falta validar si existe

        public Envio PasarDatosObjetoEnvio(EnvioDataHolder envioDT)
        {
            Envio envio = new Envio();

            //Tipo pago
            if (envioDT.TipoPago == "Efectivo")
                envio.TipoPago = new Efectivo() { Nombre = "Efectivo" };
            else if(envioDT.TipoPago == "Credito")
                envio.TipoPago = new Credito() { Nombre = "Credito" }; 
            else if(envioDT.TipoPago == "Debito")
                envio.TipoPago = new Debito() { Nombre = "Debito" }; 
            else if(envioDT.TipoPago == "MercadoPago")
                envio.TipoPago = new MercadoPago() { Nombre = "MercadoPago" };

            //Numero tracking
            while (string.IsNullOrEmpty(envio.NumeroTracking))
            {
                int numeroRandom = new Random().Next(int.MaxValue);

                if (!repositories.GetEnvioRepository().ExisteNumeroTracking(numeroRandom))
                    envio.NumeroTracking = numeroRandom.ToString();
            }

            //Estado
            envio.Estado = EstadoEnvio.EnDesposito;

            //Peso total
            envio.PesoTotal = envioDT.PesoTotal;

            //Direccion
            if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
            {
                long idNuevaDireccion = CrearNuevaDireccion(envioDT);
                envio.DireccionEnvio = repositories.GetDireccionRepository().GetDireccion(idNuevaDireccion);
            }

            //Remitente y precio total
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.RemitenteId))
            {
                Persona persona = repositories.GetPersonaRepository().GetPersona(envioDT.RemitenteId);
                envio.Remitente = persona;

                envio.PrecioTotal = persona.TipoPrecio.PrecioTotal(envio.PesoTotal, 100);//<---------------------------------   Direccion hardcodeado por el momento hasta calcularlo
            }
            else if(repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.RemitenteId))
            {
                Empresa empresa = repositories.GetEmpresaRepository().GetEmpresa(envioDT.RemitenteId);
                envio.Remitente = empresa;

                envio.PrecioTotal = empresa.TipoPrecio.PrecioTotal(envio.PesoTotal, 100);//<---------------------------------   Direccion hardcodeado por el momento hasta calcularlo
            }

            //Destinatario
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.ClienteDestinatarioId))
            {
                envio.Destinatario = repositories.GetPersonaRepository().GetPersona(envioDT.ClienteDestinatarioId);
            }
            else if (repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.ClienteDestinatarioId))
            {
                envio.Destinatario = repositories.GetEmpresaRepository().GetEmpresa(envioDT.ClienteDestinatarioId);
            }

            //Fecha agregado
            envio.FechaAgregado = DateTime.Now;

            //Zona
            envio.ZonaEnvio = new Zona { IdZona = 1 }; //<---- Hardcodeado por el momento   --- buscarlo en base con envioDT.DatoZona

            //Camion
            envio.CamionEnvio = new Camion { Matricula = "A111" }; //<---------------- Hardcodeado por el momento hasta hacer parte de camiones

            //Funcionario responsable
            envio.Responsable = new Funcionario { Documento = "50534726" };


            return envio;
        }

        public long CrearNuevaDireccion(EnvioDataHolder envioDT)
        {
            Direccion nuevaDireccion = new Direccion() { Latitud = envioDT.Latitud, Longitud = envioDT.Longitud, Nombre = envioDT.NombreDireccion };
            return repositories.GetDireccionRepository().AgregarDireccionReturnId(nuevaDireccion);
        }
    }
}
