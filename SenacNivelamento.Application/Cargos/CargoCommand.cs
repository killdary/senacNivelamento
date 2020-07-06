using SenacNivelamento.Domain.Commands;
using SenacNivelamento.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Cargos
{
    public abstract class CargoCommand : Command<CargoCommandResult>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public ENivelAcesso NivelAcesso{ get; set; }
    }
}
