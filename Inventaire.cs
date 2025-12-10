using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    class Inventaire
    {
        private List<Nouriture> _liste_nourriture;

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
    }
}
