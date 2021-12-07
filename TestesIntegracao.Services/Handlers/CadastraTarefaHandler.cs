using Microsoft.Extensions.Logging;
using System;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;

namespace TestesIntegracao.Services.Handlers
{
    public class CadastraTarefaHandler
    {
        private readonly IRepositorioTarefas _repo;
        private readonly ILogger<CadastraTarefaHandler> _logger;

        //public CadastraTarefaHandler(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        //{
        //    _repo = repositorio;
        //    _logger = logger;
        //}

        public CadastraTarefaHandler(IRepositorioTarefas repositorio)
        {
            this._repo = repositorio;
            this._logger = new LoggerFactory().CreateLogger<CadastraTarefaHandler>();
        }


        public ComandResult Execute(CadastraTarefa comando)
        {
            try
            {
                var tarefa = new Tarefa
            (
                id: 0,
                titulo: comando.Titulo,
                prazo: comando.Prazo,
                categoria: comando.Categoria,
                concluidaEm: null,
                status: StatusTarefa.Criada
            );
                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirTarefas(tarefa);

                return new ComandResult(true);
            }
            catch (Exception e)
            {
                return new ComandResult(false);
            }            
        }
    }
}