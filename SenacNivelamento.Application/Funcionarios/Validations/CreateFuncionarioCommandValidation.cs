using SenacNivelamento.Application.Funcionarios.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Funcionarios.Validations
{
    public class CreateFuncionarioCommandValidation : FuncionarioCommandValidation<CreateFuncionarioCommand>
    {
        public CreateFuncionarioCommandValidation()
        {
            ValidarNome();
            ValidarEmpresa();
            ValidarCargo();
            ValidaLogin();
            ValidaSenha();
            ValidaLogradouro();
            ValidaCep();
        }
    }
}
