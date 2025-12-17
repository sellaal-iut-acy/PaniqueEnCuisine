using Microsoft.VisualBasic;
using PaniqueEnCuisine;
using System;
using System.Collections.Generic;
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
 
    public partial class UCMenuPlus : UserControl
    {
        private MainWindow _Main;

        public UCMenuPlus(MainWindow mw)
        {
            InitializeComponent();
            _Main = mw;
        }
        private void ButtonSettingsSon_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav"); ;
            Console.WriteLine("Réglages son");
            _Main.ChangerEcran(new UCMenuSon(_Main));
        }

        private void ButtonSettingsSkin_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            Console.WriteLine("Réglages skins");
            _Main.ChangerEcran(new UCMenuSkin(_Main));
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            _Main.ChangerEcran(new UCMainMenu(_Main));
        }
        private void ButtonSettingsLevel_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            _Main.ChangerEcran(new UCMenuLevel(_Main));
        }
    }

}
