using CommonSolution.DTO.Clientes;
using DataAccess.Mapper.Cliente;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Cliente
{
    public class PersonaRepository
    {
        private PersonaMapper _personaMapper;

        public PersonaRepository()
        {
            this._personaMapper = new PersonaMapper();
        }

        public bool ExistePersona(string documento)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return context.T_Persona.Any(a => a.Documento == documento);
            }
        }

        public Persona GetPersona(string documento)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._personaMapper.MapToObject(context.T_Cliente.AsNoTracking().Include("T_Persona").AsNoTracking().FirstOrDefault(f => f.IDPersona == documento));
            }
        }
    }
}
