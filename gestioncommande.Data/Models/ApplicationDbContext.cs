using Microsoft.EntityFrameworkCore; // Essentiel pour DbContext et DbSet<T>
using gestioncommande.Models; // Assurez-vous que cet espace de noms est correct

namespace gestioncommande.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Définition des DbSets
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Versement> Versements { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<ProduitCommande> ProduitsCommandes { get; set; }

        // Constructeur pour l'injection des options de contexte
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Méthode pour la configuration supplémentaire des entités
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuration supplémentaire si nécessaire
        }
    }
}
