using System;
using System.Collections.Generic;

namespace gestioncommande.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }
        public DateTime DatePaiement { get; set; }
        public string TypePaiement { get; set; }
        public string Reference { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
