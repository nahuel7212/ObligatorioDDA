using CommonSolution.DTO.Camiones;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ZonaMapper
    {
        public Zona MapToObject(T_Zona entity)
        {
            return new Zona()
            {
                IdZona = entity.ID,
                Nombre = entity.Nombre,
            };
        }

        public List<Zona> MapToObject(List<T_Zona> entities)
        {
            List<Zona> entitiesList = new List<Zona>();
            foreach (var item in entities)
            {
                entitiesList.Add(MapToObject(item));
            }
            return entitiesList;
        }

        public PuntosZona MapToObjectPuntos(T_Puntos_Zona entity)
        {
            return new PuntosZona()
            {
                NumeroZona = entity.NumeroZona,
                Latitud = entity.Latitud,
                Longitud = entity.Longitud
            };
        }

        public List<PuntosZona> MapToObjectPuntos(List<T_Puntos_Zona> entities)
        {
            List<PuntosZona> entitiesList = new List<PuntosZona>();
            foreach (var item in entities)
            {
                entitiesList.Add(MapToObjectPuntos(item));
            }
            return entitiesList;
        }
    }
}
