using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Cargo> Cargos { get; set; }
        DbSet<Empresa> Empresas { get; set; }
        DbSet<Funcionario> Funcionarios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
