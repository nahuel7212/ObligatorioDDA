using CommonSolution.DTO.Clientes;
using DataAccess.Mapper.Cliente;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Cliente
{
    public class DireccionRepository
    {
        private DireccionMapper _direccionMapper;

        public DireccionRepository()
        {
            this._direccionMapper = new DireccionMapper();
        }

        public Direccion GetDireccion(long id)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                return this._direccionMapper.MapToObject(context.T_Direccion.AsNoTracking().FirstOrDefault(f => f.ID == id));
            }
        }

        public long AgregarDireccionReturnId(Direccion direccion)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        T_Direccion entity = this._direccionMapper.MapToEntity(direccion);
                        context.T_Direccion.Add(entity);
                        context.SaveChanges();
                        trann.Commit();

                        return entity.ID;
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            return 0;
        }

    }
}
