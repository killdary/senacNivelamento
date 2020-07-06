using MediatR;
using SenacNivelamento.Application.Common.Services;
using SenacNivelamento.Application.Funcionarios.Repositories;
using SenacNivelamento.Domain.Core.Queries;
using SenacNivelamento.Domain.Entities;
using SenacNivelamento.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Funcionarios.Queries
{
    public class BuscarFuncionarioLoginQuery : Query<QueryResult>
    {
        public string Login { get; set; }
        public string Senha { get; set; }


        public class BuscarFuncionarioLoginQueryHandler : IRequestHandler<BuscarFuncionarioLoginQuery, QueryResult>
        {
            private readonly IFuncionarioWritingRepository _funcionarioContext;

            public BuscarFuncionarioLoginQueryHandler(
                IFuncionarioWritingRepository funcionarioContext)
            {
                _funcionarioContext = funcionarioContext;
            }

            public async Task<QueryResult> Handle(BuscarFuncionarioLoginQuery request, CancellationToken cancellationToken)
            {

                var entity = await _funcionarioContext.buscarFuncionarioLogin(request.Login);

                if (entity == null)
                {
                    var response = new QueryResult(0, null);
                    response.AddNotification(nameof(Funcionario), "Login ou senha incorretos.");
                    return response;
                }

                byte[] data = Encoding.ASCII.GetBytes(request.Senha);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                var senha = Encoding.ASCII.GetString(data);

                if (!senha.Equals(entity.Senha))
                {
                    var response = new QueryResult(0, null);
                    response.AddNotification(nameof(Funcionario), "Login ou senha incorretos.");
                    return response;
                }

                var token = TokenService.GenerateToken(entity);


                return new QueryResult(entity == null ? 0 : 1, new
                {
                    funcionario = entity,
                    token = token
                });
            }
        }
    }
}
