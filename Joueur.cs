using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaniqueEnCuisine
{
    class Joueur : EntiterMobile
    {
        private int _score;
        private Inventaire inventaire;
        private int _main;
        public Joueur(string nom, int x, int y, int vitesse, int score) : base(nom, x, y, vitesse)
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
    }
}
