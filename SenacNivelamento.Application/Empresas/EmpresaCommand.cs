using SenacNivelamento.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Empresas
{
    public abstract class EmpresaCommand : Command<EmpresaCommandResult>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Pais { get; set; }
        public string Imagem { get; set; }

    }
}
