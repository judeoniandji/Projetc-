using GestionDesCommandes.Models;

namespace GestionDesCommandes.Services
{
    public interface IRSService
    {
        Task<IEnumerable<Produit>> GetAllProduitsAsync();
        Task UpdateStockAsync(int produitId, int newStockQuantity);
        Task PlanifyDeliveryAsync(int commandeId, int livreurId);
    }
}
