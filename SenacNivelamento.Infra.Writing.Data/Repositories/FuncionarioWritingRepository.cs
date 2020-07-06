using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Funcionarios.Repositories;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenacNivelamento.Infra.Writing.Data.Repositories
{
    public class FuncionarioWritingRepository : BaseRepository<Funcionario>, IFuncionarioWritingRepository
    {
        public FuncionarioWritingRepository(WritingContext context) : base(context)
        {
        }

        public async Task<Funcionario> buscarFuncionarioLogin(string login)
            => await _dbSet
                .AsNoTracking()
                .Include(f => f.Cargo)
                .FirstOrDefaultAsync(f => f.Login.ToLower().Equals(login.ToLower()));

        public async Task<IList<Funcionario>> listarFuncionariosComIncludes()
            => await _dbSet
                .Include(x => x.Cargo)
                .Include(x => x.Empresa)
                .ToListAsync();
    }
}
