using System;
using System.Linq;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;

namespace TestesIntegracao.Services.Handlers
{
    public class GerenciaPrazoDasTarefasHandler
    {
        private readonly IRepositorioTarefas _repo;

        public GerenciaPrazoDasTarefasHandler(IRepositorioTarefas repositorio)
        {
            this._repo = repositorio;
        }

        public void Execute(GerenciaPrazoDasTarefas comando)
        {
            var agora = comando.DataHoraAtual;

            //pegar todas as tarefas não concluídas que passaram do prazo
            var tarefas = _repo
                .ObtemTarefas(t => t.Prazo <= agora && t.Status != StatusTarefa.Concluida)
                .ToList();

            //atualizá-las com status Atrasada
            tarefas.ForEach(t => t.Status = StatusTarefa.EmAtraso);

            //salvar tarefas
            _repo.AtualizarTarefas(tarefas.ToArray());
        }
    }
}
