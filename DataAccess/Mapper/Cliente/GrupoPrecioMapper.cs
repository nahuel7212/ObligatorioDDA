using CommonSolution.DTO.Precios;
using CommonSolution.Interface.Precio;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Cliente
{
    public class GrupoPrecioMapper
    {
        public IPrecioGeneral MapToObject(T_GrupoPrecio entity)
        {
            if (entity.Nombre == "PrecioFijo")
            {
                return new PrecioFijo()
                {
                    Nombre = entity.Nombre,
                    ValorPrestablecido = entity.ValorPrestablecio
                };
            }
            else if (entity.Nombre == "PrecioPorPeso")
            {
                return new PrecioPorPeso()
                {
                    Nombre = entity.Nombre,
                    ValorPrestablecido = entity.ValorPrestablecio
                };
            }
            else if (entity.Nombre == "PrecioPorKGDistancia")
            {
                return new PrecioPorKGDistancia()
                {
                    Nombre = entity.Nombre,
                    ValorPrestablecido = entity.ValorPrestablecio
                };
            }

            return null;
        }
    }
}
