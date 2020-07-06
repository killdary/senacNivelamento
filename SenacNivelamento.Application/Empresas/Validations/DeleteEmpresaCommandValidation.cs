using SenacNivelamento.Application.Empresas.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas.Validations
{
    class DeleteEmpresaCommandValidation : EmpresaCommandValidation<DeleteEmpresaCommand>
    {
        public DeleteEmpresaCommandValidation()
        {
            ValidarId();
        }
    }
}
