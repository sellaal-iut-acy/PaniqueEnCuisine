using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    public class EntiterMobile
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
        private string direction;
        private Image crenent_Image;


        /* Constructeur */
        public EntiterMobile(string nom, int x, int y,int vitesse)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            this.Vitesse = vitesse;
            this.VitesseCourse = vitesse * 2;
            this .direction = "Aucun";
        }
        public void Charger_images()
        {
            this.crenent_Image = new Image();
            this.crenent_Image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/Images/Entiter/{this.nom}_down_1.png", UriKind.Relative));

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

        public Image Curenent_Image
        {
            get
            {
                return this.crenent_Image;
            }

            set
            {
                this.crenent_Image = value;
            }
        }

  

        public override bool Equals(object? obj)
        {
            return obj is EntiterMobile entiter &&
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
        public static bool operator ==(EntiterMobile? left, EntiterMobile? right)
        {
            return EqualityComparer<EntiterMobile>.Default.Equals(left, right);
        }

        public static bool operator !=(EntiterMobile? left, EntiterMobile? right)
        {
            return !(left == right);
        }
    }
}
