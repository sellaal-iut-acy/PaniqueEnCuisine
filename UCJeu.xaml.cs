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



        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

            Ajout_Image_Player();
            Ajout_image_Fond();

            colorTimer = new DispatcherTimer();
            colorTimer.Interval = TimeSpan.FromMilliseconds(400); // vitesse changement couleur
            colorTimer.Tick += ChangeColor;
            colorTimer.Tick += direction;
            colorTimer.Start();
        }

        private void direction(object? sender, EventArgs e)
        {
            
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
            Inventaire_player();

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
            

            if ((e.Key == ManagerSettings.KeyDroite || e.Key == Key.Right) )
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

        public void Inventaire_player()
        {
            Cree_inventaire();
            cree_slot_inventaire();

        }
        public void Cree_inventaire()
        {
            Rectangle inventaire = new Rectangle();
            inventaire.Width = 460;
            inventaire.Height = 250;
            inventaire.Fill = Brushes.Gray;
            Canvas.SetTop(inventaire, 237);
            Canvas.SetLeft(inventaire, 165);
            grille.Children.Add(inventaire);
            Button page_suivante = new Button();
            page_suivante.Content = ">";
            page_suivante.Width = 30;
            page_suivante.Height = 50;
            page_suivante.Click += Page_suivante_Click;
            Canvas.SetTop(page_suivante, 386);
            Canvas.SetLeft(page_suivante, 586);
            grille.Children.Add(page_suivante);
            Button page_arriere = new Button();
            page_arriere.Content = "<";
            page_arriere.Width = 30;
            page_arriere.Height = 50;
            page_arriere.Click += Page_arriere_Click;
            Canvas.SetTop(page_arriere,386);
            Canvas.SetLeft(page_arriere, 176);
            grille.Children.Add(page_arriere);
        }

        private void Page_suivante_Click(object sender, RoutedEventArgs e)
        {
            main.mapManager.playeur.Inventaire.Current_page += 1;
            afficher_objet_inventaire(main.mapManager.playeur.Inventaire, main.mapManager.playeur.Inventaire.Current_page);
        }

        private void Page_arriere_Click(object sender, RoutedEventArgs e)
        {
            main.mapManager.playeur.Inventaire.Current_page -= 1;
            afficher_objet_inventaire(main.mapManager.playeur.Inventaire, main.mapManager.playeur.Inventaire.Current_page);
        }

        public void afficher_objet_inventaire(Inventaire inventaire, int page)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 6*page; c < 6*page+6; c++)
                {
                    if (c >= inventaire.Liste_nourriture.Count)
                        break;
                    grille.Children.Add(inventaire.Liste_nourriture[c].Image);
                    Canvas.SetLeft(inventaire.Liste_nourriture[c].Image, 260 + (l * 63));
                    Canvas.SetLeft(inventaire.Liste_nourriture[c].Image, 213 + ((c%6+1) * 63));
                }
            }
        }

        public void cree_slot_inventaire()
        {
            for (int l=0; l < 3; l++)
            {
                for (int c=0; c < 6; c++)
                {
                    Rectangle slot = new Rectangle();
                    slot.Width = 50;
                    slot.Height = 50;
                    Canvas.SetTop(slot, 260 +(l*63));
                    Canvas.SetLeft(slot, 213 + (c*63));
                    slot.Fill = Brushes.LightGray;
                    grille.Children.Add(slot);
                }
            }
        }


    }

}
