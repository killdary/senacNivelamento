using SenacNivelamento.Domain.Core.Repositories;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Cargos.Repositories
{
    public interface ICargoWritingRepository : IBaseWritingRepository<Cargo>
    {
    }
}
