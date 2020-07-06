using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateEmpresaCommand : EmpresaCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, EmpresaCommandResult>
        {
            private readonly IEmpresaWritingRepository _empresaContext;

            public UpdateEmpresaCommandHandler(
                IEmpresaWritingRepository empresaContext)
            {
                _empresaContext = empresaContext;
            }

            public async Task<EmpresaCommandResult> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new EmpresaCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _empresaContext.FirstOrDefaultAsync(e => e.Id == request.Id);

                if (entity == null)
                {
                    var response = new EmpresaCommandResult();
                    response.AddNotification(nameof(Empresa), "Registro não foi encontrado");
                    return response;
                }

                entity.Nome = request.Nome;
                entity.NomeFantasia = request.NomeFantasia;
                entity.Cnpj = request.CNPJ;
                entity.Logradouro = request.Logradouro;
                entity.Numero = request.Numero;
                entity.Bairro = request.Bairro;
                entity.Cidade = request.Cidade;
                entity.Estado = request.Estado;
                entity.Cep = request.Cep;
                entity.Pais = request.Pais;

                _empresaContext.Update(entity);
                await _empresaContext.SaveChangesAsync(cancellationToken);

                return new EmpresaCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
