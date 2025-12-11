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
    /// <summary>
    /// Logique d'interaction pour UCMenu.xaml
    /// </summary>
    public partial class UCMenu : UserControl
    {
        private MainWindow main;
        private MediaPlayer musicPlayer = new MediaPlayer();


        public UCMenu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

            PlayMenuMusic();

        }

        private void B_Regles_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            musicPlayer.Stop();

            main.ChangeScreen(new UCMenuRegles(main));

        }

        

        private void B_Jouer_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            musicPlayer.Stop();
            main.ChangeScreen(new UCJeu(main));
            

        }

        private void B_Quitter_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            musicPlayer.Stop();
            Application.Current.Shutdown();

        }
        private void PlayMenuMusic()
        {
            musicPlayer.Open(new Uri("Sons/son_music_loop.wav", UriKind.Relative));

            musicPlayer.MediaEnded += (s, e) =>
            {
                musicPlayer.Position = TimeSpan.Zero;
                musicPlayer.Play();
            };

            musicPlayer.Play();
        }

        private void B_Plus_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Sons/son_clic.wav");
            player.Play();
            musicPlayer.Stop();

            main.ChangeScreen(new UCParametres(main));
        }
    }


}
