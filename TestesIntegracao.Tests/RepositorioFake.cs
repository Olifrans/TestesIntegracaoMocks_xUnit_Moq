using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;

namespace TestesIntegracao.Tests //classe fake implementa o IRepositorioTarefas
{
    public class RepositorioFake : IRepositorioTarefas
    {
        List<Tarefa> lista = new List<Tarefa>();
        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            throw new NotImplementedException();
        }

        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            throw new Exception("Erro ao incluir tarefas");
            tarefas.ToList().ForEach(t => lista.Add(t));
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            return new Categoria(id, string.Empty);
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            return lista.Where(filtro);
        }
    }
}
