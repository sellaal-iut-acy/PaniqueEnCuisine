using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class Recette
    {
        private List<Nouriture> _NourituresList = new List<Nouriture>();
        private Nouriture _Nouriture;

        public Recette(List<Nouriture> nouritureList, Nouriture nouriture)
        {
            this.NouritureList = nouritureList;
            this.Nouriture = nouriture;
        }

        public Nouriture Nouriture
        {
            get
            {
                return this._Nouriture;
            }

            set
            {
                this._Nouriture = value;
            }
        }

        public List<Nouriture> NouritureList
        {
            get
            {
                return this._NourituresList;
            }

            set
            {
                this._NourituresList = value;
            }
        }

        public bool Rectte_Fait(List<Nouriture> Ingredient)
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
