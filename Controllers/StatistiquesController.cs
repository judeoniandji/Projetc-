using gestioncommande.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace gestioncommande.Controllers
{
    public class StatistiquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatistiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action pour afficher les statistiques du jour
        public IActionResult Index()
        {
            // R�cup�ration des commandes du jour
            var commandesDuJour = _context.Commandes
                .Where(c => c.DateCommande.Date == System.DateTime.Today)
                .Count();

            // R�cup�ration des livraisons du jour
            var livraisonsDuJour = _context.Livraisons
                .Where(l => l.DateLivraison.Date == System.DateTime.Today)
                .Count();

            // R�cup�ration des paiements du jour
            var paiementsDuJour = _context.Paiements
                .Where(p => p.DatePaiement.Date == System.DateTime.Today)
                .Count();

            // R�cup�ration des commandes mises en attente
            var commandesEnAttente = _context.Commandes
                .Where(c => c.EstEnAttente)
                .Count();

            // Cr�er un objet contenant toutes les statistiques
            var statistiques = new StatistiquesViewModel
            {
                CommandesDuJour = commandesDuJour,
                LivraisonsDuJour = livraisonsDuJour,
                PaiementsDuJour = paiementsDuJour,
                CommandesEnAttente = commandesEnAttente
            };

            // Retourner la vue avec les statistiques
            return View(statistiques);
        }
    }
}
