using GestionDesCommandes.Models;

namespace GestionDesCommandes.Services
{
    public interface IComptableService
    {
        Task<IEnumerable<Commande>> GetAllLivraisonsAsync();
        Task<IEnumerable<Commande>> GetPaidOrdersAsync();
        Task UpdateClientAccountAsync(int clientId, decimal paymentAmount);
    }
}
