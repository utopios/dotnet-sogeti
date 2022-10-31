using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Interfaces;

namespace TP03.Classes
{
    public class LePendu
    {
        private int _nbEssai;
        private string _masque;        
        private string _motATrouver;
        private IGenerateur _generateur;
        public int NbEssai { get => _nbEssai; set => _nbEssai = value; }
        public string Masque { get => _masque; set => _masque = value; }
        public string MotATrouver { get => _motATrouver; set => _motATrouver = value; }

        public LePendu(int nbEssais, IGenerateur generateur)
        {
            _nbEssai = nbEssais;
            _generateur = generateur;
            _motATrouver = _generateur.Generer();
            GenererMasque();
        }

        public LePendu(int nbEssais)
        {
            _nbEssai = nbEssais;
            //_motATrouver = GenerateurDeMot.Generer();
            GenererMasque();
        }

        public LePendu()
        {
            _nbEssai = 10;
            //_motATrouver = GenerateurDeMot.Generer();
            GenererMasque();
        }

        public void TestChar(char c)
        {
            string tmpMasque = string.Empty;
            bool flag = false;

            for (int i = 0; i < _motATrouver.Length; i++)
            {
                if (_motATrouver[i] == c)
                {
                    tmpMasque += c;
                    flag = true;
                }
                else
                {
                    tmpMasque += _masque[i];
                }
            }

            _masque = tmpMasque;
            if (!flag) NbEssai--;
        }

        public bool TestWin()
        {
            if (NbEssai > 0 && _masque == _motATrouver)
            {
                return true;
            }

            else return false;
        }

        public void GenererMasque()
        {
            _masque = String.Empty;

            foreach (char c in _motATrouver)
            {
                _masque += "*";
            }
        }
    }
}
