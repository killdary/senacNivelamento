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
    public class BuscarEmpresaQuery : Query<QueryResult>
    {
        public long Id { get; set; }
        public class BuscarCargoPorIdQueryHandler : IRequestHandler<BuscarEmpresaQuery, QueryResult>
        {
            private readonly IEmpresaWritingRepository _empresaContext;

            public BuscarCargoPorIdQueryHandler(
                IEmpresaWritingRepository empresaContext)
            {
                _empresaContext = empresaContext;
            }

            public async Task<QueryResult> Handle(BuscarEmpresaQuery request, CancellationToken cancellationToken)
            {
                var entidades = await _empresaContext.ToListAsync();
                var count = await _empresaContext.CountAsync();

                return new QueryResult(count, entidades);
            }
        }
    }
}
