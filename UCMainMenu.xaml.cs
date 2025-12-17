using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Media;
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
    
    public partial class UCMainMenu : UserControl
    {
        private MainWindow main;

        public UCMainMenu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

        }

        private void B_Regles_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            

            main.ChangerEcran(new UCMenuRegles(main));

        }


        private void B_Jouer_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            main.ChangerEcran(new UCJeu(main));
            Audio.ArretMusique();
            
        }

        private void B_Quitter_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            Application.Current.Shutdown();

        }
        

        private void B_Plus_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            main.ChangerEcran(new UCMenuPlus(main));
        }
    }


}
