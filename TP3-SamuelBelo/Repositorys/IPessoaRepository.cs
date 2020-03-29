using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SamuelBelo.Models;

namespace TP3_SamuelBelo.Repositorys
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
    }
}
