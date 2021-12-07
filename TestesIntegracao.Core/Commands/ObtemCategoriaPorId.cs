using MediatR;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Core.Commands
{
    public class ObtemCategoriaPorId : IRequest<Categoria>
    {
        public ObtemCategoriaPorId(int idCategoria)
        {
            IdCategoria = idCategoria;
        }

        public int IdCategoria { get; }
    }
}