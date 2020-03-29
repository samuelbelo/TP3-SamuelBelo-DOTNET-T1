using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_SamuelBelo.Models
{
    public class PessoaAggregateViewModel
    {
        [Description("Nome da Pessoa")]
        public string NomePessoa { get; set; }
        [Description("Data de nascimento da dita-cuja")]
        public DateTime DataNascimento { get; set; }
    }
}
