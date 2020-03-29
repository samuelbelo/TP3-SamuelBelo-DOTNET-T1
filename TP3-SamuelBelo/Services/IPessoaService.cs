using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SamuelBelo.Models;

namespace TP3_SamuelBelo.Services.Implementations
{
    public interface IPessoaService
    {
        int Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(int id);
        void Update(int id, Pessoa pessoa);
        void Delete(int id);
    }
}
