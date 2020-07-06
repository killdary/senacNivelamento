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
    public class DeleteEmpresaCommand : EmpresaCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteEmpresaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand, EmpresaCommandResult>
        {
            private readonly IEmpresaWritingRepository _empresaContext;


            public DeleteEmpresaCommandHandler(
                IEmpresaWritingRepository empresaContext)
            {
                _empresaContext = empresaContext;
            }

            public async Task<EmpresaCommandResult> Handle(DeleteEmpresaCommand request, CancellationToken cancellationToken)
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
                _empresaContext.Remove(entity.Id);
                await _empresaContext.SaveChangesAsync(cancellationToken);

                return new EmpresaCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
