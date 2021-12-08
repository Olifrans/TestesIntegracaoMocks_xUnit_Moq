using MediatR;
using TestesIntegracao.Core.Models;

namespace TestesIntegracao.Core.Commands
{
    public class TTTObtemCategoriaPorId : IRequest<TTTCategoria>
    {
        public TTTObtemCategoriaPorId(int idCategoria)
        {
            IdCategoria = idCategoria;
        }

        public int IdCategoria { get; }
    }
}