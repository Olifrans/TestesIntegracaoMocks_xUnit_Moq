using System;
using System.Collections.Generic;
using System.Text;

namespace TestesIntegracao.Core.Models
{
    /// <summary>
    /// Representa uma tarefa a ser realizada.
    /// </summary>
    public class TTTTarefa
    {
        public TTTTarefa()
        {

        }

        public TTTTarefa(int id, string titulo, TTTCategoria categoria, DateTime prazo, DateTime? concluidaEm, TTTStatusTarefa status)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Categoria = categoria;
            this.Prazo = prazo;
            this.ConcluidaEm = concluidaEm;
            this.Status = status;
        }

        /// <summary>
        /// Identificador da tarefa.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título da tarefa.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Categoria da tarefa.
        /// </summary>
        public TTTCategoria Categoria { get; set; }

        /// <summary>
        /// Prazo da tarefa
        /// </summary>
        public DateTime Prazo { get; set; }

        /// <summary>
        /// Indica quando a tarefa foi concluída
        /// </summary>
        public DateTime? ConcluidaEm { get; set; }

        /// <summary>
        /// Estado atual da tarefa
        /// </summary>
        public TTTStatusTarefa Status { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Titulo}, {Categoria.Descricao}, {Prazo.ToString("dd/MM/yyyy")}";
        }
    }
}
