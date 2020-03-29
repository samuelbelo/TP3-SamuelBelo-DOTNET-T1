    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SamuelBelo.Models;
using TP3_SamuelBelo.Repositorys;

namespace TP3_SamuelBelo.Services.Implementations
{
    public class PessoaService : IPessoaService
    {
        public readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public int Add(Pessoa pessoa)
        {
            if (pessoa == null)
                throw new ArgumentNullException(paramName: "Pessoa nao pode ser vazio");

            if(string.IsNullOrWhiteSpace(pessoa.Nome))
                throw new ArgumentException(message: "Nome inválido");

            var id = _pessoaRepository.Add(pessoa);

            return id;

        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }
    }
}
