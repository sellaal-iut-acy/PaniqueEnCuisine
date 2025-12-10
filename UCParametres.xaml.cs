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
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            Console.WriteLine("Réglages son");
            main.ChangeScreen(new UCMenuSon(main));
        }

        private void ButtonSettingsSkin_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            Console.WriteLine("Réglages skins");
            main.ChangeScreen(new UCMenuSkin(main));
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            main.ChangeScreen(new UCMenu(main));
        }
    }

}
