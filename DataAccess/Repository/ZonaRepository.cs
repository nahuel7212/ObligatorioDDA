using CommonSolution.DTO.Camiones;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ZonaRepository
    {
        private ZonaMapper _zonaMapper;

        public ZonaRepository() 
        {
            this._zonaMapper = new ZonaMapper();
        }


        public Zona GetZonasByID(long idZona)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._zonaMapper.MapToObject(context.T_Zona.AsNoTracking().FirstOrDefault(f => f.ID == idZona));
            }
        }
        public Zona GetZonasByDato(string DatoZona)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                long numeroZona = context.T_Puntos_Zona.AsNoTracking().FirstOrDefault(f => f.Latitud == DatoZona).NumeroZona;

                return this._zonaMapper.MapToObject(context.T_Zona.AsNoTracking().FirstOrDefault(f => f.ID == numeroZona));
            }
        }
     
        public List<PuntosZona> GetPuntosZona()
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._zonaMapper.MapToObjectPuntos(context.T_Puntos_Zona.ToList());
            }
        }

    }
}
