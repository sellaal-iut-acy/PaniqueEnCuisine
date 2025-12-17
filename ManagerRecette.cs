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
            Nouriture fromageCuit = new Nouriture("fromage_cuit", "cuit");
            Nouriture steak = new Nouriture("steak", "cru");
            Nouriture steakCuit = new Nouriture("steak_cuit", "cuit");
            Nouriture pate = new Nouriture("pate", "ingrediant");
            Nouriture pain = new Nouriture("pain", "ingrediant");
            Nouriture pizza = new Nouriture("pizza", "cru"); //a fabriquer
            Nouriture saucisse = new Nouriture("saucisse", "cru");
            Nouriture saucisseCuit = new Nouriture("saucisse_cuit", "cuit");
            Nouriture patate = new Nouriture("patate", "cru");
            Nouriture patateCuit = new Nouriture("patate_cuit", "cuit");


            // création des plat 
            Nouriture pizzaCuite = new Nouriture("pizzaCuite", "plat");
            Nouriture burgerTomate = new Nouriture("burgerTomate", "plat");
            Nouriture burgerFromage = new Nouriture("burgerFromage", "plat");
            Nouriture hotDog = new Nouriture("hotDog", "plat");
            Nouriture frite = new Nouriture("frite", "plat");
            Nouriture fondue = new Nouriture("fondue", "plat");



            // création des Recettes 
            CreeRecette(pizza,tomate,fromage);
            CreeRecette(burgerFromage,pain,steak,fromage);
            CreeRecette(burgerTomate,pain,steak,tomate);
            CreeRecette(hotDog,pain,saucisse);
            CreeRecette(frite,patate);
            CreeRecette(fondue,pain,fromageCuit);

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
