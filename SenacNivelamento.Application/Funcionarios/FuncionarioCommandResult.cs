using SenacNivelamento.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Funcionarios
{
    public class FuncionarioCommandResult : CommandResult
    {
        public long Id { get; set; }
        public FuncionarioCommandResult()
        {

        }

        public FuncionarioCommandResult(long id)
        {
            Id = id;
        }
    }
}
