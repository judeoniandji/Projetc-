using System;
using System.Collections.Generic;

namespace gestioncommande.Models
{
    public class Commande
    {
        public int CommandeId { get; set; }
        public DateTime Date { get; set; }
        public decimal Montant { get; set; }

        // Clé étrangère vers Client
        public int ClientId { get; set; }
        public Client Client { get; set; }

        // Relation plusieurs-à-plusieurs avec Produit via ProduitCommande
        public List<ProduitCommande> ProduitsCommandes { get; set; }

        // Relation avec Livraison
        public Livraison Livraison { get; set; }

        // Relation avec Versement
        public Versement Versement { get; set; }

        // Constructeur pour forcer l'initialisation des propriétés non-nullables
        public Commande(Client client, Livraison livraison, Versement versement)
        {
            Client = client;
            Livraison = livraison;
            Versement = versement;
            ProduitsCommandes = new List<ProduitCommande>();
        }

        public Commande()
        {
        }
    }
}
