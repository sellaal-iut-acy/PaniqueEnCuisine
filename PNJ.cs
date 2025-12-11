using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Xps;

namespace PaniqueEnCuisine
{
    public class PNJ : EntiterMobile
    {
        private List<Nouriture> _Comande = new List<Nouriture>();
        private int _satisfaction;
        private int _exigence;
        private bool _servi;
        private string Nom;

        public PNJ(string nom , int x  , int y , int vitesse, int satisfaction, int exigence) : base( x, y,vitesse,nom)
        {
            this._satisfaction = satisfaction;
            this._exigence = exigence;
            this.Nom1 = nom;
        }

        public int Satisfaction
        {
            get
            {
                return this._satisfaction;
            }

            set
            {
                this._satisfaction = value;
            }
        }

        public int Exigence
        {
            get
            {
                return this._exigence;
            }

            set
            {
                this._exigence = value;
            }
        }

        public List<Nouriture> Comande
        {
            get
            {
                return this._Comande;
            }

            set
            {
                this._Comande = value;
            }
        }

        public string Nom1
        {
            get
            {
                return this.Nom;
            }

            set
            {
                this.Nom = value;
            }
        }

        private bool Servi
        {
            get 
            { 
                return _servi; 
            }
            set 
            { 
                _servi = value; 
            }
        }
        private bool Est_Servi()
        {
            return this._servi;
        }
    }
}
