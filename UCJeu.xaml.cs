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
        bool right , left , up , down ;
        public int dx = 0, dy = 0;
        public Button page_suivante = new Button();
        public Button Page_arriere = new Button();

        public UCJeu(MainWindow mw)
        {
            
            InitializeComponent();
            main = mw;
            Ajout_Image_Player();
            Ajout_image_Fond();
            afficher_client();
            Rectangle_arret_Client();
            page_suivante.Click += Page_Suivante;
            Page_arriere.Click += Page_Arriere;
            colorTimer = new DispatcherTimer();
            colorTimer.Interval = TimeSpan.FromMilliseconds(400); // vitesse changement couleur
            colorTimer.Tick += ChangeColor;
            colorTimer.Tick += direction;
            colorTimer.Start();
        }
        private void File_Client()
        {
            main.mapManager.ManagerClients.move_all_PNJ(grille) ;
        }

        private void Rectangle_arret_Client()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 50;
            rect.Fill = Brushes.Red;
            rect.Tag = "commande";
            rect.MouseDown += servie;
            Canvas.SetTop(rect, 240);
            Canvas.SetLeft(rect, 700);
            grille.Children.Add(rect);
        }

        private void servie(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Client servi");
            main.mapManager.ManagerClients.Clients[0].Servi = true;
        }

        private void afficher_client()
        {
            Console.WriteLine("Affichage des clients");
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client1", 50, 50, 10, 100, 1, 50, 100));
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client1", 50, 50, 2, 100, 1, 50, 100));
            main.mapManager.ManagerClients.AjouterClient(new PNJ("Client1", 50, 50, 2, 100, 1, 50, 100));
            main.mapManager.ManagerClients.afficher_Clients(grille);
           
        }
        private void Page_Arriere(object sender, RoutedEventArgs e)
        {
            main.mapManager.playeur.Inventaire.Current_page -= 1;
            main.mapManager.playeur.Inventaire.afficher_objet_inventaire(main.mapManager.playeur.Inventaire, grille, main.mapManager.playeur.Inventaire.Current_page);
        }

        private void Page_Suivante(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void direction(object? sender, EventArgs e)
        {
            File_Client();
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


            if ((e.Key == ManagerSettings.KeyDroite || e.Key == Key.Right))
            {
                Console.WriteLine("droite");
                right = true;
                dx += main.mapManager.playeur.Vitesse;
                p.Direction = 1;

            }

            if ((e.Key == ManagerSettings.KeyGauche || e.Key == Key.Left))
            {
                Console.WriteLine("gauche");
                left = true;
                dx -= main.mapManager.playeur.Vitesse;
                p.Direction = 3;

            }

            if ((e.Key == ManagerSettings.KeyBas || e.Key == Key.Down))
            {
                Console.WriteLine("bas");
                down = true;
                dy += main.mapManager.playeur.Vitesse;
                p.Direction = 2;

            }

            if ((e.Key == ManagerSettings.KeyHaut || e.Key == Key.Up))
            {
                Console.WriteLine("haut");
                up = true;
                dy -= main.mapManager.playeur.Vitesse;
                p.Direction = 0;

            }
            if (e.Key == Key.E)
            {
                if (main.mapManager.playeur.Inventaire.Ouvert == false)
                {
                    main.mapManager.afficher_Inventaire_Player(main.mapManager.playeur, grille, ref page_suivante, ref Page_arriere);
                    main.mapManager.playeur.Inventaire.Ouvert = true;
                    Console.WriteLine("Inventaire ouvert");
                }
                else
                {
                    main.mapManager.playeur.Inventaire.Ouvert = false;
                    Console.WriteLine("Inventaire fermé");
                }

            }
            Canvas.SetTop(joueur, Canvas.GetTop(joueur) + dy);
            Canvas.SetLeft(joueur, Canvas.GetLeft(joueur) + dx);
            joueur.Source = p.GetImageJoueur();

        }

        public void stop_joueur(object sender, KeyEventArgs e)
        {
            var p = main.mapManager.playeur;

            if (e.Key == ManagerSettings.KeyDroite || e.Key == Key.Right) right = false;
            if (e.Key == ManagerSettings.KeyGauche || e.Key == Key.Left) left = false;
            if (e.Key == ManagerSettings.KeyBas || e.Key == Key.Down) down = false;
            if (e.Key == ManagerSettings.KeyHaut || e.Key == Key.Up) up = false;
            Console.WriteLine("dx: " + dx + " dy: " + dy);

            // PLUS AUCUNE TOUCHE = IDLE
            if (!up && !down && !left && !right)
            {
                p.Direction = 4; // idle
                joueur.Source = p.GetImageJoueur();
                Console.WriteLine("idle");
                dx = 0;
                dy = 0;
            }
        }

    }

}
