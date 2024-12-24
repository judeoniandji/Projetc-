using gestionCommande.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestionscommande.Controllers
{
    public class CommandeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des commandes
        public async Task<IActionResult> Index()
        {
            var commandes = await _context.Commandes.Include(c => c.Client).ToListAsync();
            return View(commandes);
        }

        // Afficher le formulaire d'ajout d'une commande
        public IActionResult Create()
        {
            ViewBag.Clients = _context.Clients.ToList();
            return View();
        }

        // Enregistrer une nouvelle commande
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Montant,ClientId")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        // Afficher les détails d'une commande
        public async Task<IActionResult> Details(int id)
        {
            var commande = await _context.Commandes
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }
    }
}
