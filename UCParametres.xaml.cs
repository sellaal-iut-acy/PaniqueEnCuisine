using Microsoft.VisualBasic;
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
using PaniqueEnCuisine;

namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCParametres.xaml
    /// </summary>
    public partial class UCParametres : UserControl
    {
        private MainWindow main;

        public UCParametres(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }
        private void ButtonSettingsSon_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Réglages son");
        }

        private void ButtonSettingsSkin_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Réglages skins");
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            main.ChangeScreen(new UCMenu(main));
        }
    }

}
