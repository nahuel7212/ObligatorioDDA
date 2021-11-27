using CommonSolution.DTO.Clientes;
using DataAccess.Model;
using DataAccess.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Cliente
{
    public class EmpresaMapper
    {
        private Repositories _repositories;

        public EmpresaMapper()
        {
            _repositories = new Repositories();
        }

        public Empresa MapToObject(T_Empresa entity)
        {
            return new Empresa()
            {
                Rut = entity.Rut,
                RazonSocial = entity.RazonSocial,
                Correo = entity.Correo,
                Telefono = entity.Telefono,
                Direccion = _repositories.GetDireccionRepository().GetDireccion(entity.IDDireccion),
                TipoPrecio = _repositories.GetGrupoPrecioRepository().GetPrecio(entity.GrupoPrecio)
            };
        }
    }
}
