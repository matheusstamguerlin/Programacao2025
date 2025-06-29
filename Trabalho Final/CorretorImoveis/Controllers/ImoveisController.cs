using CorretorImoveis.Data;
using CorretorImoveis.Models;
using CorretorImoveis.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CorretorImoveis.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly Repositorio _repositorio = new Repositorio();
        private readonly ExportacaoService _exportacaoService = new ExportacaoService();

        public IActionResult Index() => View(_repositorio.ObterTodosImoveis());

        [HttpGet]
        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _repositorio.AdicionarImovel(imovel);
                return RedirectToAction("Index");
            }
            return View(imovel);
        }

        public IActionResult Exportar()
        {
            var conteudo = _exportacaoService.GerarArquivoTexto(_repositorio.ObterTodosImoveis());
            return File(Encoding.UTF8.GetBytes(conteudo), "text/plain", $"imoveis_{DateTime.Now:yyyyMMddHHmmss}.txt");
        }
    }
}