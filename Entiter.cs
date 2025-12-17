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
     * _Nom : string -> _Nom de l'entité
     * X : int -> position X de l'entité
     * Y : int -> position Y de l'entité
     */
    {
        /* Attributs */
        private string _Nom ="";
        private double _X=0 ;
        private double _Y  =0 ;
        private int _vitesse=0 ;
        private int _VitesesCourse = 0 ;
        private string _Direction;
        private Image _ImageActuel = new Image();
        private int _Hauteur = 0 ;
        private int _Largeur =0;
        BitmapImage[,] _ImagesPerso = new BitmapImage[4,4];




        /* Constructeur */
        public EntiterMobile(double x, double y,int vitesse, string nom, int Height, int Widht)
        {
            this.X = x;
            this.Nom = nom;
            this.Y = y;
            this.Vitesse = vitesse;
            this.VitesseCourse = vitesse * 2;
            this.Charger_Images();
            this._Hauteur = Height ;
            this._Largeur = Widht ;
            Set_Image();
        }
        public void Set_Image()
        {
            Console.WriteLine($"Chemin de l'image par défaut définie pour l'entité mobile.");
            this.ImageActuel.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("player_Aucun_1.jpg", UriKind.Relative));
            this.ImageActuel.Height = this._Hauteur;
            this.ImageActuel.Width = this._Largeur;
        }

        private void Charger_Images()
        {
            _ImagesPerso = new BitmapImage[5, 5];

            // ===== HAUT =====
            _ImagesPerso[0, 0] = ChargerImages("Images/Entiter/image_fleche_haut_bleu.png");
            _ImagesPerso[0, 1] = ChargerImages("Images/Entiter/image_fleche_haut_rouge.png");
            _ImagesPerso[0, 2] = ChargerImages("Images/Entiter/image_fleche_haut_vert.png");
            _ImagesPerso[0, 3] = ChargerImages("Images/Entiter/image_fleche_haut_violet.png");
            _ImagesPerso[0, 4] = ChargerImages("Images/Entiter/image_fleche_haut_orange.png");

            // ===== DROITE =====
            _ImagesPerso[1, 0] = ChargerImages("Images/Entiter/image_fleche_droite_bleu.png");
            _ImagesPerso[1, 1] = ChargerImages("Images/Entiter/image_fleche_droite_rouge.png");
            _ImagesPerso[1, 2] = ChargerImages("Images/Entiter/image_fleche_droite_vert.png");
            _ImagesPerso[1, 3] = ChargerImages("Images/Entiter/image_fleche_droite_violet.png");
            _ImagesPerso[1, 4] = ChargerImages("Images/Entiter/image_fleche_droite_orange.png");

            // ===== BAS =====
            _ImagesPerso[2, 0] = ChargerImages("Images/Entiter/image_fleche_bas_bleu.png");
            _ImagesPerso[2, 1] = ChargerImages("Images/Entiter/image_fleche_bas_rouge.png");
            _ImagesPerso[2, 2] = ChargerImages("Images/Entiter/image_fleche_bas_vert.png");
            _ImagesPerso[2, 3] = ChargerImages("Images/Entiter/image_fleche_bas_violet.png");
            _ImagesPerso[2, 4] = ChargerImages("Images/Entiter/image_fleche_bas_orange.png");

            // ===== GAUCHE =====
            _ImagesPerso[3, 0] = ChargerImages("Images/Entiter/image_fleche_gauche_bleu.png");
            _ImagesPerso[3, 1] = ChargerImages("Images/Entiter/image_fleche_gauche_rouge.png");
            _ImagesPerso[3, 2] = ChargerImages("Images/Entiter/image_fleche_gauche_vert.png");
            _ImagesPerso[3, 3] = ChargerImages("Images/Entiter/image_fleche_gauche_violet.png");
            _ImagesPerso[3, 4] = ChargerImages("Images/Entiter/image_fleche_gauche_orange.png");

            // === IDLE (RONDS) ===
            _ImagesPerso[4, 0] = ChargerImages("Images/Entiter/image_rond_bleu.jpg");
            _ImagesPerso[4, 1] = ChargerImages("Images/Entiter/image_rond_rouge.jpg");
            _ImagesPerso[4, 2] = ChargerImages("Images/Entiter/image_rond_vert.jpg");
            _ImagesPerso[4, 3] = ChargerImages("Images/Entiter/image_rond_violet.jpg");
            _ImagesPerso[4, 4] = ChargerImages("Images/Entiter/image_rond_orange.jpg");
        }

        public BitmapImage ChargerImages(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }


        public int Vitesse
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La _vitesse ne peut pas être négative.");
                }
                this._vitesse = value;
            }
            get
            {
                return this._vitesse;
            }
        }
      
        public double X
        {
            set
            {

                this._X= value;
            }
            get
            {
                return this._X;
            }
        }
        public double Y
        {
            set
            {
                this._Y = value;
            }
            get
            {
                return this._Y;
            }
        }

        public int VitesseCourse
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La _vitesse de course ne peut pas être négative.");
                }
                this._VitesesCourse = value;
            }
            get
            {
                return this._VitesesCourse;
            }
        }

        public string Nom
        {
            get
            {
                return this._Nom;
            }

            set
            {
                this._Nom = value;
            }
        }


        public int VitesesCourse
        {
            get
            {
                return this._VitesesCourse;
            }

            set
            {
                this._VitesesCourse = value;
            }
        }


        public Image ImageActuel
        {
            get
            {
                return this._ImageActuel;
            }

            set
            {
                this._ImageActuel = value;
            }
        }

        public int Hauteur
        {
            get
            {
                return this._Hauteur;
            }

            set
            {
                this._Hauteur = value;
            }
        }

        public int Largeur
        {
            get
            {
                return this._Largeur;
            }

            set
            {
                this._Largeur = value;
            }
        }

        public BitmapImage[,] ImagesPerso
        {
            get
            {
                return this._ImagesPerso;
            }

            set
            {
                this._ImagesPerso = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is EntiterMobile entiter &&
                   this.Nom == entiter.Nom &&
                   this.X == entiter.X &&
                   this.Y == entiter.Y &&
                   this.Vitesse == entiter.Vitesse &&
                   this.VitesesCourse == entiter.VitesesCourse;
        }

        public override string? ToString()
        {
            return $"{this.Y.ToString()} ,{this._X.ToString()}";
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
