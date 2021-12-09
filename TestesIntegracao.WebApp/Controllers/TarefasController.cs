using Microsoft.AspNetCore.Mvc;
using TestesIntegracao.WebApp.Models;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Services.Handlers;
using TestesIntegracao.Infrastructure;
using Microsoft.Extensions.Logging;

namespace TestesIntegracao.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public TarefasController(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        {
            this._repo = repositorio;
            this._logger = logger;
        }


        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(_repo).Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);
            var handler = new CadastraTarefaHandler(_repo, _logger);
            var resultado = handler.Execute(comando);
            if (resultado.IsSuccess) return Ok();
            return StatusCode(500);
        }
    }
}