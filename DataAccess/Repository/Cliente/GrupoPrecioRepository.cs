using CommonSolution.Interface.Precio;
using DataAccess.Mapper.Cliente;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Cliente
{
    public class GrupoPrecioRepository
    {
        private GrupoPrecioMapper _grupoPrecioMapper;

        public GrupoPrecioRepository()
        {
            this._grupoPrecioMapper = new GrupoPrecioMapper();
        }

        public IPrecioGeneral GetPrecio(string nombre)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._grupoPrecioMapper.MapToObject(context.T_GrupoPrecio.AsNoTracking().FirstOrDefault(f => f.Nombre == nombre));
            }
        }

    }
}
