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
        private Nouriture _NouritureACuire;
        private Nouriture _NouritureCuit;
        private int _CurrentIndex = 0;
        private bool _Selectioner = false;
        private Inventaire _NouriturePersonange;

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

        public Nouriture NouritureACuire
        {
            get
            {
                return this._NouritureACuire;
            }

            set
            {
                this._NouritureACuire = value;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return this._CurrentIndex;
            }

            set
            {
                this._CurrentIndex = value;
            }
        }

        public bool Selectioner
        {
            get
            {
                return this._Selectioner;
            }

            set
            {
                this._Selectioner = value;
            }
        }

        public Nouriture NouritureCuit1
        {
            get
            {
                return this._NouritureCuit;
            }

            set
            {
                this._NouritureCuit = value;
            }
        }

        public UCfour( Joueur joueur , Inventaire inventaire)
        {
            InitializeComponent();
            Console.WriteLine("fait");
            _NouriturePersonange = inventaire;
            

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
            Console.WriteLine($"{NouriturePersonange.Liste_nourriture[CurrentIndex].Type}");
            if (_Selectioner && !NouriturePersonange.Liste_nourriture[CurrentIndex].EstCuit && (NouriturePersonange.Liste_nourriture[CurrentIndex].Type == "cru"))
            {
                 
                NouritureCuit.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"pack://application:,,,/Images/food/{NouriturePersonange.Liste_nourriture[CurrentIndex].Nom}_cuit.png"));
                NouritureCuit1 = new Nouriture($"{NouriturePersonange.Liste_nourriture[CurrentIndex].Nom}_cuit", "cuit");
                NouriturePersonange.Liste_nourriture.RemoveAt(CurrentIndex);
                NouriturePersonange.Liste_nourriture.Remove(NouritureACuire);
                NouritureCuit1.EstCuit = true;
                NouriturePersonange.Liste_nourriture.Add(NouritureCuit1);
               
            }
            
        }

        private void button_reculer_Click(object sender, RoutedEventArgs e)
        {
            if (NouriturePersonange.Liste_nourriture.Count == 0) return;

            CurrentIndex--;
            if (CurrentIndex < 0) 
                CurrentIndex = NouriturePersonange.Liste_nourriture.Count - 1;

            nouriture_Choix.Source = NouriturePersonange.Liste_nourriture[CurrentIndex].Image.Source;
        }

        private void button_avancer_Click(object sender, RoutedEventArgs e)
        {

            if (NouriturePersonange.Liste_nourriture.Count == 0) return;

            _CurrentIndex++;
            if (_CurrentIndex >= NouriturePersonange.Liste_nourriture.Count) CurrentIndex = 0;

            nouriture_Choix.Source = NouriturePersonange.Liste_nourriture[CurrentIndex].Image.Source;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NouritureACuirre.Source = NouriturePersonange.Liste_nourriture[CurrentIndex].Image.Source;
            NouritureACuire = NouriturePersonange.Liste_nourriture[CurrentIndex];
            Selectioner = true;
        }
    }
}
