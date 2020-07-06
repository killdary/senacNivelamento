using MediatR;
using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Cargos.Repositories;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Domain.Core.Queries;
using SenacNivelamento.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Cargos.Queries
{
    public class BuscarListaCargoQuery : Query<QueryResult>
    {
        public long Id { get; set; }
        public class BuscarListaCargoQueryHandler : IRequestHandler<BuscarListaCargoQuery, QueryResult>
        {
            private readonly ICargoWritingRepository _cargoContext;

            public BuscarListaCargoQueryHandler(
                ICargoWritingRepository cargoContext)
            {
                _cargoContext = cargoContext;
            }

            public async Task<QueryResult> Handle(BuscarListaCargoQuery request, CancellationToken cancellationToken)
            {
                var entidades = await _cargoContext.ToListAsync();
                var count = await _cargoContext.CountAsync();

                return new QueryResult(count, entidades);
            }
        }
    }
}
