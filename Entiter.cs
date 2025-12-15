using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
        private string nom ="";
        private double x=0 ;
        private double y  =0 ;
        private int vitesse=0 ;
        private int vitesseCourse = 0 ;
        private string direction;
        public Image current_Image = new Image();
        private int height = 0 ;
        private int width =0;
        BitmapImage[,] imagesPerso = new BitmapImage[4,4];




        /* Constructeur */
        public EntiterMobile(double x, double y,int vitesse, string nom, int Height, int Widht)
        {
            this.X = x;
            this.Nom = nom;
            this.Y = y;
            this.Vitesse = vitesse;
            this.VitesseCourse = vitesse * 2;
            this.direction = "Aucun";
            this.Charger_images();
            this.height = Height ;
            this.width = Widht ;
            Set_image();
        }
        public void Set_image()
        {
            Console.WriteLine($"Chemin de l'image par défaut définie pour l'entité mobile.");
            this.current_Image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("player_Aucun_1.jpg", UriKind.Relative));
            this.current_Image.Height = this.height;
            this.current_Image.Width = this.width;
        }

        private void Charger_images()
        {
            imagesPerso = new BitmapImage[5, 5];

            // ===== HAUT =====
            imagesPerso[0, 0] = LoadImage("Images/Entiter/image_fleche_haut_bleu.png");
            imagesPerso[0, 1] = LoadImage("Images/Entiter/image_fleche_haut_rouge.png");
            imagesPerso[0, 2] = LoadImage("Images/Entiter/image_fleche_haut_vert.png");
            imagesPerso[0, 3] = LoadImage("Images/Entiter/image_fleche_haut_violet.png");
            imagesPerso[0, 4] = LoadImage("Images/Entiter/image_fleche_haut_orange.png");

            // ===== DROITE =====
            imagesPerso[1, 0] = LoadImage("Images/Entiter/image_fleche_droite_bleu.png");
            imagesPerso[1, 1] = LoadImage("Images/Entiter/image_fleche_droite_rouge.png");
            imagesPerso[1, 2] = LoadImage("Images/Entiter/image_fleche_droite_vert.png");
            imagesPerso[1, 3] = LoadImage("Images/Entiter/image_fleche_droite_violet.png");
            imagesPerso[1, 4] = LoadImage("Images/Entiter/image_fleche_droite_orange.png");

            // ===== BAS =====
            imagesPerso[2, 0] = LoadImage("Images/Entiter/image_fleche_bas_bleu.png");
            imagesPerso[2, 1] = LoadImage("Images/Entiter/image_fleche_bas_rouge.png");
            imagesPerso[2, 2] = LoadImage("Images/Entiter/image_fleche_bas_vert.png");
            imagesPerso[2, 3] = LoadImage("Images/Entiter/image_fleche_bas_violet.png");
            imagesPerso[2, 4] = LoadImage("Images/Entiter/image_fleche_bas_orange.png");

            // ===== GAUCHE =====
            imagesPerso[3, 0] = LoadImage("Images/Entiter/image_fleche_gauche_bleu.png");
            imagesPerso[3, 1] = LoadImage("Images/Entiter/image_fleche_gauche_rouge.png");
            imagesPerso[3, 2] = LoadImage("Images/Entiter/image_fleche_gauche_vert.png");
            imagesPerso[3, 3] = LoadImage("Images/Entiter/image_fleche_gauche_violet.png");
            imagesPerso[3, 4] = LoadImage("Images/Entiter/image_fleche_gauche_orange.png");

            // === IDLE (RONDS) ===
            imagesPerso[4, 0] = LoadImage("Images/Entiter/image_rond_bleu.jpg");
            imagesPerso[4, 1] = LoadImage("Images/Entiter/image_rond_rouge.jpg");
            imagesPerso[4, 2] = LoadImage("Images/Entiter/image_rond_vert.jpg");
            imagesPerso[4, 3] = LoadImage("Images/Entiter/image_rond_violet.jpg");
            imagesPerso[4, 4] = LoadImage("Images/Entiter/image_rond_orange.jpg");
        }

        private BitmapImage LoadImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
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
      
        public double X
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
        public double Y
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
                return this.current_Image;
            }

            set
            {
                this.current_Image = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is EntiterMobile entiter &&
                   this.Nom == entiter.Nom &&
                   this.x == entiter.x &&
                   this.y == entiter.y &&
                   this.vitesse == entiter.vitesse &&
                   this.vitesseCourse == entiter.vitesseCourse &&
                   this.Vitesse == entiter.Vitesse &&
                   this.X == entiter.X &&
                   this.Y == entiter.Y &&
                   this.VitesseCourse == entiter.VitesseCourse;
        }

        public override string? ToString()
        {
            return $"{this.Y.ToString()} ,{this.x.ToString()}";
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
