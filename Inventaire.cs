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
        private List<Nouriture> _liste_nourriture = new List<Nouriture>();
        private int current_page = 0;
        private bool ouvert = false;
        private int nb_page = 1;
        private int old_page = 0;
        private int max_page ;

        public Inventaire(List<Nouriture> liste_nourriture,int current_page)
        {
            
            Console.WriteLine("fait");
            this.Liste_nourriture = liste_nourriture;
            this.Current_page = current_page;
            this.old_page = this.current_page;
        }

        public List<Nouriture> Liste_nourriture
        {
            get
            {
                return this._liste_nourriture;
            }

            set
            {
                this._liste_nourriture = value;
            }
        }

        public int Current_page
        {
            get
            {
                return this.current_page;
            }

            set
            {
                this.current_page = value;
            }
        }

        public bool Ouvert
        {
            get
            {
                return this.ouvert;
            }

            set
            {
                this.ouvert = value;
            }
        }

        public int Nb_page
        {
            get
            {
                return this.nb_page;
            }

            set
            {
                this.nb_page = value;
            }
        }

        public int Old_page
        {
            get
            {
                return this.old_page;
            }

            set
            {
                this.old_page = value;
            }
        }

        public int Max_page
        {
            get
            {
                return this.max_page;
            }

            set
            {
                this.max_page = value;
            }
        }

        public int Max_page1
        {
            get
            {
                return this.max_page;
            }

            set
            {
                this.max_page = value;
            }
        }
    }
}
