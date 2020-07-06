using SenacNivelamento.Application.Empresas.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas.Validations
{
    class UpdateEmpresaCommandValidation : EmpresaCommandValidation<UpdateEmpresaCommand>
    {
        public UpdateEmpresaCommandValidation()
        {
            ValidarId();
            ValidarNome();
            ValidaNomeFantasia();
            ValidaCnpj();
            ValidaLogradouro();
            ValidaCep();
        }
    }
}
