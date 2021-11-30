using CommonSolution.DTO.Camiones;
using DataAccess.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.LControllers
{
    public class LZonaController
    {
        private Repositories repositories;

        public LZonaController()
        {
            repositories = new Repositories();
        }
        public List<PuntosZona> GetPuntosZona()
        {
            return repositories.GetZonaRepository().GetPuntosZona();
        }
    }
}
