using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMA.src.Model;

namespace SMA.Test
{
    /// <summary>
    /// Description résumée pour DistributionsTest
    /// </summary>
    [TestClass]
    public class DistributionsTest
    {
        

        public DistributionsTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
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
        public void TestPileOuFace()
        {

            Distributions dist = Distributions.Instance;
            int x = 0;
            long[] histo = new long[2];
            histo[0] = 0;
            histo[1] = 0;

            for (int i = 0; i < 1000000; i++)
            {
                x = dist.PileOuFace();
                histo[x]++;
            }
            double  freq= ((double) histo[0] / (double)1000000);
            
            Assert.IsTrue( (freq > 0.49) && ( freq < 0.51)); // 2% d'erreur
        }
    }
}
