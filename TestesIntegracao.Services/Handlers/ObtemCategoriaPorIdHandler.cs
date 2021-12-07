using TestesIntegracao.Core.Commands;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;

namespace TestesIntegracao.Services.Handlers
{
    public class ObtemCategoriaPorIdHandler
    {
        private readonly IRepositorioTarefas _repo;

        public ObtemCategoriaPorIdHandler(IRepositorioTarefas repositorio)
        {
            this._repo = repositorio;
        }
        public Categoria Execute(ObtemCategoriaPorId comando)
        {
            return _repo.ObtemCategoriaPorId(comando.IdCategoria);
        }
    }
}
