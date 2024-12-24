using System.Collections.Generic;

namespace gestioncommande.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }
        public string Libelle { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut
        public int QuantiteEnStock { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int QuantiteSeuil { get; set; }
        public string Image { get; set; } = string.Empty;  // Non-nullable avec valeur par défaut

        // Relation avec les commandes via ProduitCommande
        public List<ProduitCommande> ProduitsCommandes { get; set; } = new List<ProduitCommande>();  // Initialisation de la liste
    }
}
