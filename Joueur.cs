using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    public class Joueur : EntiterMobile
    {
        private int _score;
        private Inventaire inventaire;
        private int _main;
        public Joueur(string nom, int x, int y, int vitesse, int score ) : base(x, y, vitesse,nom)
        {
            this._score = score;
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
