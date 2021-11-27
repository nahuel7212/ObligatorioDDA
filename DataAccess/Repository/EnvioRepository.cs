using CommonSolution.DTO.Envios;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EnvioRepository
    {
        private EnvioMapper _envioMapper;

        public EnvioRepository()
        {
            this._envioMapper = new EnvioMapper();
        }

        public void AgregarEnvio(Envio envio)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        context.T_Direccion.Add(this._envioMapper.MapToEntity(envio));
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public bool ExisteNumeroTracking(int nroTracking)
        {
            using (DAKObligatorioEntities context = new DAKObligatorioEntities())
            {
                 return context.T_Envio.AsNoTracking().Any(a => a.NroTracking == nroTracking);
            }
        }
        
    }
}
