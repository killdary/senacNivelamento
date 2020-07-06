using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SenacNivelamento.Domain.Enumerators
{
    public enum ENivelAcesso
    {
        [Description("Administrador")]
        administrador = 1,
        [Description("Financeiro")]
        financeiro = 2,
        [Description("Usuario")]
        usuario = 3
    }
}
