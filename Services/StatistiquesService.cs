using GestionDesCommandes.Data;

namespace GestionDesCommandes.Services
{
    public class StatistiquesService : IStatistiquesService
    {
        private readonly GestionDesCommandesContext _context;

        public StatistiquesService(GestionDesCommandesContext context)
        {
            _context = context;
        }

        public async Task<int> GetOrdersOfDayAsync()
        {
            return await _context.Commandes
                .CountAsync(c => c.DateCommande.Date == DateTime.Now.Date);
        }

        public async Task<int> GetDeliveriesOfDayAsync()
        {
            return await _context.Livraisons
                .CountAsync(l => l.DateLivraison.Date == DateTime.Now.Date);
        }

        public async Task<int> GetPaymentsOfDayAsync()
        {
            return await _context.Paiements
                .CountAsync(p => p.DatePaiement.Date == DateTime.Now.Date);
        }
    }
}
