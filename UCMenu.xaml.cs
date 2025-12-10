using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
    /// Logique d'interaction pour UCMenu.xaml
    /// </summary>
    public partial class UCMenu : UserControl
    {
        private MainWindow main;

        public UCMenu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }

        private void B_Regles_Click(object sender, RoutedEventArgs e)
        {
            main.ChangeScreen(new UCRegles(main));

        }

        private void B_Parametre_Click(object sender, RoutedEventArgs e)
        {
            main.ChangeScreen(new UCParametres(main));
        }

        private void B_Jouer_Click(object sender, RoutedEventArgs e)
        {
            main.ChangeScreen(new UCJeu(main));
            

        }

        private void B_Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }


}
