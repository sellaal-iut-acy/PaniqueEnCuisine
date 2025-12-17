using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaniqueEnCuisine
{
    internal class TableDeCraft
    {
        private Image _ImageTableCraft = new Image();
        private int _X =0, _Y=0,_Hauteur=0,_Largeur=0;
        public TableDeCraft()
        {
            Set_mimage();
        }
        public void Afficher_Image(Canvas canvas, int x, int y)
        {
            
            Canvas.SetLeft(this._ImageTableCraft,x);
            Canvas.SetTop(this._ImageTableCraft,y);
            canvas.Children.Add(this._ImageTableCraft);
        }
        public void Craft(List<Nouriture> ingrediant, List<Nouriture> Recettes,Nouriture nouriture,Inventaire inventaire)
        {
            Recette recete = new Recette(Recettes,nouriture);
            bool fait = recete.Rectte_Fait(ingrediant);
            if (fait)
            {
                inventaire.Liste_nourriture.Add(recete.Nouriture);
            }
        }
        public Image Img_table_craft
        {
            get
            {
                return this._ImageTableCraft;
            }

            set
            {
                this._ImageTableCraft = value;
            }
        }

        public int X
        {
            get
            {
                return this._X;
            }

            set
            {
                this._X = value;
            }
        }

        public int Y
        {
            get
            {
                return this._Y;
            }

            set
            {
                this._Y = value;
            }
        }

        public int Height
        {
            get
            {
                return this._Hauteur;
            }

            set
            {
                this._Hauteur = value;
            }
        }

        public int Width
        {
            get
            {
                return this._Largeur;
            }

            set
            {
                this._Largeur = value;
            }
        }

        private void Set_mimage()
        {
            this._ImageTableCraft.Source = new BitmapImage(new Uri($"P:/SAE/Nouveau dossier (5)/Images/Outils/table_de_crafte.png"));
            this._ImageTableCraft.Tag = "table_de_craft";
        }
    }
}
