﻿using System;

namespace TestesIntegracao.Core.Commands
{
    /// <summary>
    /// Representa a necessidade de gerenciar o prazo das tarefas, verificando seu prazo e colocando as que expiraram em atraso. Um objeto dessa classe registra as informações necessárias para executar esse "caso de uso".
    /// </summary>
    public class TTTGerenciaPrazoDasTarefas
    {
        public TTTGerenciaPrazoDasTarefas(DateTime dataHoraAtual )
        {
            DataHoraAtual = dataHoraAtual;
        }

        public DateTime DataHoraAtual { get; }
    }
}