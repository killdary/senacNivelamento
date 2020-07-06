using SenacNivelamento.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas
{
    public class EmpresaCommandResult: CommandResult
    {
        public long Id { get; set; }
        public EmpresaCommandResult()
        {

        }

        public EmpresaCommandResult(long id)
        {
            Id = id;
        }
    }
}
