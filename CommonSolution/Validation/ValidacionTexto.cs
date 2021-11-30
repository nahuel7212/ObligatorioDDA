using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonSolution.Validation
{
    public class ValidacionTexto
    {
        //Largos
        public string LargoMinimo(string texto, long valorMinimo, string textoMensaje)
        {
            if (!string.IsNullOrEmpty(texto))
                if (texto.Length < valorMinimo)
                    return textoMensaje + " debe tener mas de " + valorMinimo + " caracteres";
          
            return null;
        }
        public string LargoMaximo(string texto, long valorMaximo, string textoMensaje)
        {
            if(!string.IsNullOrEmpty(texto))
                if (texto.Length > valorMaximo)
                    return textoMensaje + " debe tener menos de " + valorMaximo + " caracteres";

            return null;
        }

        //Null o vacio
        public string NullVacio(string texto, string textoMensaje)
        {
            if (string.IsNullOrEmpty(texto))
                return "Dato " + textoMensaje +  " es requerido";

            return null;
        }

        //Correo
        public string Correo(string correo)
        { 
            string Formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (!string.IsNullOrEmpty(correo))
                if (Regex.IsMatch(correo, Formato))
                    return "Formato de correo incorrecto";

            return null;
        }
    }
}
