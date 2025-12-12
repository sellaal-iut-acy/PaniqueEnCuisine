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
using System.Windows.Threading;


namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private MainWindow main;
        public Image joueur = new Image();
        private DispatcherTimer colorTimer;
        bool up, down, left, right;

        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

            Ajout_Image_Player();
            Ajout_image_Fond();

            colorTimer = new DispatcherTimer();
            colorTimer.Interval = TimeSpan.FromMilliseconds(400); // vitesse changement couleur
            colorTimer.Tick += ChangeColor;
            colorTimer.Start();
        }
        private void ChangeColor(object sender, EventArgs e)
        {
            var p = main.mapManager.playeur;

            // Change la couleur (0 → 4)
            p.Frame = (p.Frame + 1) % p.imagesPerso.GetLength(1);

            // Met à jour l’image (idle ou mouvement)
            joueur.Source = p.GetImageJoueur();
        }



        private void Ajout_image_Fond()
        {
            grille.Background = main.mapManager.fond;
        }

        private void Ajout_Image_Player()
        {
            var p = main.mapManager.playeur;

            joueur.Source = p.GetImageJoueur(); // NOUVEAU
            Set_Tail_Paler();
            Set_Coordoner_Player();
            grille.Children.Add(joueur);
        }


        private void Set_Coordoner_Player()
        {
            Canvas.SetTop(joueur, main.mapManager.playeur.Y);
            Canvas.SetLeft(joueur, main.mapManager.playeur.X);
        }

        private void Set_Tail_Paler()
        {
            joueur.Width = main.mapManager.playeur.Width;
            joueur.Height = main.mapManager.playeur.Height;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += move_joueur;
            Application.Current.MainWindow.KeyUp += stop_joueur;


        }

        public void move_joueur(object sender, KeyEventArgs e)
        {
            var p = main.mapManager.playeur;

            if (e.Key == ManagerSettings.KeyDroite)
            {
                right = true;
                p.Direction = 1;
                Canvas.SetLeft(joueur, Canvas.GetLeft(joueur) + p.Vitesse);
            }

            if (e.Key == ManagerSettings.KeyGauche)
            {
                left = true;
                p.Direction = 3;
                Canvas.SetLeft(joueur, Canvas.GetLeft(joueur) - p.Vitesse);
            }

            if (e.Key == ManagerSettings.KeyBas)
            {
                down = true;
                p.Direction = 2;
                Canvas.SetTop(joueur, Canvas.GetTop(joueur) + p.Vitesse);
            }

            if (e.Key == ManagerSettings.KeyHaut)
            {
                up = true;
                p.Direction = 0;
                Canvas.SetTop(joueur, Canvas.GetTop(joueur) - p.Vitesse);
            }

            joueur.Source = p.GetImageJoueur();
        }
        public void stop_joueur(object sender, KeyEventArgs e)
        {
            var p = main.mapManager.playeur;

            if (e.Key == ManagerSettings.KeyDroite) right = false;
            if (e.Key == ManagerSettings.KeyGauche) left = false;
            if (e.Key == ManagerSettings.KeyBas) down = false;
            if (e.Key == ManagerSettings.KeyHaut) up = false;

            // PLUS AUCUNE TOUCHE = IDLE
            if (!up && !down && !left && !right)
            {
                p.Direction = 4; // idle
                joueur.Source = p.GetImageJoueur();
            }
        }




    }

}
