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
      

        public Nouriture(string nom, string type)
        {
            this._nom = nom;
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
    }
}
