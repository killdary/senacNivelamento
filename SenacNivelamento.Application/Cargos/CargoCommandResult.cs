using SenacNivelamento.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos
{
    public class CargoCommandResult: CommandResult
    {
        public long Id { get; set; }
        public CargoCommandResult()
        {

        }

        public CargoCommandResult(long id)
        {
            Id = id;
        }

    }
}
