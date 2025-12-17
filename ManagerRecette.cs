using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    internal class ManagerRecette
    {
        private List<Recette> _ListeRecetes = new List<Recette>();

        public ManagerRecette()
        {
            // création des ingrédiant 
            Nouriture tomate = new Nouriture("tomate", "ingrediant");
            Nouriture fromage = new Nouriture("fromage", "ingrediant");

            // création des plat 
            Nouriture pizza = new Nouriture("pizza", "plat");

            // création des Recettes 
            CreeRecette(pizza,tomate,fromage);

        }

        private void AjoutRecette(Recette newRecette)
        {
            ListeRecetes.Add(newRecette);
        }
        private void CreeRecette(Nouriture plat, Nouriture ingrédiant, Nouriture ingrédiant1)
        {
            
            List<Nouriture> ingrediant = new List<Nouriture>();
            ingrediant.Add(ingrédiant);
            ingrediant.Add(ingrédiant1);
            Recette RecettePizza = new Recette(ingrediant, plat);
            AjoutRecette(RecettePizza);
        }

        internal List<Recette> ListeRecetes
        {
            get
            {
                return this._ListeRecetes;
            }

            set
            {
                this._ListeRecetes = value;
            }
        }
    }
}
