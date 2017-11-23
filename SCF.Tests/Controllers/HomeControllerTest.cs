using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCF;
using SCF.Controllers;
using SCF.Models;
using NSubstitute;
using SCF.BancoDados;

namespace SCF.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        public ConveniadoController controller;
        public Conveniado conveniado;
        //private ConveniadoController mock;
        private SCFContext db = new SCFContext();

        #region ContasReceber

        #region TesteSomaValor500ValorPago50retorna450
        [TestMethod]
        public void TesteValor500ValorPago50()
        {
            decimal esperado = 450;
            var contasReceber = new ContasReceber
            {
                Valor = 500,
                ValorPago = 50
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaValorPago(contasReceber.Valor, contasReceber.ValorPago);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteSomaValor500ValorPago500retorna0
        [TestMethod]
        public void TesteValor500ValorPago500()
        {
            decimal esperado = 0;
            var contasReceber = new ContasReceber
            {
                Valor = 500,
                ValorPago = 500
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaValorPago(contasReceber.Valor, contasReceber.ValorPago);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteValorMenorQueValorPago
        [TestMethod]
        public void TesteValorMenorQueValorPago()
        {
            decimal esperado = 0;
            var contasReceber = new ContasReceber
            {
                Valor = 500,
                ValorPago = 700
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaValorPago(contasReceber.Valor, contasReceber.ValorPago);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteSomaValor500Desconto50retorna450
        [TestMethod]
        public void TesteSomaValor500Desconto50retorna450()
        {
            decimal esperado = 450;
            var contasReceber = new ContasReceber
            {
                Valor = 500,
                Desconto = 50
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaValorcomDesconto(contasReceber.Valor, contasReceber.Desconto);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteValorMenorQueDesconto
        [TestMethod]
        public void TesteValorMenorQueDesconto()
        {
            decimal esperado = 500;
            var contasReceber = new ContasReceber
            {
                Valor = 500,
                Desconto = 700
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaValorcomDesconto(contasReceber.Valor, contasReceber.Desconto);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteDesdobramentoValor1200Desdobramento12retorna100
        [TestMethod]
        public void TesteDesdobramentoValor1200Desdobramento12()
        {
            decimal esperado = 100;
            var contasReceber = new ContasReceber
            {
                Valor = 1200
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.CalculaDesdobramento(contasReceber.Valor);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteValidaSituacaoContasReceberAbertoRetornaAberto
        [TestMethod]

        public void TesteValidaContasReceberEmAberto()
        {
            string esperado = "A";

            var contasReceber = new ContasReceber
            {
                SituacaoContasReceber = 1
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.SituacaoPagamento(contasReceber.SituacaoContasReceber);
            Assert.AreEqual(esperado, teste);
        }

        #endregion

        #region TesteValidaSituacaoContaReceberPagoRetornaFechado
        [TestMethod]

        public void TesteValidaContaReceberPago()
        {
            string esperado = "F";

            var contasReceber = new ContasReceber
            {
                SituacaoContasReceber = 2
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.SituacaoPagamento(contasReceber.SituacaoContasReceber);
            Assert.AreEqual(esperado, teste);
        }

        #endregion

        #region TesteSituacaoContaReceberPagoRetornaInvalido
        [TestMethod]
        public void TesteContaReceberSituacaoPagamentoInvalida()
        {
            string esperado = "Invalido";

            var contasReceber = new ContasReceber
            {
                SituacaoContasReceber = 3
            };

            var mock = Substitute.ForPartsOf<ContasReceberController>();

            var teste = mock.SituacaoPagamento(contasReceber.SituacaoContasReceber);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #endregion

        #region Conveniado

        #region TesteValidaCPF
        [TestMethod]
        public void TesteValidaCPF()
        {
            bool esperado = true;

            var conveniado = new Conveniado
            {
                CPF = "06442894657"
            };

            var mock = Substitute.ForPartsOf<ConveniadoController>();

            var teste = mock.ValidaCPF(conveniado.CPF);

            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteConveniadoSituacaoConveniadoAtivo
        [TestMethod]
        public void TesteConveniadoAtivo()
        {
            string esperado = "Ativo";
            var conveniado = new Conveniado
            {
                SituacaoConveniado = true
            };

            var mock = Substitute.ForPartsOf<ConveniadoController>();

            var teste = mock.VerificarSituacaoConveniado(conveniado.SituacaoConveniado);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #region TesteConveniadoSituacaoConveniadoInativo
        [TestMethod]
        public void TesteConveniadoInativo()
        {
            string esperado = "Inativo";
            var conveniado = new Conveniado
            {
                SituacaoConveniado = false
            };

            var mock = Substitute.ForPartsOf<ConveniadoController>();

            var teste = mock.VerificarSituacaoConveniado(conveniado.SituacaoConveniado);
            Assert.AreEqual(esperado, teste);
        }
        #endregion

        #endregion

        #region View
        [TestMethod]
        public void ViewDeVisualizarConveniado()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViewDeCriarConveniado()
        {
            // Arrange
            ConveniadoController controllerConveniado = new ConveniadoController();

            // Act
            ViewResult result = controllerConveniado.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViewDeCriarContasReceber()
        {
            // Arrange
            ContasReceberController controllerContasReceber = new ContasReceberController();

            // Act
            ViewResult result = controllerContasReceber.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion
    }
}
