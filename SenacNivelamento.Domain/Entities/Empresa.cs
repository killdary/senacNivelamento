using SenacNivelamento.Domain.Common;
using SenacNivelamento.Domain.DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SenacNivelamento.Domain.Entities
{
    public class Empresa: Entity
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Pais { get; set; }
        public string Imagem { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }
    }
}
