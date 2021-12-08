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
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
                        
            var mock = new Mock<ILogger<CadastraTarefaHandler>>(); //mock

            //var repo = new RepositorioFake();//usando reposito fek
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto); //usando reposito real

            var handler = new CadastraTarefaHandler(repo, mock.Object); //tratador comando 
                       
            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //Assert
            var  tarefa = repo.ObtemTarefas(t => t.Titulo == "Estuadar Xunit").FirstOrDefault();
            Assert.NotNull(tarefa); 
        }




        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            //arrange >>comando
            var comando = new CadastraTarefa("Estuadar Xunit", new Core.Models.Categoria("Estudo") //--->Duplês Teste >> Dummy Object
                , new DateTime(2021, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>(); //mock

            //mock ---> Duplês Teste >> Stubs Object
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro na inclusão da tarefa"));
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            ComandResult resultado = handler.Execute(comando);

            //Assert
            Assert.False(resultado.IsSuccess);
        }




        delegate void CapturaMensagemLog(LogLevel level, EventId eventId, object state, Exception exception, Func<object, Exception, string> function);

        //Testes de inclusão de uma tarefa real
        [Fact]
        public void DadaTarefaComInfoValidasDeveLogar()
        {
            //arrange >>comando >>Duplê Teste >>  Stubs Spys -- Faz a verificação em cima do objeto simulada que esta ligado indireatmente aquele teste
            var tituloTarefaEsperado = "Usar Mock para estudar XunitNoDotNet";
            var comando = new CadastraTarefa(tituloTarefaEsperado, new Categoria(100, "Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            LogLevel levelCapturado = LogLevel.Error;             
            string mensagemCapturada = string.Empty;  
            
            CapturaMensagemLog captura = (level, eventId, state, exception, func) =>
            {
                levelCapturado = level;
                mensagemCapturada = func(state, exception);
            };

            mockLogger.Setup(l =>
            l.Log(
                It.IsAny<LogLevel>(), //nivel de log ==> log erro
                It.IsAny<EventId>(), //identificador do evento
                It.IsAny<object>(), //Objeto que sera logado
                It.IsAny<Exception>(), //exceção que sera logada
                It.IsAny<Func<object, Exception, string>>()//função que converte o objeto +exceção >> string
            )).Callback(captura);

            var mock = new Mock<IRepositorioTarefas>();
            var handler = new CadastraTarefaHandler(mock.Object, mockLogger.Object);

            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //Assert
            Assert.Equal(LogLevel.Error, levelCapturado);
            Assert.Contains("", mensagemCapturada);
        }




        //Testes para aparecer no log
        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            //arrange >>comando
            var mensagemDeErroEsperada = "Houve um erro na inclusão da tarefa";
            var excecaoEsperada = new Exception(mensagemDeErroEsperada);

            var comando = new CadastraTarefa("Estuadar Xunit", new Core.Models.Categoria("Estudo") //--->Duplês Teste >> Dummy Object
                , new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>(); //mock
            
            var mock = new Mock<IRepositorioTarefas>();//mock ---> Duplê Teste >> Stubs Object

            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(excecaoEsperada);

            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            ComandResult resultado = handler.Execute(comando);

            //Assert --> Com argumento especifico de erro + exceção
            mockLogger.Verify(l => 
            l.Log(
                LogLevel.Error, //nivel de log ==> log erro
                It.IsAny<EventId>(), //identificador do evento
                It.IsAny<object>(), //Objeto que sera logado
                excecaoEsperada, //exceção que sera logada
                It.IsAny<Func<object, Exception, string>>()
                ),//função que converte o objeto +exceção >> string
            Times.Once());
        }

    }
}
