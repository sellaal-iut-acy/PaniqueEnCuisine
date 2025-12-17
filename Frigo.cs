using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class Frigo : OutilsCusine
    {
        private List<Nouriture> _Ingrediants = new List<Nouriture>();

        public Frigo(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation) : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Frigo";
        }

        public List<Nouriture> Ingredients
        {
            get
            {
                return this._Ingrediants;
            }
            set
            {
                this._Ingrediants = value;
            }
        }
        public void Ajouter_Nouriture(Nouriture nouriture)
        { 
            Ingredients.Add(nouriture);
        }
        public void Retirer_Nouriture(Nouriture nouriture)
        {
            Ingredients.Remove(nouriture);
        }
    }
}
