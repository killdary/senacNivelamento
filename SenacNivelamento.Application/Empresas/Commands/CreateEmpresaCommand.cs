using MediatR;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Application.Empresas.Repositories;
using SenacNivelamento.Application.Empresas.Validations;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Empresas.Commands
{
    public class CreateEmpresaCommand : EmpresaCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new CreateEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreateCargoCommandHandler : IRequestHandler<CreateEmpresaCommand, EmpresaCommandResult>
        {
            private readonly IEmpresaWritingRepository _empresaContext;

            public CreateCargoCommandHandler(
                IEmpresaWritingRepository empresaContext)
            {
                _empresaContext = empresaContext;
            }

            public async Task<EmpresaCommandResult> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new EmpresaCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = new Empresa
                {
                    Nome = request.Nome,
                    NomeFantasia = request.NomeFantasia,
                    Cnpj = request.CNPJ,
                    Logradouro = request.Logradouro,
                    Numero = request.Numero,
                    Bairro = request.Bairro,
                    Cidade = request.Cidade,
                    Estado = request.Estado,
                    Cep = request.Cep,
                    Pais = request.Pais
                };

                _empresaContext.Add(entity);
                await _empresaContext.SaveChangesAsync(cancellationToken);

                return new EmpresaCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
