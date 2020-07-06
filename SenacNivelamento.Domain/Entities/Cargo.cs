using SenacNivelamento.Domain.Common;
using SenacNivelamento.Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SenacNivelamento.Domain.Entities
{
    public class Cargo: Entity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public ENivelAcesso NivelAcesso{ get; set; }
        public IList<Funcionario> Funcionarios { get; set; }

    }
}
