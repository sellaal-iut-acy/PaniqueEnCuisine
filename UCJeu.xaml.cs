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
        private MainWindow _Main;

        private Image _Joueur = new Image();

        private bool _Up, _Down, _Left, _Right, _Sprint;
        private DispatcherTimer _Timer;

        private double _BaseSpeed = 3;
        private double _SprintMultiplier = 1.8;

        private int _AnimDelay = 0;
        private int _AnimSpeed = 3;

        private ManagerColision _Colision = new ManagerColision();

        private UCFrigo _UcFrigo = null;
        private UCfour _UcFour = null;
        private UCTableDeCraft _UcTableDeCraft = null;


        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            _Main = mw;
            DefinirFondNiveau();
            Ajouter_outlis_cuisine();
            Ajout_Image_Player();
            JouerLaMusiqueDuNiveau();


            _Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };
            _Timer.Tick += MiseAjourJoueur;
            _Timer.Start();
           
        }

        /* ================= INIT ================= */

        private void DefinirFondNiveau()
        {
            int niveau = _Main.MapManager.NiveauActuel;
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
            var p = _Main.MapManager.Playeur;

            _Joueur.Width = p.Largeur;
            _Joueur.Height = p.Hauteur;
            _Joueur.Source = p.GetImageJoueur();

            Canvas.SetLeft(_Joueur, p.X);
            Canvas.SetTop(_Joueur, p.Y);

            grille.Children.Add(_Joueur);
            
        }
        private void JouerLaMusiqueDuNiveau()
        {
            Audio.ArretMusique();
            Audio.JouerMusique($"Sons/son_music_loop_niveau{_Main.MapManager.NiveauActuel}.wav", true);

        }

        /* ================= GAME LOOP ================= */

        private void MiseAjourJoueur(object sender, EventArgs e)
        {
            var p = _Main.MapManager.Playeur;

            double speed = _Sprint ? _BaseSpeed * _SprintMultiplier : _BaseSpeed;
            bool moving = false;

            if (_Up) { p.Y -= speed; p.Direction = 0; moving = true; }
            if (_Right) { p.X += speed; p.Direction = 1; moving = true; }
            if (_Down) { p.Y += speed; p.Direction = 2; moving = true; }
            if (_Left) { p.X -= speed; p.Direction = 3; moving = true; }

            _AnimDelay++;
            if (_AnimDelay >= _AnimSpeed)
            {
                p.IndexImage = (p.IndexImage + 1) % 5;
                _AnimDelay = 0;
            }

            if (!moving) p.Direction = 4;

            Canvas.SetLeft(_Joueur, p.X);
            Canvas.SetTop(_Joueur, p.Y);
            _Joueur.Source = p.GetImageJoueur();
            if(Caisse.fini)
            {
                Console.WriteLine("GAME OVER !!!");
                Audio.PlaySFX("Sons/son_gameover.wav");
                Audio.ArretMusique();
                NettoyerUCJeu();
                _Main.ChangerEcran(new UCGameOver(_Main));

            }

        }
       
        /* ================= CLAVIER ================= */

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += OnKeyDown;
            Application.Current.MainWindow.KeyUp += OnKeyUp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == ManagerSettings.KeyHaut) _Up = true;
            if (e.Key == ManagerSettings.KeyBas) _Down = true;
            if (e.Key == ManagerSettings.KeyGauche) _Left = true;
            if (e.Key == ManagerSettings.KeyDroite) _Right = true;
            if (e.Key == ManagerSettings.KeySprint) _Sprint = true;

            if (e.Key == ManagerSettings.KeyAction)
            {
                if (_Colision.VeriferColision_PLAYER_FrIgo(grille, _Joueur, _Main.MapManager.Playeur))
                    OuvrirFrigo();

                if (_Colision.VeriferColision_PLAYER_Four(grille, _Joueur, _Main.MapManager.Playeur))
                    OuvrirFour();
                if (e.Key == ManagerSettings.KeyAction)
                {
                    if (_Colision.VeriferColision_PLAYER_Caisse(grille, _Joueur, _Main.MapManager.Playeur))
                        OuvrirCaisse();
                }
            }
        }



        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == ManagerSettings.KeyHaut) _Up = false;
            if (e.Key == ManagerSettings.KeyBas) _Down = false;
            if (e.Key == ManagerSettings.KeyGauche) _Left = false;
            if (e.Key == ManagerSettings.KeyDroite) _Right = false;
            if (e.Key == ManagerSettings.KeySprint) _Sprint = false;
        }

        /* ================= OVERLAYS ================= */

        private void OuvrirFrigo()
        {
            if (_UcFrigo != null) return;

            _UcFrigo = new UCFrigo(_Main.MapManager.Playeur.Inventaire);
            AjouterOverlay(_UcFrigo);
            _UcFrigo.Unloaded += (s, e) => _UcFrigo = null;
        }

        private void OuvrirFour()
        {
            if (_UcFour != null) return;
            _UcFour = new UCfour(_Main.MapManager.Playeur,_Main.MapManager.Playeur.Inventaire);
            AjouterOverlay(_UcFour);
            _UcFour.Unloaded += (s, e) => _UcFour = null;
        }
        private UCCaisse ucCaisse = null;

        private void OuvrirCaisse()
        {
            if (ucCaisse != null) return;

            ucCaisse = new UCCaisse(_Main.MapManager.Playeur);
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


        private void Button_RetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            Audio.ArretMusique();


            NettoyerUCJeu();

            _Main.ChangerEcran(new UCMainMenu(_Main));

            Audio.JouerMusique("Sons/son_music_loop.wav", true);

        }

        private void NettoyerUCJeu()
        {
            // Stop la boucle de jeu
            _Timer?.Stop();

            // Désinscription clavier
            Application.Current.MainWindow.KeyDown -= OnKeyDown;
            Application.Current.MainWindow.KeyUp -= OnKeyUp;

            // Fermer overlays
            if (_UcFrigo != null && _UcFrigo.Parent is Panel parentFrigo)
                parentFrigo.Children.Remove(_UcFrigo);

            if (_UcFour != null && _UcFour.Parent is Panel parentFour)
                parentFour.Children.Remove(_UcFour);

            if (ucCaisse != null && ucCaisse.Parent is Panel parentCaisse)
                parentCaisse.Children.Remove(ucCaisse);

            _UcFrigo = null;
            _UcFour = null;
            ucCaisse = null;

            // 🔥 RESET CAISSE (IMPORTANT)
            Caisse.Reset();

            // Nettoyage du canvas
            grille.Children.Clear();

            // Reset gameplay
            _Main.MapManager.ManagerOutilsCuisine.OutilsCuisine.Clear();
            

            _Main.MapManager.Playeur.X = 0;
            _Main.MapManager.Playeur.Y = 0;
        }


        private void Button_TableDeCraft_Click(object sender, RoutedEventArgs e)
        {
            if (_UcTableDeCraft != null) return;

            _UcTableDeCraft = new UCTableDeCraft(_Main.MapManager.Playeur);
            AjouterOverlay(_UcTableDeCraft);
            _UcTableDeCraft.Unloaded += (s, e) => _UcTableDeCraft = null;
        }


      


        private void Ajouter_outlis_cuisine()
        {
            _Main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Frigo("Frigo", 100, 5, 100, 150, 0, 50)
            );

            _Main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Foure("Four", 400, 50, 200, 100, 0, 50)
            );

            _Main.MapManager.ManagerOutilsCuisine.AjouterOutil(
                new Caisse("Caisse", 640, 300, 70, 50, 0, 50)
             );

            _Main.MapManager.ManagerOutilsCuisine.AfficherOutilsCuisine(grille);


        }
    }
}
