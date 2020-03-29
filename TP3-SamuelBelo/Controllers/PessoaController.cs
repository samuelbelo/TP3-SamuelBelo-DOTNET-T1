using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TP3_SamuelBelo.Models;
using TP3_SamuelBelo.Repositorys;
using TP3_SamuelBelo.Repositorys.Implementations;
using TP3_SamuelBelo.Services.Implementations;

namespace TP3_SamuelBelo.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(
            IConfiguration configuration)
        {
            _pessoaService = new PessoaService(
                new PessoaRepository(configuration));
        }


        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoas = _pessoaService.GetAll();
            return View(pessoas);
        }


        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaAggregateViewModel pessoaAggregateViewModel)
        {
            try
            {
                _pessoaService.Add(new Pessoa {
                    Nome = pessoaAggregateViewModel.NomePessoa, 
                    DataNascimento = pessoaAggregateViewModel.DataNascimento.ToString() 
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                _pessoaService.Update(id, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = _pessoaService.GetById(id);
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pessoa pessoa)
        {
            try
            {
                // TODO: Add delete logic here
                 _pessoaService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}