using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace PaniqueEnCuisine
{
    public partial class UCfour : UserControl
    {
        private Nouriture Nouriture_a_cuire;
        private Nouriture Nouriture_cuit;
        private int currentIndex = 0;
        private bool selectioner = false;
        private Inventaire NouriturePersonange;


        public UCfour( Joueur joueur , Inventaire inventaire)
        {
            InitializeComponent();
            Console.WriteLine("fait");
            NouriturePersonange = inventaire;
            

            this.Focusable = true;
            this.Focus();
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerFour();
        }

        private void FermerFour()
        {
            if (this.Parent is Panel parent)
                parent.Children.Remove(this);
        }

        private void B_cuirre(object sender, RoutedEventArgs e)
        {
            if (selectioner && !NouriturePersonange.Liste_nourriture[currentIndex].EstCuit)
            {
                 
                NouritureCuit.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"pack://application:,,,/Images/food/{NouriturePersonange.Liste_nourriture[currentIndex].Nom}_cuit.png"));
                Nouriture_cuit = new Nouriture($"{NouriturePersonange.Liste_nourriture[currentIndex].Nom}_cuit", "cuit");
                NouriturePersonange.Liste_nourriture.RemoveAt(currentIndex);
                NouriturePersonange.Liste_nourriture.Remove(Nouriture_a_cuire);
                Nouriture_cuit.EstCuit = true;
                NouriturePersonange.Liste_nourriture.Add(Nouriture_cuit);
               
            }
            
        }

        private void button_reculer_Click(object sender, RoutedEventArgs e)
        {
            if (NouriturePersonange.Liste_nourriture.Count == 0) return;

            currentIndex--;
            if (currentIndex < 0) 
                currentIndex = NouriturePersonange.Liste_nourriture.Count - 1;

            nouriture_Choix.Source = NouriturePersonange.Liste_nourriture[currentIndex].Image.Source;
        }

        private void button_avancer_Click(object sender, RoutedEventArgs e)
        {

            if (NouriturePersonange.Liste_nourriture.Count == 0) return;

            currentIndex++;
            if (currentIndex >= NouriturePersonange.Liste_nourriture.Count) currentIndex = 0;

            nouriture_Choix.Source = NouriturePersonange.Liste_nourriture[currentIndex].Image.Source;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NouritureACuirre.Source = NouriturePersonange.Liste_nourriture[currentIndex].Image.Source;
            Nouriture_a_cuire = NouriturePersonange.Liste_nourriture[currentIndex];
            selectioner = true;
        }
    }
}
