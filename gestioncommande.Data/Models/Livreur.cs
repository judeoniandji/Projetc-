using System.Collections.Generic;

namespace gestioncommande.Models
{
    public class Livreur
    {
        public int LivreurId { get; set; }
        public string Nom { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public string Prenom { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public string Telephone { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut

        // Relation avec Livraison
        public List<Livraison> Livraisons { get; set; } = new List<Livraison>();  // Initialisation de la liste
    }
}
