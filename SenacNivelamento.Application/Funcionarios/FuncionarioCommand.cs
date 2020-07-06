using SenacNivelamento.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Application.Funcionarios
{
    public abstract class FuncionarioCommand : Command<FuncionarioCommandResult>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Pais { get; set; }
        public int CargoId { get; set; }
        public int EmpresaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}
