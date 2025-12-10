using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    internal class Entiter
    /*  
     * Classe Entiter
     * nom : string -> nom de l'entité
     * X : int -> position X de l'entité
     * Y : int -> position Y de l'entité
     */
    {
        /* Attributs */
        private string nom;
        private int x;
        private int y;
        private int vitesse;
        private int vitesseCourse;

        /* Constructeur */
        public Entiter(string nom, int x, int y,int vitesse)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            this.Vitesse = vitesse;
            this.VitesseCourse = vitesse * 2;
        }

        public string Nom 
        { 
            set { 
                this.nom = value;
            }
            get {
                return this.nom; 
            }  
        }
        public int Vitesse
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La vitesse ne peut pas être négative.");
                }
                this.vitesse = value;
            }
            get
            {
                return this.vitesse;
            }
        }
      
        public int X
        {
            set
            {

                this.x= value;
            }
            get
            {
                return this.x;
            }
        }
        public int Y
        {
            set
            {
                this.y = value;
            }
            get
            {
                return this.y;
            }
        }

        public int VitesseCourse
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La vitesse de course ne peut pas être négative.");
                }
                this.vitesseCourse = value;
            }
            get
            {
                return this.vitesseCourse;
            }
        }

    }
}
