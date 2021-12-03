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
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.LControllers
{
    public class LEnvioController
    {
        //Datos ubicacion DAK
        static string latDAK = "0.2977208699081284"; //<----    Dato falsos de ubicacion de DAK
        static string lonDAK = "37.197632254726614"; //<----    Dato falsos de ubicacion de DAK

        private Repositories repositories;
        public LEnvioController()
        {
            repositories = new Repositories();
        }

        #region Agregar
        public List<string> AgregarEnvio(EnvioDataHolder envioDT)
        {
            //Simular datos que todavia no estan prontos 
            envioDT = SimularDatos(envioDT);

            List<string> erroresList = ValidarDatosEnvio(envioDT);

            if (erroresList.Count == 0)
            {
                Envio envio = PasarDatosObjetoEnvio(envioDT);
                repositories.GetEnvioRepository().AgregarEnvio(envio);
            }

            return erroresList;
        }
        public long CrearNuevaDireccion(EnvioDataHolder envioDT)
        {
            Direccion nuevaDireccion = new Direccion() { Latitud = envioDT.Latitud, Longitud = envioDT.Longitud, Nombre = envioDT.NombreDireccion};
            nuevaDireccion.Zona = repositories.GetZonaRepository().GetZonasByDato(envioDT.DatoZona);
            return repositories.GetDireccionRepository().AgregarDireccionReturnId(nuevaDireccion);
        }
        #endregion

        #region Devolucion de datos
        public double GetDatoPrecioTotal(EnvioDataHolder envioDT)
        {
            Persona remitentePersona = null;
            Empresa remitenteEmpresa = null;
            Persona destinatarioPersona = null;
            Empresa destinatarioEmpresa = null;
            double kilometros = 0;

            //Remitente
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.RemitenteId))
            {
                remitentePersona = repositories.GetPersonaRepository().GetPersona(envioDT.RemitenteId);
            }
            else if (repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.RemitenteId))
            {
                remitenteEmpresa = repositories.GetEmpresaRepository().GetEmpresa(envioDT.RemitenteId);
            }

            //Destinatario
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.ClienteDestinatarioId))
            {
                destinatarioPersona = repositories.GetPersonaRepository().GetPersona(envioDT.ClienteDestinatarioId);
            }
            else if (repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.ClienteDestinatarioId))
            {
                destinatarioEmpresa = repositories.GetEmpresaRepository().GetEmpresa(envioDT.ClienteDestinatarioId);
            }

            if (remitentePersona == null && remitenteEmpresa == null)
                return 0;

            if (destinatarioPersona == null && destinatarioEmpresa == null)
                return 0;

            //Precio total
            if (destinatarioPersona != null)
            {
                if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
                {
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, envioDT.Latitud, envioDT.Longitud);
                }
                else
                {
                    Direccion direccion = repositories.GetDireccionRepository().GetDireccion(destinatarioPersona.Direccion.IdDireccion);
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, direccion.Latitud, direccion.Longitud);
                }
                if(remitentePersona != null)
                    envioDT.PrecioTotal = remitentePersona.TipoPrecio.PrecioTotal(envioDT.PesoTotal, kilometros);
                else
                    envioDT.PrecioTotal = remitenteEmpresa.TipoPrecio.PrecioTotal(envioDT.PesoTotal, kilometros);
            }
            else
            {
                if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
                {
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, envioDT.Latitud, envioDT.Longitud);
                }
                else
                {
                    Direccion direccion = repositories.GetDireccionRepository().GetDireccion(destinatarioEmpresa.Direccion.IdDireccion);
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, direccion.Latitud, direccion.Longitud);
                }
                if (remitentePersona != null)
                    envioDT.PrecioTotal = remitentePersona.TipoPrecio.PrecioTotal(envioDT.PesoTotal, kilometros);
                else
                    envioDT.PrecioTotal = remitenteEmpresa.TipoPrecio.PrecioTotal(envioDT.PesoTotal, kilometros);
            }

            return envioDT.PrecioTotal;
        }
        #endregion

        #region Simulacion de datos (temporal)
        public EnvioDataHolder SimularDatos(EnvioDataHolder envioDT) //Eliminar luego de hacer la funcionalidad respectiva 
        {
            envioDT.FuncionarioResponsable = "50534726";

            return envioDT;
        }

        #endregion

        #region Pasaje de datos | Llamadas a funciones
        public Envio PasarDatosObjetoEnvio(EnvioDataHolder envioDT)
        {
            Envio envio = new Envio();
            Persona remitentePersona = null;
            Empresa remitenteEmpresa = null;
            Persona destinatarioPersona = null;
            Empresa destinatarioEmpresa = null;
            Direccion direccion = null;

            //Tipo pago
            GetTipoPago(envioDT, envio);

            //Numero tracking
            GetNumeroTracking(envioDT, envio);

            //Estado
            envio.Estado = EstadoEnvio.EnDesposito;

            //Fecha agregado
            envio.FechaAgregado = DateTime.Now;

            //Peso total
            envio.PesoTotal = envioDT.PesoTotal;

            //Direccion (solo asigna la direccion si es nueva, de lo contrario se asigna luego de obtener otros datos necesarios)
            GetDireccionNueva(envioDT, envio);

            //Remitente 
            GetRemitente(envioDT, envio, ref remitentePersona, ref remitenteEmpresa);

            //Destinatario
            GetDestinatario(envioDT, envio, ref destinatarioPersona, ref destinatarioEmpresa);

            //Precio total
            GetPrecioTotal(envioDT, envio, ref remitentePersona, ref remitenteEmpresa, ref destinatarioPersona, ref destinatarioEmpresa, ref direccion);

            //Direccion (solo se hace si no hay una nueva direccion)
            if (string.IsNullOrEmpty(envioDT.Latitud) && string.IsNullOrEmpty(envioDT.Longitud))
                envio.DireccionEnvio = direccion;

            //Zona
            GetZona(envioDT, envio, destinatarioPersona, destinatarioEmpresa);

            //Camion
            envio.CamionEnvio = new Camion { Matricula = "A111" }; //<---------------- Hardcodeado hasta hacer parte de camiones (para conseguir logica de distruibucion de envio por zona de camion)

            //Funcionario responsable
            envio.Responsable = this.repositories.GetFuncionarioRepository().GetFuncionario(envioDT.FuncionarioResponsable);  

            return envio;
        }
        public Envio GetTipoPago(EnvioDataHolder envioDT, Envio envio)
        {
            if (envioDT.TipoPago == "Efectivo")
                envio.TipoPago = new Efectivo() { Nombre = "Efectivo" };
            else if (envioDT.TipoPago == "Credito")
                envio.TipoPago = new Credito() { Nombre = "Credito" };
            else if (envioDT.TipoPago == "Debito")
                envio.TipoPago = new Debito() { Nombre = "Debito" };
            else if (envioDT.TipoPago == "MercadoPago")
                envio.TipoPago = new MercadoPago() { Nombre = "MercadoPago" };

            return envio;
        }
        public Envio GetNumeroTracking(EnvioDataHolder envioDT, Envio envio)
        {
            while (envio.NumeroTracking == 0)
            {
                long numeroRandom = new Random().Next(int.MaxValue);

                if (!repositories.GetEnvioRepository().ExisteNumeroTracking(numeroRandom))
                    envio.NumeroTracking = numeroRandom;
            }

            return envio;
        }
        public Envio GetDireccionNueva(EnvioDataHolder envioDT, Envio envio)
        {
            if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
            {
                long idNuevaDireccion = CrearNuevaDireccion(envioDT);
                envio.DireccionEnvio = repositories.GetDireccionRepository().GetDireccion(idNuevaDireccion);
            }

            return envio;
        }
        public Envio GetRemitente(EnvioDataHolder envioDT, Envio envio, ref Persona remitentePersona, ref Empresa remitenteEmpresa)
        {
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.RemitenteId))
            {
                remitentePersona = repositories.GetPersonaRepository().GetPersona(envioDT.RemitenteId);
                envio.Remitente = remitentePersona;
            }
            else if (repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.RemitenteId))
            {
                remitenteEmpresa = repositories.GetEmpresaRepository().GetEmpresa(envioDT.RemitenteId);
                envio.Remitente = remitenteEmpresa;
            }

            return envio;
        }
        public Envio GetDestinatario(EnvioDataHolder envioDT, Envio envio, ref Persona destinatarioPersona, ref Empresa destinatarioEmpresa)
        {
            if (repositories.GetPersonaRepository().ExistePersona(envioDT.ClienteDestinatarioId))
            {
                destinatarioPersona = repositories.GetPersonaRepository().GetPersona(envioDT.ClienteDestinatarioId);
                envio.Destinatario = destinatarioPersona;
            }
            else if (repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.ClienteDestinatarioId))
            {
                destinatarioEmpresa = repositories.GetEmpresaRepository().GetEmpresa(envioDT.ClienteDestinatarioId);
                envio.Destinatario = destinatarioEmpresa;
            }
            return envio;
        }
        public Envio GetPrecioTotal(EnvioDataHolder envioDT, Envio envio, ref Persona remitentePersona, ref Empresa remitenteEmpresa, ref Persona destinatarioPersona, ref Empresa destinatarioEmpresa, ref Direccion direccion)
        {
            double kilometros = 0;

            if (destinatarioPersona != null)
            {
                if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
                {
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, envioDT.Latitud, envioDT.Longitud);
                }
                else
                {
                    direccion = repositories.GetDireccionRepository().GetDireccion(destinatarioPersona.Direccion.IdDireccion);
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, direccion.Latitud, direccion.Longitud);
                }
                if(remitentePersona != null)
                    envio.PrecioTotal = remitentePersona.TipoPrecio.PrecioTotal(envio.PesoTotal, kilometros);
                else
                    envio.PrecioTotal = remitenteEmpresa.TipoPrecio.PrecioTotal(envio.PesoTotal, kilometros);
            }
            else
            {
                if (!string.IsNullOrEmpty(envioDT.Latitud) && !string.IsNullOrEmpty(envioDT.Longitud))
                {
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, envioDT.Latitud, envioDT.Longitud);
                }
                else
                {
                    direccion = repositories.GetDireccionRepository().GetDireccion(destinatarioEmpresa.Direccion.IdDireccion);
                    kilometros = DoubleParseDatosYLlamadaCalculo(latDAK, lonDAK, direccion.Latitud, direccion.Longitud);
                }
                if (remitentePersona != null)
                    envio.PrecioTotal = remitentePersona.TipoPrecio.PrecioTotal(envio.PesoTotal, kilometros);
                else
                    envio.PrecioTotal = remitenteEmpresa.TipoPrecio.PrecioTotal(envio.PesoTotal, kilometros);
            }
            return envio;
        }
        public Envio GetZona(EnvioDataHolder envioDT, Envio envio, Persona destinatarioPersona, Empresa destinatarioEmpresa)
        {
            if (!string.IsNullOrEmpty(envioDT.DatoZona))
                envio.ZonaEnvio = this.repositories.GetZonaRepository().GetZonasByDato(envioDT.DatoZona);
            else
                if (destinatarioPersona != null)
                envio.ZonaEnvio = destinatarioPersona.Direccion.Zona;
            else
                envio.ZonaEnvio = destinatarioEmpresa.Direccion.Zona;

            return envio;
        }
        private double DoubleParseDatosYLlamadaCalculo(string lat1, string long1, string lat2, string long2)
        {
            return CalculoDistanciaDosPutos(double.Parse(lat1, CultureInfo.InvariantCulture), double.Parse(long1, CultureInfo.InvariantCulture), double.Parse(lat2, CultureInfo.InvariantCulture), double.Parse(long2, CultureInfo.InvariantCulture));
        }
        
        #endregion

        #region Validaciones
        public List<string> ValidarDatosEnvio(EnvioDataHolder envioDT)
        {
            ValidacionNumero validacionNumero = new ValidacionNumero();
            ValidacionTexto validacionTexto = new ValidacionTexto();
            List<string> erroresList = new List<string>();

            #region Remitente
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.RemitenteId.ToString(), "Id remitente"));

            //Existe
            if (!repositories.GetPersonaRepository().ExistePersona(envioDT.RemitenteId) && !repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.RemitenteId))
                erroresList.Add("No existe un remitente con ese Documento/Rut");

            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.RemitenteId.ToString(), 255,"Id remitente"));
            #endregion

            #region Destinatario
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.RemitenteId.ToString(), "Destinatario"));

            //Existe
            if (!repositories.GetPersonaRepository().ExistePersona(envioDT.ClienteDestinatarioId) && !repositories.GetEmpresaRepository().ExisteEmpresa(envioDT.ClienteDestinatarioId))
                erroresList.Add("No existe un destinatario con ese Documento/Rut");

            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.RemitenteId.ToString(), 255, "Destinatario"));
            #endregion

            #region Descripcion contenido
            //Maximo caracteres
            erroresList.Add(validacionTexto.LargoMaximo(envioDT.DescripcionContenido, 255, "Descripcion contenido"));
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
            if (!repositories.GetFuncionarioRepository().ExisteFuncionario(envioDT.FuncionarioResponsable))
                erroresList.Add("Funcionario no encontrado");
            #endregion

            #region Tipo de pago
            //Null
            erroresList.Add(validacionTexto.NullVacio(envioDT.TipoPago, "Tipo de pago"));
            #endregion

            //Filtro lista
            erroresList = erroresList.Where(w => !string.IsNullOrEmpty(w)).Distinct().ToList();

            return erroresList;
        }

        #endregion

        #region Calculos
        private double CalculoDistanciaDosPutos(double lat1, double lon1, double lat2, double lon2)
        {
            // Dato utilizado para probar que funcione bien el calculo. Si se hace el calculo con estos datos debe dar un total de 136.4 / 136.5
            // Pagina utilizada para ferificar el calculo: https://www.calculator.net/distance-calculator.html?type=3&la1=0.2977208699081284&lo1=37.197632254726614&la2=-0.724906654398569&lo2=39.014854431152344&ctype=dec&lad1=38&lam1=53&las1=51.36&lau1=n&lod1=77&lom1=2&los1=11.76&lou1=w&lad2=39&lam2=56&las2=58.56&lau2=n&lod2=75&lom2=9&los2=1.08&lou2=w&x=89&y=14#latlog
            /*
            lat1 = -1.1184744889292195;
            lon1 = 37.85270690917969;
            lat2 = -0.724906654398569;
            lon2 = 39.014854431152344;
            */

            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double rlon1 = Math.PI * lon1 / 180;
            double rlon2 = Math.PI * lon2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta); ;
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return dist;
        }

        #endregion

    }
}
