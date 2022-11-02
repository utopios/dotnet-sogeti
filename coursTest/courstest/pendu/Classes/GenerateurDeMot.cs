using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Interfaces;

namespace TP03.Classes
{
    public class GenerateurDeMot : IGenerateur
    {
        private static string[] _motDisponibles = new string[] { "Amazon", "eBay", "Fnac", "CDiscount", "LeBonCoin", "AliExpress", "Micromania", "RueDuCommerce", "Darty", "Alibaba", "Wish", "Leclerc", "Carrefour", "Auchan", "Aldi", "Lidl", "EasyCash" };

       

        public string Generer()
        {
            int nbAleatoire = new Random().Next(_motDisponibles.Length);
            return _motDisponibles[nbAleatoire].ToUpper();
        }
    }
}
