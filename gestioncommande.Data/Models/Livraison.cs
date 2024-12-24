using System;

namespace gestioncommande.Models
{
    public class Livraison
    {
        public int LivraisonId { get; set; }
        public DateTime DateLivraison { get; set; }
        public string AdresseLivraison { get; set; }

        // Clé étrangère vers Commande
        public int CommandeId { get; set; }
        public Commande Commande { get; set; }

        // Clé étrangère vers Livreur
        public int LivreurId { get; set; }
        public Livreur Livreur { get; set; }

        // Constructeur pour initialiser les propriétés
        public Livraison(DateTime dateLivraison, string adresseLivraison, int commandeId, Commande commande, int livreurId, Livreur livreur)
        {
            DateLivraison = dateLivraison;
            AdresseLivraison = adresseLivraison;
            CommandeId = commandeId;
            Commande = commande;
            LivreurId = livreurId;
            Livreur = livreur;
        }
    }
}
