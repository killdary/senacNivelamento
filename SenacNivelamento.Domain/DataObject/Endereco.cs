using System;
using System.Collections.Generic;
using System.Text;

namespace SenacNivelamento.Domain.DataObject
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Pais { get; set; }
    }
}
