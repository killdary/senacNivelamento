using SenacNivelamento.Application.Cargos.Validations;
using SenacNivelamento.Application.Empresas.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas.Validations
{
    public class CreateEmpresaCommandValidation: EmpresaCommandValidation<CreateEmpresaCommand>
    {
        public CreateEmpresaCommandValidation()
        {
            ValidarNome();
            ValidaNomeFantasia();
            ValidaCnpj();
            ValidaLogradouro();
            ValidaCep();
        }

    }
}
