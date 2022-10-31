using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03.Classes
{
    internal class IHM
    {
        private LePendu jeu;

        public void Demarrer()
        {
            GenererPendu();

            do
            {
                Console.WriteLine($"Le mot à trouver : {jeu.Masque}");
                Console.WriteLine($"Il vous reste {jeu.NbEssai} essais");
                Console.Write("Veuilliez saisir une lettre : ");
                char lettresaisie = Console.ReadLine().ToUpper()[0];
                jeu.TestChar(lettresaisie);

            } while (!jeu.TestWin() && jeu.NbEssai > 0);

            Console.WriteLine("");

            if (jeu.NbEssai > 0)
            {
                Console.WriteLine($"Félicitation, il vous restait encore {jeu.NbEssai} essais !");
            }
            else
            {
                Console.WriteLine($"Pas de chance... Le mot à trouver était {jeu.MotATrouver}...");
            }

            
        }

        private void GenererPendu()
        {
            Console.WriteLine("=== Paramètres de partie ===\n");
            Console.Write("Voulez vous un nombre d'essais spécifique (10 par défaut) ? Y/n");
            char choixParams = Console.ReadLine().ToLower()[0];
            if (choixParams == 'y')
            {
                Console.Write("Combien voulez-vous d'essais ?");
                int nombreEssais = int.Parse(Console.ReadLine());
                jeu = new LePendu(nombreEssais);
            }
            else
            {
                jeu = new LePendu();
            }
            
            Console.WriteLine($"Jeu du pendu généré ! Nombre d'essais : {jeu.NbEssai}");
        }
    }
}
