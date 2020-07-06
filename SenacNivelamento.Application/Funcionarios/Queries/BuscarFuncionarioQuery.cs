using MediatR;
using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Application.Funcionarios.Repositories;
using SenacNivelamento.Domain.Core.Queries;
using SenacNivelamento.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Funcionarios.Queries
{
    public class BuscarFuncionarioQuery : Query<QueryResult>
    {
        public long Id { get; set; }


        public class BuscarEmpresaPorIdQueryHandler : IRequestHandler<BuscarFuncionarioQuery, QueryResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;

            public BuscarEmpresaPorIdQueryHandler(
                IFuncionarioWritingRepository funcionarioContext)
            {
                _funcionarioContext = funcionarioContext;
            }

            public async Task<QueryResult> Handle(BuscarFuncionarioQuery request, CancellationToken cancellationToken)
            {

                var entidades = await _funcionarioContext.listarFuncionariosComIncludes();
                var count = await _funcionarioContext.CountAsync();

                return new QueryResult(count, entidades);
            }
        }
    }
}

