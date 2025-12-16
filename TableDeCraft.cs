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
        private Image img_table_craft = new Image();
        private int x =0, y=0,height=0,width=0;
        public TableDeCraft()
        {
            Set_mimage();
        }
        public void Afficher_image(Canvas canvas, int x, int y)
        {
            
            Canvas.SetLeft(this.img_table_craft,x);
            Canvas.SetTop(this.img_table_craft,y);
            canvas.Children.Add(this.img_table_craft);
        }
        public void craft(List<Nouriture> ingrediant, List<Nouriture> Recettes,Nouriture nouriture,Inventaire inventaire)
        {
            Recette recete = new Recette(Recettes,nouriture);
            bool fait = recete.Rectte_fait(ingrediant);
            if (fait)
            {
                inventaire.Liste_nourriture.Add(recete.Nouriture);
            }
        }
        public Image Img_table_craft
        {
            get
            {
                return this.img_table_craft;
            }

            set
            {
                this.img_table_craft = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        private void Set_mimage()
        {
            this.img_table_craft.Source = new BitmapImage(new Uri($"P:/SAE/Nouveau dossier (5)/Images/Outils/table_de_crafte.png"));
            this.img_table_craft.Tag = "table_de_craft";
        }
    }
}
