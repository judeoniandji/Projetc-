using GestionDesCommandes.Data;
using GestionDesCommandes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesCommandes.Services
{
    public class RSService : IRSService
    {
        private readonly GestionDesCommandesContext _context;

        public RSService(GestionDesCommandesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produit>> GetAllProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task UpdateStockAsync(int produitId, int newStockQuantity)
        {
            var produit = await _context.Produits.FindAsync(produitId);
            if (produit != null)
            {
                produit.QuantiteEnStock = newStockQuantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task PlanifyDeliveryAsync(int commandeId, int livreurId)
        {
            var commande = await _context.Commandes.FindAsync(commandeId);
            if (commande != null)
            {
                commande.LivreurId = livreurId;
                commande.Status = "Livraison planifiée";
                await _context.SaveChangesAsync();
            }
        }
    }
}
