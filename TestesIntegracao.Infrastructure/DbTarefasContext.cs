using Microsoft.EntityFrameworkCore;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Infrastructure
{
    public class DbTarefasContext : DbContext
    {
        public DbTarefasContext(DbContextOptions options) : base(options)
        {
        }

        public DbTarefasContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder
                .UseSqlServer("Server=ITI-DEV-01;Database=DbTarefas;Trusted_Connection=true");
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
