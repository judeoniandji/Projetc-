using gestioncommande.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace gestioncommande.Controllers
{
    public class PaiementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaiementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var paiements = _context.Paiements.ToList();
            return View(paiements);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paiement);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }
    }
}
