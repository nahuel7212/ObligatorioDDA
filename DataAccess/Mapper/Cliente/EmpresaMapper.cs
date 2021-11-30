using CommonSolution.DTO.Clientes;
using DataAccess.Model;
using DataAccess.Persistance;
using DataAccess.Repository.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Cliente
{
    public class EmpresaMapper
    {
        DireccionRepository _direccionRepository = new DireccionRepository();
        readonly GrupoPrecioRepository _grupoPrecioRepository = new GrupoPrecioRepository();

        public Empresa MapToObject(T_Cliente entity)
        {
            return new Empresa()
            {
                IdCliente = entity.IDCliente,
                Rut = entity.T_Empresa.Rut,
                RazonSocial = entity.T_Empresa.RazonSocial,
                Correo = entity.T_Empresa.Correo,
                Telefono = entity.T_Empresa.Telefono,
                Direccion = _direccionRepository.GetDireccion(entity.T_Empresa.IDDireccion),
                TipoPrecio = _grupoPrecioRepository.GetPrecio(entity.T_Empresa.GrupoPrecio)
            };
        }
    }
}
