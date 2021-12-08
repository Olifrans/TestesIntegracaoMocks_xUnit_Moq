using System;

namespace TestesIntegracao.Core.Models
{
    /// <summary>
    /// Representa uma classificação dada a <see cref="TTTTarefa"/>.
    /// </summary>
    public class TTTCategoria
    {
        public TTTCategoria(string descricao)
        {
            Descricao = descricao;
        }

        public TTTCategoria(int id, string descricao) : this(descricao)
        {
            Id = id;
        }

        /// <summary>
        /// Identificador da categoria
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; private set; }
    }
}
