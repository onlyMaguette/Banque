using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompteBanqueNS;

namespace BanqueTests
{
    [TestClass]
    public class CompteBancaireTests
    {
        [TestMethod]
        public void VérifierDébitCompteCorrect()
        {
            double soldeInitial = 500000;
            double montantDébit = 400000;
            double soldeAttendu = 100000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter le compte
            compte.Débiter(montantDébit);

            // Tester
            double soldeObtenu = compte.Balance;
            Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantNégatifLèveArgumentOutOfRange()
        {
            double soldeInitial = 500000;
            double montantADébiter = -100000; // Montant négatif
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter le compte (devrait lever une exception)
            compte.Débiter(montantADébiter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange()
        {
            double soldeInitial = 500000;
            double montantADébiter = 600000; // Montant supérieur au solde
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            // Débiter le compte (devrait lever une exception)
            compte.Débiter(montantADébiter);
        }
    }
}
