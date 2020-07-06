using SenacNivelamento.Application.Cargos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos.Validations
{
    public class CreateCargoCommandValidation: CargoCommandValidation<CreateCargoCommand>
    {
        public CreateCargoCommandValidation()
        {
            ValidarNome();
            ValidarSigla();
        }

    }
}
