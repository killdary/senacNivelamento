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
    public class UpdateCargoCommand : CargoCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateCargoCommandHandler : IRequestHandler<UpdateCargoCommand, CargoCommandResult>
        {
            private readonly ICargoWritingRepository _cargoContext;

            public UpdateCargoCommandHandler(
                ICargoWritingRepository cargoContext)
            {
                _cargoContext = cargoContext;
            }

            public async Task<CargoCommandResult> Handle(UpdateCargoCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new CargoCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var cargo = _cargoContext.FirstOrDefaultAsync(c => c.Nome.Equals(request.Nome) || c.Sigla.Equals(request.Sigla));

                if (cargo == null)
                {
                    var response = new CargoCommandResult();
                    response.AddNotification(nameof(Cargo), "Já existe um cargo com este nome ou sigla.");
                    return response;
                }

                var entity = await _cargoContext.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (entity == null)
                {
                    var response = new CargoCommandResult();
                    response.AddNotification(nameof(Cargo), "Registro não foi encontrado");
                    return response;
                }

                entity.Nome = request.Nome;
                entity.Sigla = request.Sigla;
                entity.NivelAcesso = request.NivelAcesso;

                _cargoContext.Update(entity);
                await _cargoContext.SaveChangesAsync(cancellationToken);

                return new CargoCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
