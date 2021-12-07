﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Infrastructure
{
    public class RepositorioTarefa : IRepositorioTarefas
    {
        private readonly DbTarefasContext _ctx;

        public RepositorioTarefa(DbTarefasContext context)
        {
            this._ctx = context;
        }        

        public void AtualizarTarefas(params Tarefa[] tarefas)
        {
            _ctx.Tarefas.UpdateRange(tarefas);
            _ctx.SaveChanges();
        }

        public void ExcluirTarefas(params Tarefa[] tarefas)
        {
            _ctx.Tarefas.RemoveRange(tarefas);
            _ctx.SaveChanges();
        }

        public void IncluirTarefas(params Tarefa[] tarefas)
        {
            _ctx.Tarefas.AddRange(tarefas);
            _ctx.SaveChanges();
        }

        public Categoria ObtemCategoriaPorId(int id)
        {
            return _ctx.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro)
        {
            return _ctx.Tarefas.Where(filtro);
        }
    }
}