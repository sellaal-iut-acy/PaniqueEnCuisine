using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    public partial class UCJeu : UserControl
    {
        public MainWindow main;

        private Image joueur = new Image();

        private bool up, down, left, right, sprint;
        private DispatcherTimer moveTimer;

        private double baseSpeed = 3;
        private double sprintMultiplier = 1.8;

        private int animDelay = 0;
        private int animSpeed = 3;

        private ManagerColision colision = new ManagerColision();

        private UCFrigo ucFrigo = null;
        private UCfour ucFour = null;
        private UCTableDeCraft ucTableDeCraft = null;


        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
            DefinirFondNiveau();
            Ajouter_outlis_cuisine();
            Ajout_Image_Player();
            JouerLaMusiqueDuNiveau();





            moveTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            moveTimer.Tick += UpdatePlayer;
            moveTimer.Start();
           
        }

        /* ================= INIT ================= */

        private void DefinirFondNiveau()
        {
            int niveau = main.MapManager._NiveauActuel;
            grille.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(
                    new Uri($"pack://application:,,,/Images/Niveau/image_fond_niveau{niveau}.png")
                ),
                Stretch = Stretch.Fill
            };
        }

        private void Ajout_Image_Player()
        {
            var p = main.MapManager._Playeur;

            joueur.Width = p.Width;
            joueur.Height = p.Height;
            joueur.Source = p.GetImageJoueur();

            Canvas.SetLeft(joueur, p.X);
            Canvas.SetTop(joueur, p.Y);

            grille.Children.Add(joueur);
            
        }
        private void JouerLaMusiqueDuNiveau()
        {
            Audio.ArretMusique();
            Audio.JouerMusique($"Sons/son_music_loop_niveau{main.MapManager._NiveauActuel}.wav", true);

        }

        /* ================= GAME LOOP ================= */

        private void UpdatePlayer(object sender, EventArgs e)
        {
            var p = main.MapManager._Playeur;

            double speed = sprint ? baseSpeed * sprintMultiplier : baseSpeed;
            bool moving = false;

            if (up) { p.Y -= speed; p._Direction = 0; moving = true; }
            if (right) { p.X += speed; p._Direction = 1; moving = true; }
            if (down) { p.Y += speed; p._Direction = 2; moving = true; }
            if (left) { p.X -= speed; p._Direction = 3; moving = true; }

            animDelay++;
            if (animDelay >= animSpeed)
            {
                p._IndexImage = (p._IndexImage + 1) % 5;
                animDelay = 0;
            }

            if (!moving) p._Direction = 4;

            Canvas.SetLeft(joueur, p.X);
            Canvas.SetTop(joueur, p.Y);
            joueur.Source = p.GetImageJoueur();

        }
       
        /* ================= CLAVIER ================= */

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += OnKeyDown;
            Application.Current.MainWindow.KeyUp += OnKeyUp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == ManagerSettings.KeyHaut) up = true;
            if (e.Key == ManagerSettings.KeyBas) down = true;
            if (e.Key == ManagerSettings.KeyGauche) left = true;
            if (e.Key == ManagerSettings.KeyDroite) right = true;
            if (e.Key == ManagerSettings.KeySprint) sprint = true;

            if (e.Key == ManagerSettings.KeyAction)
            {
                if (colision.VeriferColision_PLAYER_FrIgo(grille, joueur, main.MapManager._Playeur))
                    OuvrirFrigo();

                if (colision.VeriferColision_PLAYER_Four(grille, joueur, main.MapManager._Playeur))
                    OuvrirFour();
                if (e.Key == ManagerSettings.KeyAction)
                {
                    if (colision.VeriferColision_PLAYER_Caisse(grille, joueur, main.MapManager._Playeur))
                        OuvrirCaisse();
                }
            }
        }



        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == ManagerSettings.KeyHaut) up = false;
            if (e.Key == ManagerSettings.KeyBas) down = false;
            if (e.Key == ManagerSettings.KeyGauche) left = false;
            if (e.Key == ManagerSettings.KeyDroite) right = false;
            if (e.Key == ManagerSettings.KeySprint) sprint = false;
        }

        /* ================= OVERLAYS ================= */

        private void OuvrirFrigo()
        {
            if (ucFrigo != null) return;

            ucFrigo = new UCFrigo(main.MapManager._Playeur.Inventaire);
            AjouterOverlay(ucFrigo);
            ucFrigo.Unloaded += (s, e) => ucFrigo = null;
        }

        private void OuvrirFour()
        {
            if (ucFour != null) return;
            ucFour = new UCfour(main.MapManager._Playeur,main.MapManager._Playeur.Inventaire);
            AjouterOverlay(ucFour);
            ucFour.Unloaded += (s, e) => ucFour = null;
        }
        private UCCaisse ucCaisse = null;

        private void OuvrirCaisse()
        {
            if (ucCaisse != null) return;

            ucCaisse = new UCCaisse(main.MapManager._Playeur);
            AjouterOverlay(ucCaisse);
            ucCaisse.Unloaded += (s, e) => ucCaisse = null;
        }



        private void AjouterOverlay(UserControl uc)
        {
            uc.Width = grille.ActualWidth;
            uc.Height = grille.ActualHeight;

            Canvas.SetLeft(uc, 0);
            Canvas.SetTop(uc, 0);
            Panel.SetZIndex(uc, 999);
            grille.Children.Add(uc);
            uc.Focus();
        }

        private void Button_Inventaire_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Ouverture de l'_Inventaire");
        }

        private void Button_RetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            Audio.ArretMusique();


            NettoyerUCJeu();

            main.ChangerEcran(new UCMainMenu(main));

            Audio.JouerMusique("Sons/son_music_loop.wav", true);

        }

        private void NettoyerUCJeu()
        {
            // Stop la boucle de jeu
            moveTimer?.Stop();

            // Désinscription clavier
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
            Application.Current.MainWindow.KeyUp -= OnKeyUp;

            // Fermer overlays
            if (ucFrigo != null && ucFrigo.Parent is Panel parentFrigo)
                parentFrigo.Children.Remove(ucFrigo);

            if (ucFour != null && ucFour.Parent is Panel parentFour)
                parentFour.Children.Remove(ucFour);

            if (ucCaisse != null && ucCaisse.Parent is Panel parentCaisse)
                parentCaisse.Children.Remove(ucCaisse);

            ucFrigo = null;
            ucFour = null;
            ucCaisse = null;

            // 🔥 RESET CAISSE (IMPORTANT)
            Caisse.Reset();

            // Nettoyage du canvas
            grille.Children.Clear();

            // Reset gameplay
            main.MapManager.ManagerOutilsCuisine.Outils.Clear();

            main.MapManager._Playeur.X = 0;
            main.MapManager._Playeur.Y = 0;
        }


        private void Button_TableDeCraft_Click(object sender, RoutedEventArgs e)
        {
            if (ucTableDeCraft != null) return;

            ucTableDeCraft = new UCTableDeCraft(main.MapManager._Playeur);
            AjouterOverlay(ucTableDeCraft);
            ucTableDeCraft.Unloaded += (s, e) => ucTableDeCraft = null;
        }


      


        private void Ajouter_outlis_cuisine()
        {
            main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Frigo("Frigo", 100, 5, 100, 150, 0, 50)
            );

            main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Foure("Four", 400, 50, 200, 100, 0, 50)
            );

            main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Caisse("Caisse", 640, 300, 70, 50, 0, 50)
             );

            main.MapManager.ManagerOutilsCuisine.AfficherOutilsCuisine(grille);


        }
    }
}
