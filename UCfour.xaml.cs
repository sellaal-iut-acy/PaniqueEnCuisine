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
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCfour.xaml
    /// </summary>
    public partial class UCfour : UserControl
    {
        private Rectangle objet_A_cuirre = new Rectangle();
        private Rectangle objet_cuit = new Rectangle();
        private Image nouriture_cuit = new Image();
        public UCfour()
        {
            InitializeComponent();
            Cree_four();
            //moveTimer = new DispatcherTimer();
            //moveTimer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
            //moveTimer.Tick += UpdatePlayer;
            //moveTimer.Start();
        }

        private void Cree_four()
        {
            set_case_pour_nourriture();
            
        }

        private void set_case_pour_nourriture()
        {
            // case pour poser l'objet a cuirre
            objet_A_cuirre.Width = 50;
            objet_A_cuirre.Height = 50;
            Canvas.SetTop(objet_A_cuirre, 210 );
            Canvas.SetLeft(objet_A_cuirre, 210);
            objet_A_cuirre.Fill = Brushes.LightGray;
            canvas.Children.Add(objet_A_cuirre);

            // case de l'objet cui 
            objet_cuit.Width = 50;
            objet_cuit.Height = 50;
            Canvas.SetTop(objet_cuit, 210);
            Canvas.SetLeft(objet_cuit, 500);
            objet_cuit.Fill = Brushes.LightGray;
            canvas.Children.Add(objet_cuit);
        }

        private void Aficher_inventaire_joueur()
        {
            
        }

        private void B_cuirre(object sender, RoutedEventArgs e)
        {
            foreach (Nouriture nouriture_a_cuirre in canvas.Children)
            { 
                if ((string)nouriture_a_cuirre.Image.Tag == "cuire")
                {
                    Cuisson(nouriture_a_cuirre);
                }
            }

            
        }

        private void Cuisson(Nouriture nouriture)
        {
            int i = 0;
            while (i < nouriture.Temps_cuisson)
                i++;

        }
    }
}
