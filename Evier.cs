using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class Evier : OutilsCusine
    {
        private int capacite_lavage = 1;
        private List<Nouriture> Nouritures_a_laver = new List<Nouriture>();
        public Evier(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation) : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Evier";
        }
        public int Capacite_lavage
        {
            get
            {
                return this.capacite_lavage;
            }
            set
            {
                this.capacite_lavage = value;
            }
        }

        public List<Nouriture> Nouritures_a_laver1
        {
            get
            {
                return this.Nouritures_a_laver;
            }

            set
            {
                this.Nouritures_a_laver = value;
            }
        }

        public void ajouter_nouriture_a_laver(Nouriture nouriture)
        {
            if (Nouritures_a_laver1.Count < Capacite_lavage)
            {
                Nouritures_a_laver1.Add(nouriture);
                this.Niveaux += 1;
            }
        }
        public void retirer_nouriture_laver(Nouriture nouriture)
        {
            Nouritures_a_laver1.Remove(nouriture);
            this.Niveaux -= 1;
        }
    }
}
