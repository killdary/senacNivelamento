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
    public class BuscarCargoPorIdQuery : Query<QueryResult>
    {
        public long Id { get; set; }
        public class BuscarCargoPorIdQueryHandler : IRequestHandler<BuscarCargoPorIdQuery, QueryResult>
        {
            private readonly ICargoWritingRepository _cargoContext;

            public BuscarCargoPorIdQueryHandler(
                ICargoWritingRepository cargoContext)
            {
                _cargoContext = cargoContext;
            }

            public async Task<QueryResult> Handle(BuscarCargoPorIdQuery request, CancellationToken cancellationToken)
            {

                var entity = await _cargoContext.FirstOrDefaultAsync(c => c.Id == request.Id);


                return new QueryResult(entity == null ? 0 : 1, entity);
            }
        }
    }
}
