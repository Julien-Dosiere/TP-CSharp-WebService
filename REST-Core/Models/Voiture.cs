using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Core.Models
{
    public class Voiture
    {

        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public DateTime Annee { get; set; }
        public string couleur { get; set; }
        public double Puissance { get; set; }
        public string NumeroSerie { get; set; }
    }
}
