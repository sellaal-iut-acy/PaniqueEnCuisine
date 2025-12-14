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
        private int _satisfaction =0;
        private int _exigence = 0;
        private bool _servi = false;
        private string nom = "";

        public PNJ(string nom , int x  , int y , int vitesse, int satisfaction, int exigence, int Widht,int Height) : base( x, y,vitesse,nom, Height,Widht)
        {
            this._satisfaction = satisfaction;
            this._exigence = exigence;
            this.nom = nom;
        }

        public void Placer_PNJ(double x, double y)
        {
            Set_Position(x, y,this.Vitesse);
        }
        public void Afficher_PNJ( Canvas grille,int width, int height)
        {
            Placer_PNJ(this.X, this.Y);
            Set_taile_Image(width, height);
            grille.Children.Add(this.current_Image);
        }
        public void Afficher_PNJ(Canvas grille, int width, int height ,int x , int  y)
        {
            Set_taile_Image(width, height);
            Set_Position(x, y);
            this.current_Image.Tag = "PNJ";
            grille.Children.Add(this.current_Image);
        }
        public void Set_taile_Image(int width, int height)
        {
            this.current_Image.Width = width ;
            this.current_Image.Height = height ;
        }

        public void Set_Position(double x, double y, int vitesse =0 )
        {
            Image image = new Image();
            this.X = x;
            this.Y = y;
            Canvas.SetLeft(this.current_Image, this.X + vitesse );
            Canvas.SetTop(this.current_Image, this.Y + vitesse);
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

        //public override bool Equals(object? obj)
        //{
        //    return obj is PNJ pNJ &&
        //           base.Equals(obj) &&
        //           this.nom == pNJ.nom &&
        //           this.Nom == pNJ.Nom &&
        //           this.Vitesse == pNJ.Vitesse &&
        //           this.X == pNJ.X &&
        //           this.Y == pNJ.Y &&
        //           this.VitesseCourse == pNJ.VitesseCourse &&
        //           EqualityComparer<Image[,]>.Default.Equals(this.Images, pNJ.Images) &&
        //           EqualityComparer<List<Nouriture>>.Default.Equals(this._Comande, pNJ._Comande) &&
        //           this._satisfaction == pNJ._satisfaction &&
        //           this._exigence == pNJ._exigence &&
        //           this.Satisfaction == pNJ.Satisfaction &&
        //           this.Exigence == pNJ.Exigence &&
        //           EqualityComparer<List<Nouriture>>.Default.Equals(this.Comande, pNJ.Comande);
        //}
        public bool Servi
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

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public bool Est_Servi()
        {
            return this.Servi;
        }
    }
}
