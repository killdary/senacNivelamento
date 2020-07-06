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
    public class BuscarFuncionarioPorIdQuery : Query<QueryResult>
    {
        public long Id { get; set; }


        public class BuscarEmpresaPorIdQueryHandler : IRequestHandler<BuscarFuncionarioPorIdQuery, QueryResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;

            public BuscarEmpresaPorIdQueryHandler(
                IFuncionarioWritingRepository funcionarioContext)
            {
                _funcionarioContext = funcionarioContext;
            }

            public async Task<QueryResult> Handle(BuscarFuncionarioPorIdQuery request, CancellationToken cancellationToken)
            {

                var entity = await _funcionarioContext.FirstOrDefaultAsync(c => c.Id == request.Id);


                return new QueryResult(entity == null ? 0 : 1, entity);
            }
        }
    }
}
