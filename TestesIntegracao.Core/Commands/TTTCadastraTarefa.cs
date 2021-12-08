using System;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Core.Commands
{
    /// <summary>
    /// Informações necessárias para cadastrar uma tarefa.
    /// </summary>
    public class TTTCadastraTarefa
    {
        public TTTCadastraTarefa(string titulo, TTTCategoria categoria, DateTime prazo)
        {
            Titulo = titulo;
            Categoria = categoria;
            Prazo = prazo;
        }

        public string Titulo { get; }
        public TTTCategoria Categoria { get; }
        public DateTime Prazo { get; }
    }
}