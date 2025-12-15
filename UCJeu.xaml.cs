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
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private MainWindow main;

        // Visuel joueur
        private Image joueur = new Image();

        // Déplacement
        private bool up, down, left, right, sprint;
        private DispatcherTimer moveTimer;

        private double baseSpeed = 3;
        private double sprintMultiplier = 1.8;

        // UI inventaire
        public Button page_suivante = new Button();
        public Button page_arriere = new Button();

        int animDelay = 0;
        int animSpeed = 3;

        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;


            DefinirFondNiveau();
            Ajout_Image_Player();
            afficher_client();
            Rectangle_arret_Client();


            page_suivante.Click += Page_Suivante;
            page_arriere.Click += Page_Arriere;

            // Timer principal (game loop)
            moveTimer = new DispatcherTimer();
            moveTimer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
            moveTimer.Tick += UpdatePlayer;
            moveTimer.Start();
        }

        /* =========================
           === INITIALISATION ===
           ========================= */

        private void DefinirFondNiveau()
        {
            int niveau = main.mapManager.niveau_actuel;

            string uri = $"pack://application:,,,/Images/Niveau/image_fond_niveau{niveau}.png";

            ImageBrush brush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(uri)),
                Stretch = Stretch.Fill
            };

            grille.Background = brush;
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

        /* =========================
           === GAME LOOP ===
           ========================= */

        private void UpdatePlayer(object? sender, EventArgs e)
{
        var p = main.mapManager.playeur;

        double speed = sprint ? baseSpeed * sprintMultiplier : baseSpeed;
        bool moving = false;

        if (up)
        {
            p.Y -= speed;
            p.Direction = 0;
            moving = true;
        }

        if (right)
        {
            p.X += speed;
            p.Direction = 1;
            moving = true;
        }

        if (down)
        {
            p.Y += speed;
            p.Direction = 2;
            moving = true;
        }

        if (left)
        {
            p.X -= speed;
            p.Direction = 3;
            moving = true;
        }

                animDelay++;

                if (animDelay >= animSpeed)
                {
                    p.Frame = (p.Frame + 1) % 5;
                    animDelay = 0;
                }

                if (moving)
                {
                    // direction déjà définie
                }
                else
                {
                    p.Direction = 4; // idle
                }


                Canvas.SetLeft(joueur, p.X);
        Canvas.SetTop(joueur, p.Y);
        joueur.Source = p.GetImageJoueur();

        // PNJ
        main.mapManager.ManagerClients.move_all_PNJ(grille);
    }


        /* =========================
           === CLAVIER ===
           ========================= */

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

            // Action / inventaire
            if (e.Key == ManagerSettings.KeyAction)
            {
                var inv = main.mapManager.playeur.Inventaire;

                if (!inv.Ouvert)
                {
                    main.mapManager.afficher_Inventaire_Player(
                        main.mapManager.playeur,
                        grille,
                        ref page_suivante,
                        ref page_arriere
                    );
                    inv.Ouvert = true;
                }
                else
                {
                    inv.Ouvert = false;
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

        /* =========================
           === CLIENTS / UI ===
           ========================= */

        private void Rectangle_arret_Client()
        {
            Rectangle rect = new Rectangle
            {
                Width = 100,
                Height = 50,
                Fill = Brushes.Red,
                Tag = "commande"
            };

            rect.MouseDown += servie;
            Canvas.SetTop(rect, 240);
            Canvas.SetLeft(rect, 700);
            grille.Children.Add(rect);
        }
        private void NettoyerUCJeu()
        {
            // Stop timers
            moveTimer?.Stop();

            // Désinscription clavier
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
            Application.Current.MainWindow.KeyUp -= OnKeyUp;

            // Supprime tous les éléments visuels
            grille.Children.Clear();
            main.mapManager.ManagerClients.Clients.Clear();
            main.mapManager.playeur.X = default;
            main.mapManager.playeur.Y = default;
        }


        private void Button_RetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            NettoyerUCJeu(); 

            main.ChangeScreen(new UCMainMenu(main));
        }

        private void servie(object sender, MouseButtonEventArgs e)
        {
            main.mapManager.ManagerClients.Clients[0].Servi = true;
        }

        private void afficher_client()
        {
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client1", 50, 50, 10, 100, 1, 50, 100));
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client2", 50, 50, 2, 100, 1, 50, 100));
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client3", 50, 50, 2, 100, 1, 50, 100));
            main.mapManager.ManagerClients.afficher_Clients(grille);
        }

        private void Page_Arriere(object sender, RoutedEventArgs e)
        {
            main.mapManager.playeur.Inventaire.Current_page--;
            main.mapManager.playeur.Inventaire.afficher_objet_inventaire(
                main.mapManager.playeur.Inventaire,
                grille,
                main.mapManager.playeur.Inventaire.Current_page
            );
        }

        private void Page_Suivante(object sender, RoutedEventArgs e)
        {
            main.mapManager.playeur.Inventaire.Current_page++;
        }
    }
}
