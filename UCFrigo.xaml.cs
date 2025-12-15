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
            cree_frigo();
            ajout_nouriture();
            afficher_Frigo();
            canvas.KeyDown += fermer_inventaire;
            Page_suivante.Click += page_suivante;
            Page_arrierre.Click += page_presedente;
           
        }

        private void page_presedente(object sender, RoutedEventArgs e)
        {
            if (inventaire_frigo.Current_page > inventaire_frigo.Old_page)
            {
                inventaire_frigo.page_precedent(canvas, inventaire_frigo);
            }
        }

        private void page_suivante(object sender, RoutedEventArgs e)
        {
            if(inventaire_frigo.Current_page < inventaire_frigo.Max_page)
            {
                inventaire_frigo.Old_page = inventaire_frigo.Current_page;
                inventaire_frigo.page_suivante(canvas, inventaire_frigo); 
            }
        }

        private void fermer_inventaire(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
                this.Visibility = Visibility.Hidden;
        }

        private void cree_frigo()
        {
            inventaire_frigo.Cree_inventaire(canvas, ref Page_suivante, ref  Page_arrierre);
            inventaire_frigo.cree_slot_inventaire(canvas);
            inventaire_frigo.set_page_max();
            Console.WriteLine($"page max = {inventaire_frigo.Max_page}");
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
        private void afficher_Frigo()
        {
           inventaire_frigo.afficher_objet_inventaire(inventaire_frigo,canvas, 1);
        }
         
    }
}
