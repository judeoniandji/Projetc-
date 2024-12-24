using gestionCommande.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestioncommande.Controllers
{
    public class ComptableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComptableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher les commandes à livrer ou payées
        public async Task<IActionResult> Index()
        {
            var commandes = await _context.Commandes
                .Where(c => c.Statut == "Livrée" || c.Statut == "Payée")
                .ToListAsync();
            return View(commandes);
        }

        // Créer une facture pour une commande
        public IActionResult CreerFacture(int commandeId)
        {
            var commande = _context.Commandes.FirstOrDefault(c => c.Id == commandeId);
            if (commande != null)
            {
                var facture = new Facture
                {
                    CommandeId = commande.Id,
                    Montant = commande.Montant,
                    DateFacture = DateTime.Now
                };
                _context.Add(facture);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // Enregistrer un paiement
        public async Task<IActionResult> EnregistrerPaiement(int commandeId, string typePaiement, decimal montant, string reference)
        {
            var commande = await _context.Commandes.FindAsync(commandeId);
            if (commande != null)
            {
                var paiement = new Paiement
                {
                    CommandeId = commande.Id,
                    TypePaiement = typePaiement,
                    Montant = montant,
                    Reference = reference
                };
                _context.Add(paiement);
                await _context.SaveChangesAsync();
                // Mettre à jour le solde du client
                var client = await _context.Clients.FindAsync(commande.ClientId);
                client.SoldeCompte -= montant;
                _context.Update(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // Afficher l'historique des paiements
        public async Task<IActionResult> HistoriquePaiements()
        {
            var paiements = await _context.Paiements.Include(p => p.Commande).ToListAsync();
            return View(paiements);
        }
    }
}
