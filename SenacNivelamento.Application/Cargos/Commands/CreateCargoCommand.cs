using MediatR;
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
    public class CreateCargoCommand : CargoCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new CreateCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, CargoCommandResult>
        {
            private readonly ICargoWritingRepository _cargoContext;

            public CreateCargoCommandHandler(
                IApplicationDbContext context,
                ICargoWritingRepository cargoContext)
            {
                _cargoContext = cargoContext;
            }

            public async Task<CargoCommandResult> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
            {
                if (!request.IsValid())
                {
                    var response = new CargoCommandResult();
                    response.CopyErrorsFromValidations(request.ValidationResult);
                    return response;
                }

                var cargo = _cargoContext.FirstOrDefaultAsync(c => c.Nome.Equals(request.Nome)|| c.Sigla.Equals(request.Sigla));

                if (cargo == null)
                {
                    var response = new CargoCommandResult();
                    response.AddNotification(nameof(Cargo), "Já existe um cargo com este nome ou sigla.");
                    return response;
                }

                var entity = new Cargo
                {
                    Nome = request.Nome,
                    Sigla = request.Sigla,
                    NivelAcesso = request.NivelAcesso
                };

                _cargoContext.Add(entity);
                await _cargoContext.SaveChangesAsync(cancellationToken);

                return new CargoCommandResult()
                {
                    Id = entity.Id
                };
            }
        }
    }
}
