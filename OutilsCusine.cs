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
        private string nom = "";
        private Image img_outi = new Image();
        private int x = 0;
        private int y = 0;
        private int width = 0;
        private int height = 0;
        private int niveaux = 0;
        private int vitesse_utilisation = 0;
        
       

        public OutilsCusine(string nom, int x, int y, int width, int height, int niveaux , int vitesse_utilisation)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
            this.niveaux = niveaux;
            this.vitesse_utilisation = vitesse_utilisation;
            Set_image();
        }
        public void afficher_outi(Canvas grille)
        {
            this.Img_outi.Name = this.Nom;
            grille.Children.Add(this.Img_outi);
            Canvas.SetLeft(this.Img_outi, this.X);
            Canvas.SetTop(this.Img_outi, this.Y);
            this.Img_outi.Height = this.Height;
            this.Img_outi.Width = this.Width;
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

        public Image Img_outi
        {
            get
            {
                return this.img_outi;
            }

            set
            {
                this.img_outi = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
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

        public int Niveaux
        {
            get
            {
                return this.niveaux;
            }

            set
            {
                this.niveaux = value;
            }
        }

        public int Vitesse_utilisation
        {
            get
            {
                return this.vitesse_utilisation;
            }

            set
            {
                this.vitesse_utilisation = value;
            }
        }

        private void Set_image()
        {
            this.Img_outi.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"Images/Outils/{this.Nom}.png", UriKind.Relative));
        }
    }
}
