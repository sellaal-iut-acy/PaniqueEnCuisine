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
    /// Logique d'interaction pour UCGameOver.xaml
    /// </summary>
    public partial class UCGameOver : UserControl
    {
        private MainWindow _Main = new MainWindow();
        public UCGameOver(MainWindow mw)
        {
            InitializeComponent();
            Main = mw;
        }

        public MainWindow Main
        {
            get
            {
                return this._Main;
            }

            set
            {
                this._Main = value;
            }
        }

        private void B_Quitter_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            Application.Current.Shutdown();
        }

        private void B_RetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            Main.ChangerEcran(new UCMainMenu(_Main));
            Audio.JouerMusique("Sons/son_music_loop.wav", true);
        }
    }
}
