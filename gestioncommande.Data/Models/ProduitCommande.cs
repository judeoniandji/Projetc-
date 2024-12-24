namespace gestioncommande.Models
{
    public class ProduitCommande
    {
        public int ProduitId { get; set; }

        // Clé étrangère vers Produit
        public Produit Produit { get; set; } = new Produit();  // Initialisation pour éviter les erreurs de nullabilité

        public int CommandeId { get; set; }

        // Clé étrangère vers Commande
        public Commande Commande { get; set; } = new Commande();  // Initialisation pour éviter les erreurs de nullabilité

        public int Quantite { get; set; }
    }
}
