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
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private MainWindow main;
        public Image joueur = new Image();
        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
            Ajout_Image_Player();
            Ajout_image_Fond();
        }

        private void Ajout_image_Fond()
        {
            grille.Background = main.mapManager.fond;
        }

        private void Ajout_Image_Player()
        {
            joueur.Source = main.mapManager.playeur.current_Image.Source;
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
            Application.Current.MainWindow.KeyUp += move_joueur;
            
        }

        public void move_joueur(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == ManagerSettings.KeyDroite.ToString()) 
            {
                Canvas.SetLeft(joueur, Canvas.GetLeft(joueur) + main.mapManager.playeur.Vitesse);
                Console.WriteLine("Position Right joueur :" + Canvas.GetLeft(joueur));
            }
           
            if (e.Key.ToString() == ManagerSettings.KeyGauche.ToString()) 
            {
                main.mapManager.playeur.Left();
                Canvas.SetLeft(joueur, Canvas.GetLeft(joueur) - main.mapManager.playeur.Vitesse);
                Console.WriteLine("Position Right joueur :" + Canvas.GetLeft(joueur));
            }

            if (e.Key.ToString() == ManagerSettings.KeyBas.ToString()) 
            {
                main.mapManager.playeur.Down();
                Canvas.SetTop(joueur, Canvas.GetTop(joueur) + main.mapManager.playeur.Vitesse);
                Console.WriteLine("Position Right joueur :" + Canvas.GetLeft(joueur));
            }

            if (e.Key.ToString() == ManagerSettings.KeyHaut.ToString()) 
            {
                main.mapManager.playeur.Right();
                Canvas.SetTop(joueur, Canvas.GetTop(joueur) - main.mapManager.playeur.Vitesse);
                Console.WriteLine("Position Right joueur :" + Canvas.GetLeft(joueur));
            }
            
        }
    }

}
