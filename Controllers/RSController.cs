using gestioncommande.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestioncommande.Controllers
{
    public class RSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des produits
        public async Task<IActionResult> Index()
        {
            var produits = await _context.Produits.ToListAsync();
            return View(produits);
        }

        // Afficher le formulaire d'ajout d'un produit
        public IActionResult Create()
        {
            return View();
        }

        // Enregistrer un nouveau produit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle,QuantiteStock,Price,QuantiteSeuil,ImageUrl")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // Afficher les détails d'un produit
        public async Task<IActionResult> Details(int id)
        {
            var produit = await _context.Produits
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // Mettre à jour le stock d'un produit
        public IActionResult UpdateStock(int id)
        {
            var produit = _context.Produits.FirstOrDefault(p => p.Id == id);
            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(int id, int newQuantity)
        {
            var produit = await _context.Produits.FirstOrDefaultAsync(p => p.Id == id);
            if (produit != null)
            {
                produit.QuantiteStock += newQuantity;
                _context.Update(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
