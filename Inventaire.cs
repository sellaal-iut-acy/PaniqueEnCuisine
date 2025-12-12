using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    public  class Inventaire
    {
        private List<Nouriture> _liste_nourriture;
        private int current_page = 0;

        public Inventaire(List<Nouriture> liste_nourriture)
        {
            this.Liste_nourriture = liste_nourriture;
        
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
    }
}
