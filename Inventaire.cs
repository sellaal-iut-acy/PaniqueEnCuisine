using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PaniqueEnCuisine
{
    public  class Inventaire
    {
        private List<Nouriture> _ListeNouritures = new List<Nouriture>();
        private int _PageActuel = 0;
        private bool _Ouvert = false;
        private int _Nb_Page = 1;
        private int _AnciennePage = 0;
        private int _MaxPage ;

        public Inventaire(List<Nouriture> liste_nourriture,int current_page)
        {
            
            Console.WriteLine("fait");
            this.Liste_nourriture = liste_nourriture;
            this.Current_page = current_page;
            this.AnciennePage = this.PageActuel;
        }

        public List<Nouriture> Liste_nourriture
        {
            get
            {
                return this._ListeNouritures;
            }

            set
            {
                this._ListeNouritures = value;
            }
        }

        public int Current_page
        {
            get
            {
                return this._PageActuel;
            }

            set
            {
                this._PageActuel = value;
            }
        }

        public bool Ouvert
        {
            get
            {
                return this._Ouvert;
            }

            set
            {
                this._Ouvert = value;
            }
        }
        public int Nb_Page
        {
            get
            {
                return this._Nb_Page;
            }

            set
            {
                this._Nb_Page = value;
            }
        }

        public int PageActuel
        {
            get
            {
                return this._PageActuel;
            }

            set
            {
                this._PageActuel = value;
            }
        }

        public int MaxPage
        {
            get
            {
                return this._MaxPage;
            }

            set
            {
                this._MaxPage = value;
            }
        }

        public int AnciennePage
        {
            get
            {
                return this._AnciennePage;
            }

            set
            {
                this._AnciennePage = value;
            }
        }
    }
}
