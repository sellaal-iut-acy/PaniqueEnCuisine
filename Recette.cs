using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class Recette
    {
        private List<Nouriture> NouritureList = new List<Nouriture>();
        private Nouriture nouriture;

        public Recette(List<Nouriture> nouritureList, Nouriture nouriture)
        {
            this.NouritureList = nouritureList;
            this.nouriture = nouriture;
        }

        public Nouriture Nouriture
        {
            get
            {
                return this.nouriture;
            }

            set
            {
                this.nouriture = value;
            }
        }

        public bool Rectte_fait(List<Nouriture> Ingredient)
        {
            foreach (Nouriture Nourriture in this.NouritureList) 
            {
                foreach (Nouriture nouriture in Ingredient)
                {
                    if (Nourriture.Nom == nouriture.Nom)
                    {
                        
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
