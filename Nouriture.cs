using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    public class Nouriture
    {
        private string _Nom = "";
        private Image _Image = new Image();
        private bool _EstCuit = false;
        private string _Type = "";
      

        public Nouriture(string nom, string type)
        {
            this.Nom = nom;
            this.Type = type;
            this.Image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"pack://application:,,,/Images/food/{nom}.png"));
  
        }

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

    

        public bool EstCuit
        {
            get
            {
                return this._EstCuit;
            }

            set
            {
                this._EstCuit = value;
            }
        }

        public string Type
        {
            get
            {
                return this._Type;
            }

            set
            {
                this._Type = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Nouriture nouriture &&
                   this.Nom == nouriture.Nom &&
                   EqualityComparer<Image>.Default.Equals(this._Image, nouriture._Image) &&
                   this._EstCuit == nouriture._EstCuit &&
                   this.Nom == nouriture.Nom &&
                   EqualityComparer<Image>.Default.Equals(this.Image, nouriture.Image) &&
                   this.EstCuit == nouriture.EstCuit;
        }
    }
}
