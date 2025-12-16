using System;
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
            Ajout_Image_Player();
            afficher_client();
            Rectangle_arret_Client();
            Ajouter_outlis_cuisine();

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
            int niveau = main.mapManager.niveau_actuel;
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
            var p = main.mapManager.playeur;

            joueur.Width = p.Width;
            joueur.Height = p.Height;
            joueur.Source = p.GetImageJoueur();

            Canvas.SetLeft(joueur, p.X);
            Canvas.SetTop(joueur, p.Y);

            grille.Children.Add(joueur);
        }

        /* ================= GAME LOOP ================= */

        private void UpdatePlayer(object sender, EventArgs e)
        {
            var p = main.mapManager.playeur;

            double speed = sprint ? baseSpeed * sprintMultiplier : baseSpeed;
            bool moving = false;

            if (up) { p.Y -= speed; p.Direction = 0; moving = true; }
            if (right) { p.X += speed; p.Direction = 1; moving = true; }
            if (down) { p.Y += speed; p.Direction = 2; moving = true; }
            if (left) { p.X -= speed; p.Direction = 3; moving = true; }

            animDelay++;
            if (animDelay >= animSpeed)
            {
                p.Frame = (p.Frame + 1) % 5;
                animDelay = 0;
            }

            if (!moving) p.Direction = 4;

            Canvas.SetLeft(joueur, p.X);
            Canvas.SetTop(joueur, p.Y);
            joueur.Source = p.GetImageJoueur();

            main.mapManager.ManagerClients.move_all_PNJ(grille);
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
                if (colision.VeriferColision_PLAYER_FrIgo(grille, joueur, main.mapManager.playeur))
                    OuvrirFrigo();

                if (colision.VeriferColision_PLAYER_Four(grille, joueur, main.mapManager.playeur))
                    OuvrirFour();
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

            ucFrigo = new UCFrigo();
            AjouterOverlay(ucFrigo);
            ucFrigo.Unloaded += (s, e) => ucFrigo = null;
        }

        private void OuvrirFour()
        {
            if (ucFour != null) return;
            ucFour = new UCfour(main.mapManager.playeur,main.mapManager.playeur.Inventaire);
            AjouterOverlay(ucFour);
            ucFour.Unloaded += (s, e) => ucFour = null;
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

        private void Button_RetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            NettoyerUCJeu();

            main.ChangeScreen(new UCMainMenu(main));
        }

        private void NettoyerUCJeu()
        {
            // Stop la boucle de jeu
            moveTimer?.Stop();

            // Désinscription clavier
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
            Application.Current.MainWindow.KeyUp -= OnKeyUp;

            // Fermer overlays s’ils sont ouverts
            if (ucFrigo != null && ucFrigo.Parent is Panel parentFrigo)
                parentFrigo.Children.Remove(ucFrigo);

            if (ucFour != null && ucFour.Parent is Panel parentFour)
                parentFour.Children.Remove(ucFour);

            ucFrigo = null;
            ucFour = null;

            // Nettoyage du canvas du jeu
            grille.Children.Clear();

            // Reset données gameplay (à adapter si besoin)
            main.mapManager.ManagerClients.Clients.Clear();
            main.mapManager.ManagerOutilsCuisine.Outils.Clear();

            main.mapManager.playeur.X = 0;
            main.mapManager.playeur.Y = 0;
        }

        private void Button_TableDeCraft_Click(object sender, RoutedEventArgs e)
        {
            if (ucTableDeCraft != null) return;

            ucTableDeCraft = new UCTableDeCraft();
            AjouterOverlay(ucTableDeCraft);
            ucTableDeCraft.Unloaded += (s, e) => ucTableDeCraft = null;
        }


        /* ================= CLIENTS ================= */

        private void Rectangle_arret_Client()
        {
            Rectangle rect = new Rectangle
            {
                Width = 100,
                Height = 50,
                Fill = Brushes.Red
            };

            rect.MouseDown += servie;
            Canvas.SetTop(rect, 240);
            Canvas.SetLeft(rect, 700);
            grille.Children.Add(rect);
        }

        private void servie(object sender, MouseButtonEventArgs e)
        {
            var clients = main.mapManager.ManagerClients.Clients;
            clients[^1].Servi = true;
        }

        private void afficher_client()
        {
            main.mapManager.ManagerClients.AjouterClient(
                new PNJ("Client", 50, 0, 2, 100, 1, 50, 100)
            );

            main.mapManager.ManagerClients.afficher_Clients(grille);
        }

        private void Ajouter_outlis_cuisine()
        {
            main.mapManager.ManagerOutilsCuisine.AjouterOutil(
                new Frigo("Frigo", 300, 200, 100, 150, 0, 50)
            );

            main.mapManager.ManagerOutilsCuisine.AjouterOutil(
                new Foure("Four", 500, 200, 100, 50, 0, 50)
            );
            main.mapManager.ManagerOutilsCuisine.AfficherOutilsCuisine(grille);


        }
    }
}
