using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    internal class OutilsCusine
    {
        private string _Nom = "";
        private Image _ImageOutil = new Image();
        private int _X = 0;
        private int _Y = 0;
        private int _Width = 0;
        private int _Height = 0;
        private int _Niveaux = 0;
        private int _VitesseUtilisation = 0;
        
        public OutilsCusine(string nom, int x, int y, int width, int height, int niveaux , int vitesse_utilisation)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Niveaux = niveaux;
            this.VitesseUtilisation = vitesse_utilisation;
            Set_Image();
        }
        public void AfficherOutil(Canvas grille)
        {
            this.Img_outi.Name = this.Nom;
            Canvas.SetLeft(this.Img_outi, this.X);
            Canvas.SetTop(this.Img_outi, this.Y);
            this.Img_outi.Height = this.Height;
            this.Img_outi.Width = this.Width;
            grille.Children.Add(this.Img_outi);
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

        public Image Img_outi
        {
            get
            {
                return this._ImageOutil;
            }

            set
            {
                this._ImageOutil = value;
            }
        }

        public int X
        {
            get
            {
                return this._X;
            }

            set
            {
                this._X = value;
            }
        }

        public int Y
        {
            get
            {
                return this._Y;
            }

            set
            {
                this._Y = value;
            }
        }

        public int Width
        {
            get
            {
                return this._Width;
            }

            set
            {
                this._Width = value;
            }
        }

        public int Height
        {
            get
            {
                return this._Height;
            }

            set
            {
                this._Height = value;
            }
        }

        public int Niveaux
        {
            get
            {
                return this._Niveaux;
            }

            set
            {
                this._Niveaux = value;
            }
        }

        public int Vitesse_utilisation
        {
            get
            {
                return this._VitesseUtilisation;
            }

            set
            {
                this._VitesseUtilisation = value;
            }
        }

        public int VitesseUtilisation
        {
            get
            {
                return this._VitesseUtilisation;
            }

            set
            {
                this._VitesseUtilisation = value;
            }
        }

        private void Set_Image()
        {
            this.Img_outi.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"Images/Outils/{this.Nom}.png", UriKind.Relative));
        }
    }
}
