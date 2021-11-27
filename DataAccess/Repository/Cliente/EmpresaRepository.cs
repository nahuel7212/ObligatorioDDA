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
    public class EmpresaRepository
    {
        private EmpresaMapper _empresaMapper;

        public EmpresaRepository()
        {
            this._empresaMapper = new EmpresaMapper();
        }
        public bool ExisteEmpresa(string rut)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return context.T_Empresa.Any(a => a.Rut == rut);
            }
        }

        public Empresa GetEmpresa(string rut)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._empresaMapper.MapToObject(context.T_Empresa.AsNoTracking().FirstOrDefault(f => f.Rut == rut));
            }
        }
    }
}
