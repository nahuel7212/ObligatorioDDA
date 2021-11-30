using DataAccess.Repository;
using DataAccess.Repository.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistance
{
    public class Repositories
    {
        //Cliente
        private PersonaRepository _personaRepository;
        private EmpresaRepository _empresaRepository;
        private DireccionRepository _direccionRepository;
        private GrupoPrecioRepository _grupoPrecioRepository;

        //Envio
        private EnvioRepository _envioRepository;

        //Zona
        private ZonaRepository _zonaRepository;

        //Funcionario
        private FuncionarioRepository _funcionarioRepository;


        public Repositories()
        {
            //Cliente
            this._personaRepository = new PersonaRepository();
            this._empresaRepository = new EmpresaRepository();
            this._direccionRepository = new DireccionRepository();
            this._grupoPrecioRepository = new GrupoPrecioRepository();

            //Envio
            this._envioRepository = new EnvioRepository();

            //Zona
            this._zonaRepository = new ZonaRepository();

            //Funcionario
            this._funcionarioRepository = new FuncionarioRepository();
        }

        //Cliente
        public PersonaRepository GetPersonaRepository()
        {
            return this._personaRepository;
        }
        public EmpresaRepository GetEmpresaRepository()
        {
            return this._empresaRepository;
        }
        public DireccionRepository GetDireccionRepository()
        {
            return this._direccionRepository;
        }
        public GrupoPrecioRepository GetGrupoPrecioRepository()
        {
            return this._grupoPrecioRepository;
        }

        //Envio
        public EnvioRepository GetEnvioRepository()
        {
            return this._envioRepository;
        }

        //Zona
        public ZonaRepository GetZonaRepository()
        {
            return this._zonaRepository;
        }

        //Funcionario
        public FuncionarioRepository GetFuncionarioRepository()
        {
            return this._funcionarioRepository;
        }
    }
}
