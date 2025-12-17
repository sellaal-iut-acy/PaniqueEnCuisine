using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCFrigo.xaml
    /// </summary>
    public partial class UCFrigo : UserControl
    {

        private int _IndexActuel = 0;
        private Inventaire _NouriturePersonange;
        private Inventaire _InventaireFrigo = new Inventaire(new List<Nouriture>(), 1);

        public Inventaire NouriturePersonange
        {
            get
            {
                return this._NouriturePersonange;
            }

            set
            {
                this._NouriturePersonange = value;
            }
        }

        public Inventaire InventaireFrigo
        {
            get
            {
                return this._InventaireFrigo;
            }

            set
            {
                this._InventaireFrigo = value;
            }
        }

        public int IndexActuel
        {
            get
            {
                return this._IndexActuel;
            }

            set
            {
                this._IndexActuel = value;
            }
        }

        public UCFrigo(Inventaire inventaire)
        {
            InitializeComponent();
            ajout_nouriture();
            NouriturePersonange = inventaire;
           
        }

        private void FermerFrigo()
        {
            if (this.Parent is Panel parent)
            {
                parent.Children.Remove(this);
            }
        }


        private void ajout_nouriture()
        {
            Nouriture tomate = new Nouriture("tomate", "ingrediant");
            Nouriture fromage = new Nouriture("fromage", "cru");
            Nouriture steak = new Nouriture("steak", "cru");
            Nouriture pate = new Nouriture("pate", "ingrediant");
            Nouriture pain = new Nouriture("pain", "ingrediant");
            Nouriture saucisse = new Nouriture("saucisse", "cru");
            Nouriture patate = new Nouriture("patate", "cru");

            InventaireFrigo.Liste_nourriture.Add(tomate);
            InventaireFrigo.Liste_nourriture.Add(fromage);
            InventaireFrigo.Liste_nourriture.Add(steak);
            InventaireFrigo.Liste_nourriture.Add(pate);
            InventaireFrigo.Liste_nourriture.Add(pain);
            InventaireFrigo.Liste_nourriture.Add(saucisse);
            InventaireFrigo.Liste_nourriture.Add(patate);
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerFrigo();
        }

        private void button_reculer_Click(object sender, RoutedEventArgs e)
        {
            if (InventaireFrigo.Liste_nourriture.Count == 0) return;

            IndexActuel--;
            if (IndexActuel < 0)
                IndexActuel = InventaireFrigo.Liste_nourriture.Count - 1;

            nouriture_Choix.Source = InventaireFrigo.Liste_nourriture[IndexActuel].Image.Source;
            NouritureAjouter.Text = ""; 
        }

        private void button_avancer_Click(object sender, RoutedEventArgs e)
        {

            if (InventaireFrigo.Liste_nourriture.Count == 0) return;

            IndexActuel++;
            if (_IndexActuel >= InventaireFrigo.Liste_nourriture.Count) IndexActuel = 0;

            nouriture_Choix.Source = InventaireFrigo.Liste_nourriture[IndexActuel].Image.Source;
            NouritureAjouter.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NouritureAjouter.Text = "";
            NouriturePersonange.Liste_nourriture.Add(InventaireFrigo.Liste_nourriture[IndexActuel]);
            NouritureAjouter.Text = $"{_InventaireFrigo.Liste_nourriture[_IndexActuel].Nom} a été ajouter a votre _Inventaire";
        }
    }
}
