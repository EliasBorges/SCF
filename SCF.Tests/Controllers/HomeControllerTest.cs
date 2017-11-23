﻿using System;
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

        #region TesteValidaIdade
        [TestMethod]

        public void TesteValidaIdade()
        {

        }

        #endregion

        #region TesteValidaContinuaDependenteMaior18NaoEstudante
        [TestMethod]

        public void TesteValidaContinuaDependenteMaior18NaoEstudante()
        {

        }

        #endregion

        #region TesteValidaContaReceberAberto
        [TestMethod]

        public void TesteValidaContaReceberAberto()
        {

        }

        #endregion

        #region TesteValidaContaReceberPago
        [TestMethod]

        public void TesteValidaContaReceberPago()
        {

        }

        #endregion

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

        #region TesteConveniadoInativoComDebito
        [TestMethod]

        public void TesteConveniadoInativoComDebito()
        {
            
        }

        #endregion

        #region TesteConveniadoInativos
        [TestMethod]

        public void TesteConveniadoInativo()
        {

        }

        #endregion


        #region TesteValidaContinuaDependenteMaior18Estudante
        [TestMethod]

        public void TesteValidaContinuaDependenteMaior18Estudante()
        {

        }

        #endregion

        #region TesteValidaContinuaDependenteMaior24Estudante
        [TestMethod]

        public void TesteValidaContinuaDependenteMaior24Estudante()
        {

        }

        #endregion

        //[TestMethod]
        //public void Index()                                     
        //{

        //    try
        //    {
        //        controller.Create(conveniado);
        //        Assert.IsTrue(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(false);
        //    }
        //}

        [TestMethod]
        public void ViewManterConveniado()
        {
            try { 
            ConveniadoController index = new ConveniadoController();
            ViewResult result = index.Index() as ViewResult;
            Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                ConveniadoController index = new ConveniadoController();
                ViewResult result = index.Index() as ViewResult;
                Assert.IsNull(result);
            }
        }

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}
