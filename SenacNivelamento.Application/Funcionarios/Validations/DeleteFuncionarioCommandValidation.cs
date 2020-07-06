using SenacNivelamento.Application.Funcionarios.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Funcionarios.Validations
{
    public class DeleteFuncionarioCommandValidation : FuncionarioCommandValidation<DeleteFuncionarioCommand>
    {
        public DeleteFuncionarioCommandValidation()
        {
            ValidarId();
        }
    }
}
