using System;

namespace gestioncommande.Models
{
    public class Versement
    {
        public int VersementId { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }
        public string Type { get; set; } // Type de paiement (OM, Wave, chèque, etc.)

        // Clé étrangère vers Commande
        public int CommandeId { get; set; }

        // Clé étrangère vers Commande
        public Commande Commande { get; set; } = new Commande();  // Initialisation pour éviter les erreurs de nullabilité
    }
}
