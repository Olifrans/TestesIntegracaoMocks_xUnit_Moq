﻿using System;
using System.Collections.Generic;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Infrastructure
{
    public interface IRepositorioTarefas
    {
        void IncluirTarefas(params Tarefa[] tarefas);

        void AtualizarTarefas(params Tarefa[] tarefas);

        void ExcluirTarefas(params Tarefa[] tarefas);

        Categoria ObtemCategoriaPorId(int id);

        IEnumerable<Tarefa> ObtemTarefas(Func<Tarefa, bool> filtro);
    }
}