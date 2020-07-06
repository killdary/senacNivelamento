using SenacNivelamento.Application.Cargos.Repositories;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Infra.Writing.Data.Repositories
{
    public class CargoWritingRepository : BaseRepository<Cargo>, ICargoWritingRepository
    {
        public CargoWritingRepository(WritingContext context) : base(context)
        {
        }
    }
}
