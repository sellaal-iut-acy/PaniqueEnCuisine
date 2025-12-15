using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class Foure : OutilsCusine
    {
        private int nb_plats_cuits_possible = 1;
        private List<Nouriture> plats_a_cuire = new List<Nouriture>();

        public Foure(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation) : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Foure";
        }

        public void niveaux_suivant()
        {
              this.Niveaux += 1;
        }
        public void Ajouter_Plat_a_cuire(Nouriture nouriture)
        {
            if (Plats_a_cuire.Count < Nb_plats_cuits_possible)
            {
                Plats_a_cuire.Add(nouriture);
                this.Niveaux += 1;
            }   
        }
        public void Retirer_Plat_a_cuire(Nouriture nouriture)
        {
            Plats_a_cuire.Remove(nouriture);
            this.Niveaux -= 1;
        }
        public List<Nouriture> Plats_a_cuire
        {
            get
            {
                return this.plats_a_cuire;
            }

            set
            {
                this.plats_a_cuire = value;
            }
        }

        public int Nb_plats_cuits_possible
        {
            get
            {
                return this.nb_plats_cuits_possible;
            }

            set
            {
                this.nb_plats_cuits_possible = value;
            }
        }
    }
}
