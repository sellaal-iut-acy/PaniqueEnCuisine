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
        private Button Page_suivante = new Button();
        private Button Page_arrierre = new Button();
        private Inventaire inventaire_frigo = new Inventaire(new List<Nouriture>(), 1);

        public UCFrigo()
        {
            InitializeComponent();
           
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
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger","plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));
            inventaire_frigo.Liste_nourriture.Add(new Nouriture("burger", "plat"));

        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerFrigo();
        }
    }
}
