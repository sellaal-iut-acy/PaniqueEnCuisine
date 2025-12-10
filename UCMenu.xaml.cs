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
    /// Logique d'interaction pour UCMenu.xaml
    /// </summary>
    public partial class UCMenu : UserControl
    {
        public UCMenu()
        {
            InitializeComponent();
        }

        private void B_Jouer_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Jouer");

        }
        private void B_Obtion_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Option");
        }

        private void B_Regles_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Regles");

        }

        private void B_Quitter_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Quitter");

        }
    }
}
