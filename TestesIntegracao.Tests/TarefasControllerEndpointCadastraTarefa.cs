using System;
using TestesIntegracao.WebApp.Controllers;
using TestesIntegracao.WebApp.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TestesIntegracao.Tests
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTerefaComInfomacoesValidasDeveRetornar200()
        {
            //arrange ---> entrada
            var controlador = new TarefasController();
            var model = new CadastraTarefaVM();

            model.IdCategoria = 20;
            model.Titulo = "Estudar Xunit";
            model.Prazo = new DateTime(2021, 12, 31);
           


            //act ---> metodo sobre teste
            var retorno = controlador.EndpointCadastraTarefa(model);


            //assert ---> saida
            Assert.IsType<OkResult>(retorno);
;

        }
    }
}
