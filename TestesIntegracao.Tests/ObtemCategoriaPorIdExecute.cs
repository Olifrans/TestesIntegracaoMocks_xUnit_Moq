using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Infrastructure;
using TestesIntegracao.Services.Handlers;

namespace TestesIntegracao.Tests
{
    public class ObtemCategoriaPorIdExecute
    {
        [Fact]
        public void QuandoForChamadoDeveInvocarObtemCategoriaPorIdNoRepositorio()
        {
            //arrange
            var idCategoria = 20;

            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            var comando = new ObtemCategoriaPorId(idCategoria);
            var handler = new ObtemCategoriaPorIdHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}
