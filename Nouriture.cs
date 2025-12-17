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
        private string _nom = "";
        private Image _image = new Image();
        private bool _EstCuit = false;
        private string _type = "";
      

        public Nouriture(string nom, string type)
        {
            this._nom = nom;
            this.Type = type;
            this._image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"pack://application:,,,/Images/food/{nom}.png"));
  
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
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
                return this._type;
            }

            set
            {
                this._type = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Nouriture nouriture &&
                   this._nom == nouriture._nom &&
                   EqualityComparer<Image>.Default.Equals(this._image, nouriture._image) &&
                   this._EstCuit == nouriture._EstCuit &&
                   this.Nom == nouriture.Nom &&
                   EqualityComparer<Image>.Default.Equals(this.Image, nouriture.Image) &&
                   this.EstCuit == nouriture.EstCuit;
        }
    }
}
