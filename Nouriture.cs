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
        private int _temps_cuisson = 0;
      

        public Nouriture(string nom, string type)
        {
            this._nom = nom;
            this._image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/Images/food/{nom}.png", UriKind.Relative));
  
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

    

        public int Temps_cuisson
        {
            get
            {
                return this._temps_cuisson;
            }

            set
            {
                this._temps_cuisson = value;
            }
        }

       public bool Est_cuit()
        {
            if (this._temps_cuisson <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

    }
}
