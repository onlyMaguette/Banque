using System;

/// <summary>
/// Classe démo compte bancaire.
/// </summary>
namespace CompteBanqueNS
{
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqué = false;
        private CompteBancaire() { } // Constructeur par défaut (privé

        public CompteBancaire(string nomClient, double solde)
        {
            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string nomClient
        {
            get { return m_nomClient; }
        }

        public double Balance
        {
            get { return m_solde; }
        }

        public void Débiter(double montant)
        {
            if (m_bloqué)
                throw new Exception("Compte bloqué");

            if (montant > m_solde)
                throw new ArgumentOutOfRangeException("Montant débité doit être inférieur ou égal au solde disponible");

            if (montant < 0)
                throw new ArgumentOutOfRangeException("Montant doit être positif");

            m_solde -= montant; // Déduit le montant du solde
        }

        public void Créditer(double montant)
        {
            if (m_bloqué)
                throw new Exception("Compte bloqué");

            if (montant < 0)
                throw new ArgumentOutOfRangeException("Montant crédité doit être supérieur à zéro");

            m_solde += montant; // Ajoute le montant au solde
        }

        private void BloquerCompte()
        {
            m_bloqué = true; // Bloque le compte
        }

        private void DébloquerCompte()
        {
            m_bloqué = false; // Débloque le compte
        }

        public static void Main(string[] args) // Correctement définie avec un tableau de chaînes
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
            cb.Créditer(50000);
            cb.Débiter(400000);
            Console.WriteLine("Solde disponible égal à F{0}", cb.Balance);
        }
    }
}
