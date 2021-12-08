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

        public CadastraTarefaHandler(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        {
            _repo = repositorio;
            _logger = logger;
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
                _logger.LogDebug($"Persistindo a tarefa {tarefa.Titulo}");
                _repo.IncluirTarefas(tarefa);
                return new ComandResult(true);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message); //Log de exceção
                return new ComandResult(false);
            }            
        }
    }
}