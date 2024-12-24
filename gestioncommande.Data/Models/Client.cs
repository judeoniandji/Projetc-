using System.Collections.Generic;

namespace gestioncommande.Models  // Changer à un seul espace de noms
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Nom { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public string Prenom { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public string Telephone { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public string Adresse { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public decimal SoldeCompte { get; set; }  // Non-nullable, assume decimal will not be null

        // Relation avec les commandes
        public List<Commande> Commandes { get; set; } = new List<Commande>();  // Initialisation de la liste
    }
}
