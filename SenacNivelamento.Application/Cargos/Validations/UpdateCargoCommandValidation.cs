using SenacNivelamento.Application.Cargos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos.Validations
{
    class UpdateCargoCommandValidation : CargoCommandValidation<UpdateCargoCommand>
    {
        public UpdateCargoCommandValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarSigla();
        }

    }
}
