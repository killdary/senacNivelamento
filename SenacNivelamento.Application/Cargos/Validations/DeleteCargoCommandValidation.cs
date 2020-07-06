using SenacNivelamento.Application.Cargos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos.Validations
{
    class DeleteCargoCommandValidation : CargoCommandValidation<DeleteCargoCommand>
    {
        public DeleteCargoCommandValidation()
        {
            ValidarId();
        }

    }
}
