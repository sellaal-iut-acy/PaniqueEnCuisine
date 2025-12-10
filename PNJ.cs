using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Xps;

namespace PaniqueEnCuisine
{
    class PNJ : EntiterMobile
    {
        private List<Nouriture> _Comande = new List<Nouriture>();
        private int _satisfaction;
        private int _exigence;

        public PNJ(string nom , int x  , int y , int vitesse, int satisfaction, int exigence) : base(nom, x, y,vitesse)
        {
            this._satisfaction = satisfaction;
            this._exigence = exigence;
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

        public override bool Equals(object? obj)
        {
            return obj is PNJ pNJ &&
                   base.Equals(obj) &&
                   this.nom == pNJ.nom &&
                   this.Nom == pNJ.Nom &&
                   this.Vitesse == pNJ.Vitesse &&
                   this.X == pNJ.X &&
                   this.Y == pNJ.Y &&
                   this.VitesseCourse == pNJ.VitesseCourse &&
                   EqualityComparer<Image[,]>.Default.Equals(this.Images, pNJ.Images) &&
                   EqualityComparer<List<Nouriture>>.Default.Equals(this._Comande, pNJ._Comande) &&
                   this._satisfaction == pNJ._satisfaction &&
                   this._exigence == pNJ._exigence &&
                   this.Satisfaction == pNJ.Satisfaction &&
                   this.Exigence == pNJ.Exigence &&
                   EqualityComparer<List<Nouriture>>.Default.Equals(this.Comande, pNJ.Comande);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(this.nom);
            hash.Add(this.Nom);
            hash.Add(this.Vitesse);
            hash.Add(this.X);
            hash.Add(this.Y);
            hash.Add(this.VitesseCourse);
            hash.Add(this.Images);
            hash.Add(this._Comande);
            hash.Add(this._satisfaction);
            hash.Add(this._exigence);
            hash.Add(this.Satisfaction);
            hash.Add(this.Exigence);
            hash.Add(this.Comande);
            return hash.ToHashCode();
        }
    }
}
