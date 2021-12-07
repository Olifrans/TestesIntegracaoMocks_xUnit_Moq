using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;
using TestesIntegracao.Core.Commands;
using TestesIntegracao.Core.Models;
using TestesIntegracao.Infrastructure;
using TestesIntegracao.Services.Handlers;
using Xunit;

namespace TestesIntegracao.Tests
{
    public class CadastraTarefaHandlerExecute        
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //Fases!!!!!!
            //arrange >>comando
            var comando = new CadastraTarefa("Estuadar Xunit", new Core.Models.Categoria("Estudo")
                , new DateTime(2021, 12, 31));


            //var repo = new RepositorioFake();//usando reposito fek
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto); //usando reposito real

            var handler = new CadastraTarefaHandler(repo); //tratador comando
            
            
            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute


            //Assert
            var  tarefa = repo.ObtemTarefas(t => t.Titulo == "Estuadar Xunit").FirstOrDefault();
            Assert.NotNull(tarefa); 


            //Criar Comando
            //Executar Comando
        }






        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            
            //arrange >>comando
            var comando = new CadastraTarefa("Estuadar Xunit", new Core.Models.Categoria("Estudo")
                , new DateTime(2021, 12, 31));


            //var repo = new RepositorioFake();//usando reposito fek
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto); 

            var handler = new CadastraTarefaHandler(repo);

            //act
            ComandResult resultado = handler.Execute(comando);

            //Assert
            Assert.False(resultado.IsSuccess);
        }


    }
}
