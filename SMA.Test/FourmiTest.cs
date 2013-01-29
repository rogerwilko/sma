using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMA.src.Model;
using SMA.Model;

namespace SMA.Test
{
    /// <summary>
    /// Description résumée pour FourmiTest
    /// </summary>
    [TestClass]
    public class FourmiTest
    {
        public FourmiTest()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestNaissanceFourmi()
        {
            Fourmiliere frml = Fourmiliere.Instance;

            Assert.IsNotNull(frml.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE));
            Assert.IsNotNull(frml.MakeFourmi(Fourmiliere.TYPE_NOURRICE));
            Assert.IsNotNull(frml.MakeFourmi(Fourmiliere.TYPE_OUVRIERE));
            
        }

        [TestMethod]
        public void TestMortFourmi()
        {
            Fourmiliere frml = Fourmiliere.Instance;
            Fourmi fC = frml.MakeFourmi(Fourmiliere.TYPE_CHASSEUSE);
            int nbFourmi = frml.NbrFourmis;
            frml.KillFourmi(fC);
            Assert.AreEqual(frml.NbrFourmis, nbFourmi - 1);

        }

        [TestMethod]
        public void TestExistenceReine()
        {
            Fourmiliere frml = Fourmiliere.Instance;
            Queen reine = frml.Reine;
            Assert.IsNotNull(reine);
            
        }

    }
}
