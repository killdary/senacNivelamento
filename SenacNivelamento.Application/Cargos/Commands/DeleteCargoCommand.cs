using MediatR;
using Microsoft.EntityFrameworkCore;
using SenacNivelamento.Application.Cargos.Repositories;
using SenacNivelamento.Application.Cargos.Validations;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Application.Cargos.Commands
{
    public class DeleteCargoCommand : CargoCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeleteCargoCommandHandler : IRequestHandler<DeleteCargoCommand, CargoCommandResult>
        {
            private readonly ICargoWritingRepository _cargoContext;

            public DeleteCargoCommandHandler(
                IApplicationDbContext context,
                ICargoWritingRepository cargoContext)
            {
                _cargoContext = cargoContext;
            }
            public async Task<CargoCommandResult> Handle(DeleteCargoCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new CargoCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var entity = await _cargoContext.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (entity == null)
                {
                    var response = new CargoCommandResult();
                    response.AddNotification(nameof(Cargo), "Registro não foi encontrado");
                    return response;
                }

                _cargoContext.Remove(entity.Id);
                await _cargoContext.SaveChangesAsync(cancellationToken);

                return new CargoCommandResult()
                {
                    Id = entity.Id
                };

            }
        }
    }
}
