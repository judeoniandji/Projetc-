
using System;
using System.Collections.Generic;
namespace gestioncommande.Models
{
    public class StatistiquesViewModel
    {
        public int CommandesDuJour { get; set; }
        public int LivraisonsDuJour { get; set; }
        public int PaiementsDuJour { get; set; }
        public int CommandesEnAttente { get; set; }
    }
}
