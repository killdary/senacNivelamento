using MediatR;
using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Application.Empresas.Repositories;
using SenacNivelamento.Domain.Core.Queries;
using SenacNivelamento.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Empresas.Queries
{
    public class BuscarEmpresaPorIdQuery: Query<QueryResult>
    {
        public long Id { get; set; }


        public class BuscarEmpresaPorIdQueryHandler : IRequestHandler<BuscarEmpresaPorIdQuery, QueryResult>
        {
            private readonly IEmpresaWritingRepository _empresaContext;

            public BuscarEmpresaPorIdQueryHandler(
                IEmpresaWritingRepository empresaContext)
            {
                _empresaContext = empresaContext;
            }

            public async Task<QueryResult> Handle(BuscarEmpresaPorIdQuery request, CancellationToken cancellationToken)
            {

                var entity = await _empresaContext.FirstOrDefaultAsync(c => c.Id == request.Id);


                return new QueryResult(entity == null ? 0 : 1, entity);
            }
        }
    }
}
