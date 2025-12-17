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
        private int _Score = 0;
        private Inventaire _Inventaire = new Inventaire(new List<Nouriture>(),1);
        private int _main = 0;
        public BitmapImage[,] _ImagesPerso = new BitmapImage[4,4];
        private int _IndexSkinActuel = 1;
        private int _Direction = 4; // 0=Haut,1=Droite,2=Bas,3=Gauche,4=Idle
        private int _IndexImage = 0;     // 0..4

        public Joueur(string nom, double x,double y, int vitesse, int score , int Height, int Widht) : base(x, y, vitesse,nom,Height,Widht)
        {
            this._Score = score;
            Charger_images();
        }
        public BitmapImage GetImageJoueur()
        {
            return _ImagesPerso[_Direction, _IndexImage];
        }
        public void Charger_images()
        {
            _ImagesPerso = new BitmapImage[5, 5];

            string[] directions = { "haut", "droite", "bas", "gauche", "idle" };

            for (int dir = 0; dir < 5; dir++)
            {
                for (int frame = 0; frame < 5; frame++)
                {
                    string path =
                        $"Images/Entiter/image_{directions[dir]}{frame}_skin{_IndexSkinActuel}.png";

                    _ImagesPerso[dir, frame] = ChargerImages(path);
                }
            }
        }

        public void ajouter_objet_inventaire(Nouriture nouriture)
        {
            this._Inventaire.Liste_nourriture.Add(nouriture);
        }
        public int Score
        {
            get
            {
                return this._Score;
            }

            set
            {
                this._Score = value;
            }
        }

        public Inventaire Inventaire
        {
            get
            {
                return this._Inventaire;
            }

            set
            {
                this._Inventaire = value;
            }
        }

        public int IndexSkinActuel
        {
            get
            {
                return this._IndexSkinActuel;
            }

            set
            {
                this._IndexSkinActuel = value;
            }
        }

        public int Direction
        {
            get
            {
                return this._Direction;
            }

            set
            {
                this._Direction = value;
            }
        }

        public int IndexImage
        {
            get
            {
                return this._IndexImage;
            }

            set
            {
                this._IndexImage = value;
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
