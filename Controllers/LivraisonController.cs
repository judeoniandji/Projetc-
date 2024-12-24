using gestioncommande.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestioncommande.Controllers
{
    public class LivraisonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivraisonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des livraisons
        public async Task<IActionResult> Index()
        {
            var livraisons = await _context.Livraisons.Include(l => l.Commande).ToListAsync();
            return View(livraisons);
        }

        // Planifier une livraison
        public IActionResult Planifier(int id)
        {
            ViewBag.Commande = _context.Commandes.FirstOrDefault(c => c.Id == id);
            ViewBag.Livreurs = _context.Livreurs.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Planifier(int commandeId, int livreurId, DateTime dateLivraison, string adresseLivraison)
        {
            var commande = await _context.Commandes.FindAsync(commandeId);
            var livreur = await _context.Livreurs.FindAsync(livreurId);

            if (commande != null && livreur != null)
            {
                var livraison = new Livraison
                {
                    CommandeId = commande.Id,
                    LivreurId = livreur.Id,
                    DateLivraison = dateLivraison,
                    AdresseLivraison = adresseLivraison
                };
                _context.Add(livraison);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
