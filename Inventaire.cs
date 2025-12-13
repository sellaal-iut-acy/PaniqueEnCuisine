using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    public  class Inventaire
    {
        private List<Nouriture> _liste_nourriture = new List<Nouriture>();
        private int current_page = 0;
        private bool ouvert = false;

        public Inventaire(List<Nouriture> liste_nourriture,int current_page)
        {
            this.Liste_nourriture = liste_nourriture;
            this.Current_page = current_page;

        }

        public List<Nouriture> Liste_nourriture
        {
            get
            {
                return this._liste_nourriture;
            }

            set
            {
                this._liste_nourriture = value;
            }
        }

        public int Current_page
        {
            get
            {
                return this.current_page;
            }

            set
            {
                this.current_page = value;
            }
        }

        public bool Ouvert
        {
            get
            {
                return this.ouvert;
            }

            set
            {
                this.ouvert = value;
            }
        }
    }
}
