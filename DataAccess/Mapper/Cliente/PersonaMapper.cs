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
    public class PersonaMapper
    {
        DireccionRepository _direccionRepository = new DireccionRepository();
        GrupoPrecioRepository _grupoPrecioRepository = new GrupoPrecioRepository();

        public Persona MapToObject(T_Cliente entity)
        {
            return new Persona()
            {
                IdCliente = entity.IDCliente,
                Documento = entity.T_Persona.Documento,
                Nombre = entity.T_Persona.Nombre,
                Apellido = entity.T_Persona.Apellido,
                Correo = entity.T_Persona.Correo,
                Telefono = entity.T_Persona.Telefono,
                Direccion = _direccionRepository.GetDireccion(entity.T_Persona.IDDireccion),
                TipoPrecio = _grupoPrecioRepository.GetPrecio(entity.T_Persona.GrupoPrecio)
            };
        }
    }
}
