using SenacNivelamento.Domain.Common;
using SenacNivelamento.Domain.DataObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.Entities
{
    public class Funcionario: Entity
    {
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Cpf { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Pais { get; set; }
        public Cargo Cargo { get; set; }
        public long CargoId { get; set; }
        public Empresa Empresa { get; set; }
        public long EmpresaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
