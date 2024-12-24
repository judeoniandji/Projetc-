using GestionDesCommandes.Data;
using GestionDesCommandes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesCommandes.Services
{
    public class ComptableService : IComptableService
    {
        private readonly GestionDesCommandesContext _context;

        public ComptableService(GestionDesCommandesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commande>> GetAllLivraisonsAsync()
        {
            return await _context.Commandes
                .Where(c => c.Status == "Livrée")
                .ToListAsync();
        }

        public async Task<IEnumerable<Commande>> GetPaidOrdersAsync()
        {
            return await _context.Commandes
                .Where(c => c.Status == "Payée")
                .ToListAsync();
        }

        public async Task UpdateClientAccountAsync(int clientId, decimal paymentAmount)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client != null)
            {
                client.SoldeCompte += paymentAmount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
