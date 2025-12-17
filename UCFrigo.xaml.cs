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

        private int currentIndex = 0;
        private Inventaire NouriturePersonange;
        private Inventaire inventaire_frigo = new Inventaire(new List<Nouriture>(), 1);

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

            inventaire_frigo.Liste_nourriture.Add(tomate);
            inventaire_frigo.Liste_nourriture.Add(fromage);
            inventaire_frigo.Liste_nourriture.Add(steak);
            inventaire_frigo.Liste_nourriture.Add(pate);
            inventaire_frigo.Liste_nourriture.Add(pain);
            inventaire_frigo.Liste_nourriture.Add(saucisse);
            inventaire_frigo.Liste_nourriture.Add(patate);
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerFrigo();
        }

        private void button_reculer_Click(object sender, RoutedEventArgs e)
        {
            if (inventaire_frigo.Liste_nourriture.Count == 0) return;

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = inventaire_frigo.Liste_nourriture.Count - 1;

            nouriture_Choix.Source = inventaire_frigo.Liste_nourriture[currentIndex].Image.Source;
            NouritureAjouter.Text = ""; 
        }

        private void button_avancer_Click(object sender, RoutedEventArgs e)
        {

            if (inventaire_frigo.Liste_nourriture.Count == 0) return;

            currentIndex++;
            if (currentIndex >= inventaire_frigo.Liste_nourriture.Count) currentIndex = 0;

            nouriture_Choix.Source = inventaire_frigo.Liste_nourriture[currentIndex].Image.Source;
            NouritureAjouter.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NouritureAjouter.Text = "";
            NouriturePersonange.Liste_nourriture.Add(inventaire_frigo.Liste_nourriture[currentIndex]);
            NouritureAjouter.Text = $"{inventaire_frigo.Liste_nourriture[currentIndex].Nom} a été ajouter a votre inventaire";
        }
    }
}
