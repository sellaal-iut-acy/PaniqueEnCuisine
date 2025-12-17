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
            Nouriture fromage = new Nouriture("fromage", "cru"); 
            Nouriture fromage_cuit = new Nouriture("fromage_cuit", "cuit");
            Nouriture steak = new Nouriture("steak", "cru");
            Nouriture steak_cuit = new Nouriture("steak_cuit", "cuit");
            Nouriture pate = new Nouriture("pate", "ingrediant");
            Nouriture pain = new Nouriture("pain", "ingrediant");
            Nouriture pizza = new Nouriture("pizza", "cru"); //a fabriquer
            Nouriture saucisse = new Nouriture("saucisse", "cru");
            Nouriture saucisse_cuit = new Nouriture("saucisse_cuit", "cuit");
            Nouriture patate = new Nouriture("patate", "cru");
            Nouriture patate_cuit = new Nouriture("patate_cuit", "cuit");


            // création des plat 
            Nouriture pizza_cuit = new Nouriture("pizza_cuit", "plat");
            Nouriture burgerTomate = new Nouriture("burgerTomate", "plat");
            Nouriture burgerFromage = new Nouriture("burgerFromage", "plat");
            Nouriture hotDog = new Nouriture("hotDog", "plat");
            Nouriture frite = new Nouriture("frite", "plat");
            Nouriture fondue = new Nouriture("fondue", "plat");



            // création des Recettes 
            CreeRecette(pizza_cuit, pate,tomate, fromage_cuit);
            CreeRecette(burgerFromage,pain, steak_cuit, fromage_cuit);
            CreeRecette(burgerTomate,pain, steak_cuit, tomate);
            CreeRecette(hotDog,pain, saucisse_cuit);
            CreeRecette(frite, patate_cuit);
            CreeRecette(fondue,pain, fromage_cuit);

        }

        private void AjoutRecette(Recette newRecette)
        {
            ListeRecetes.Add(newRecette);
        }


        private void CreeRecette(Nouriture plat, Nouriture ingrédiant1)
        {

            List<Nouriture> ingrediant = new List<Nouriture>();
            ingrediant.Add(ingrédiant1);
            Recette RecettePizza = new Recette(ingrediant, plat);
            AjoutRecette(RecettePizza);
        }
        private void CreeRecette(Nouriture plat, Nouriture ingrédiant1, Nouriture ingrédiant2)
        {
            
            List<Nouriture> ingrediant = new List<Nouriture>();
            ingrediant.Add(ingrédiant1);
            ingrediant.Add(ingrédiant2);
            Recette RecettePizza = new Recette(ingrediant, plat);
            AjoutRecette(RecettePizza);
        }
        private void CreeRecette(Nouriture plat, Nouriture ingrédiant1, Nouriture ingrédiant2, Nouriture ingrédiant3)
        {
            List<Nouriture> ingrediant = new List<Nouriture>();
            ingrediant.Add(ingrédiant1);
            ingrediant.Add(ingrédiant2);
            ingrediant.Add(ingrédiant3);
            Recette RecettePizza = new Recette(ingrediant, plat);
            AjoutRecette(RecettePizza);
        }
        public Recette GetRecetteAleatoire()
        {
            if (_ListeRecetes.Count == 0)
                return null;

            Random rnd = new Random();
            int index = rnd.Next(_ListeRecetes.Count);
            return _ListeRecetes[index];
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
