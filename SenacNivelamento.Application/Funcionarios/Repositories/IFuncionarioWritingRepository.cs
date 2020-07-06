using SenacNivelamento.Domain.Core.Repositories;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Funcionarios.Repositories
{
    public interface IFuncionarioWritingRepository : IBaseWritingRepository<Funcionario>
    {
        public Task<IList<Funcionario>> listarFuncionariosComIncludes();

        public Task<Funcionario> buscarFuncionarioLogin(string login);
    }
}
