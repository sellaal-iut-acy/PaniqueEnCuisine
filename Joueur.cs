using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace PaniqueEnCuisine
{
    public class Joueur : EntiterMobile
    {
        private int _score = 0;
        private Inventaire inventaire = new Inventaire(new List<Nouriture>(),1);
        private int _main = 0;
        public BitmapImage[,] imagesPerso = new BitmapImage[4,4];
        public int CurrentSkin { get; set; } = 1;


        public int Direction { get; set; } = 4; // 0=Haut,1=Droite,2=Bas,3=Gauche,4=Idle
        public int Frame { get; set; } = 0;     // 0..4

        public Joueur(string nom, double x,double y, int vitesse, int score , int Height, int Widht) : base(x, y, vitesse,nom,Height,Widht)
        {
            this._score = score;
            Charger_images();
        }
        public BitmapImage GetImageJoueur()
        {
            return imagesPerso[Direction, Frame];
        }
        public void Charger_images()
        {
            imagesPerso = new BitmapImage[5, 5];

            string[] directions = { "haut", "droite", "bas", "gauche", "idle" };

            for (int dir = 0; dir < 5; dir++)
            {
                for (int frame = 0; frame < 5; frame++)
                {
                    string path =
                        $"Images/Entiter/image_{directions[dir]}{frame}_skin{CurrentSkin}.png";

                    imagesPerso[dir, frame] = LoadImage(path);
                }
            }
        }

        public void ajouter_objet_inventaire(Nouriture nouriture)
        {
            this.inventaire.Liste_nourriture.Add(nouriture);
        }
        public int Score
        {
            get
            {
                return this._score;
            }

            set
            {
                this._score = value;
            }
        }
        public int Main
        {
            get
            {
                return this._main;
            }

            set
            {
                this._main = value;
            }
        }

        public Inventaire Inventaire
        {
            get
            {
                return this.inventaire;
            }

            set
            {
                this.inventaire = value;
            }
        }
        public void UP()
        {
            this.Y -= this.Vitesse;
        }
        public void Down()
        {
            this.Y += this.Vitesse;
        }
        public void Left()
        {
            this.X -= this.Vitesse;
        }
        public void Right()
        {
            this.X += this.Vitesse;
        }
        public void UP_Right()
        {
            this.X += this.Vitesse / 2;
            this.Y -= this.Vitesse / 2;
        }
        public void UP_Left()
        {
            this.X -= this.Vitesse / 2;
            this.Y -= this.Vitesse / 2;
        }
        public void Down_Left()
        {
            this.X -= this.Vitesse / 2;
            this.Y += this.Vitesse / 2;
        }
        public void Down_Rigth()
        {
            this.X += this.Vitesse / 2;
            this.Y += this.Vitesse / 2;
        }
    }
}
