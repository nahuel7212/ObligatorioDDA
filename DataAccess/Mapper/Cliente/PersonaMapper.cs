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
    public class PersonaMapper
    {
        private Repositories _repositories;

        public PersonaMapper()
        {
            _repositories = new Repositories();
        }

        public Persona MapToObject(T_Persona entity)
        {
            return new Persona()
            {
                Documento = entity.Documento,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Correo = entity.Correo,
                Telefono = entity.Telefono,
                Direccion = _repositories.GetDireccionRepository().GetDireccion(entity.IDDireccion),
                TipoPrecio = _repositories.GetGrupoPrecioRepository().GetPrecio(entity.GrupoPrecio)
            };
        }

    }
}
