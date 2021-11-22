using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.Validation
{
    public class ValidacionNumero
    {
        //Cantidades
        public string ValorMinimo(long valor, long valorMinimo, string textoMensaje)
        {
            if (valor < valorMinimo)
                return "Valor de " + textoMensaje + " no debe ser mayor que " + valorMinimo;

            return null;
        }
        public string ValorMaximo(long valor, long valorMaximo, string textoMensaje)
        {
            if (valor > valorMaximo)
                return "Valor de " + textoMensaje + " no debe ser menor que " + valorMaximo;

            return null;
        }
        public string ValorPositivo(long valor, string textoMensaje = "")
        {
            if (valor < 0)
                return "Valor de " + textoMensaje + " debe ser un valor positivo";

            return null;
        }
        
        //Otro
        public string NoNumeroEspecifico(long valor, long numeroEspecifico, string textoMensaje)
        {
            if (valor == numeroEspecifico)
                return "Valor de " + textoMensaje + " no puede ser " + numeroEspecifico;

            return null;
        }

        //AGREGAR UN TRY PARSE OUT
    }
}
