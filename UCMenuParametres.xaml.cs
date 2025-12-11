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
    /// Logique d'interaction pour UCMenuSon.xaml
    /// </summary>
    public partial class UCMenuSon : UserControl
    {
        private MainWindow main;
        public UCMenuSon(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play(); 
            main.ChangeScreen(new UCParametres(main));
        }

        private void B_Touches_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            FenetreConfigTouches fen = new FenetreConfigTouches();
            fen.ShowDialog();
        }

        private void B_Son_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
        }
    }
}
