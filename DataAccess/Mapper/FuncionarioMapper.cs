using CommonSolution.DTO.Funcionarios;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class FuncionarioMapper
    {
        public Funcionario MapToObject(T_Funcionario entity)
        {
            return new Funcionario()
            {
                Documento = entity.Documento,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Contrasenia = entity.Contraseña
            };
        }

    }
}
