using SenacNivelamento.Application.Empresas.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas.Validations
{
    public class UpdateEmpresaImagemCommandValidation : EmpresaCommandValidation<UpdateEmpresaImagemCommand>
    {
        public UpdateEmpresaImagemCommandValidation()
        {
            ValidarId();
            ValidarImagem();
        }
    }
}
