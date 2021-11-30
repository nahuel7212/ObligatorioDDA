using CommonSolution.DTO.Funcionarios;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class FuncionarioRepository
    {
        private FuncionarioMapper _funcionarioMapper;

        public FuncionarioRepository()
        {
            this._funcionarioMapper = new FuncionarioMapper();
        }

        public Funcionario GetFuncionario(string documento)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._funcionarioMapper.MapToObject(context.T_Funcionario.AsNoTracking().FirstOrDefault(f => f.Documento == documento));
            }
        }

        public bool ExisteFuncionario(string documento)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return context.T_Funcionario.AsNoTracking().Any(a => a.Documento == documento);
            }
        }
    }
}
