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
        private MainWindow main;

        public UCMenuPlus(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }
        private void ButtonSettingsSon_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav"); ;
            Console.WriteLine("Réglages son");
            main.ChangerEcran(new UCMenuSon(main));
        }

        private void ButtonSettingsSkin_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            Console.WriteLine("Réglages skins");
            main.ChangerEcran(new UCMenuSkin(main));
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            main.ChangerEcran(new UCMainMenu(main));
        }
        private void ButtonSettingsLevel_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            main.ChangerEcran(new UCMenuLevel(main));
        }
    }

}
