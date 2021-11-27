using CommonSolution.DTO.Envios;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class EnvioMapper
    {
        public T_Envio MapToEntity(Envio envio, bool mapId)
        {
            T_Envio entity = new T_Envio()
            {
                a
            };

            if (mapId)
                entity.ID = envio.IdEnvio;

            return entity;
        }

    }
}
