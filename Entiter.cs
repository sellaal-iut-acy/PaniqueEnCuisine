using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    internal class EntiterMobile
    /*  
     * Classe Entiter
     * _nom : string -> _nom de l'entité
     * X : int -> position X de l'entité
     * Y : int -> position Y de l'entité
     */
    {
        /* Attributs */
        public string nom;
        private int x;
        private int y;
        private int vitesse;
        private int vitesseCourse;
        private Image[,] images;

       
        /* Constructeur */
        public EntiterMobile(string nom, int x, int y,int vitesse)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            this.Vitesse = vitesse;
            this.VitesseCourse = vitesse * 2;
            this.Images = Charger_images(nom);
        }

        private static Image[,] Charger_images(string non)
            {
                Image[,] imgs = new Image[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        imgs[i, j] = new Image();
                        imgs[i, j].Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/Images/{non}_{i}_{j}.png", UriKind.Relative));
                    }
                }
                return imgs;
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

        public Image[,] Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }


        public override bool Equals(object? obj)
        {
            return obj is Entiter entiter &&
                   this.nom == entiter.nom &&
                   this.x == entiter.x &&
                   this.y == entiter.y &&
                   this.vitesse == entiter.vitesse &&
                   this.vitesseCourse == entiter.vitesseCourse &&
                   this.Nom == entiter.Nom &&
                   this.Vitesse == entiter.Vitesse &&
                   this.X == entiter.X &&
                   this.Y == entiter.Y &&
                   this.VitesseCourse == entiter.VitesseCourse;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.nom);
            hash.Add(this.x);
            hash.Add(this.y);
            hash.Add(this.vitesse);
            hash.Add(this.vitesseCourse);
            hash.Add(this.Nom);
            hash.Add(this.Vitesse);
            hash.Add(this.X);
            hash.Add(this.Y);
            hash.Add(this.VitesseCourse);
            return hash.ToHashCode();
        }

        public static bool operator ==(Entiter? left, Entiter? right)
        {
            return EqualityComparer<Entiter>.Default.Equals(left, right);
        }

        public static bool operator !=(Entiter? left, Entiter? right)
        {
            return !(left == right);
        }
    }
}
