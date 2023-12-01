using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_CRUDE_Luiz.Model
{
    public class PessoaModel
    {
        public int Id          { get; set; }
        public string Name     { get; set; }
        public string Nasc     { get; set; }
        public string Sexo     { get; set; }
        public string Cpf      { get; set; }
        public string Celular  { get; set; }
        public string Endereco { get; set; }
        public string Bairro   { get; set; }
        public string Cidade   { get; set; }
        public string Estado   { get; set; }
        public string Cep      { get; set; }
    }
}
