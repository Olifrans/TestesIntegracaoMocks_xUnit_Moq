using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;
using TestesIntegracao.Services.Handlers;
using Xunit;
using Moq;

namespace TestesIntegracao.Tests
{
    public class ObtemCategoriaPorIdExecute
    {
        [Fact]
        public void QuandoIdForExistenteDeveChamarObtemCategoriaPorIDUmaUnicaVez()
        {
            //arrange >>comando >>Duplês Teste >> Mocks Object --Verificado na fase de  Assert
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);
            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;
            var handler = new ObtemCategoriaPorIdHandler(repo); //tratador comando

            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //Assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}
