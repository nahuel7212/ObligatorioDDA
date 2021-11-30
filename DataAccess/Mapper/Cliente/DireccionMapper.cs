using CommonSolution.DTO.Clientes;
using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Cliente
{
    public class DireccionMapper
    {
        private ZonaRepository _zonaRepository;

        public DireccionMapper()
        {
            this._zonaRepository = new ZonaRepository();
        }

        public Direccion MapToObject(T_Direccion entity)
        {
            return new Direccion()
            {
                IdDireccion = entity.ID,
                Nombre = entity.Nombre,
                Latitud = entity.Latitud,
                Longitud = entity.Longitud,
                Zona = this._zonaRepository.GetZonasByID(entity.IdZona)
            };
        }

        public T_Direccion MapToEntity(Direccion direccion, bool mapId = false)
        {
            T_Direccion entity = new T_Direccion()
            {
                Latitud = direccion.Latitud,
                Longitud = direccion.Longitud,
                Nombre = direccion.Nombre,
                IdZona = direccion.Zona.IdZona
            };

            if (mapId)
                entity.ID = direccion.IdDireccion;

            return entity;
        }
    }
}
