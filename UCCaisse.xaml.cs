using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    public partial class UCCaisse : UserControl
    {
        private Joueur _Joueur;
        private DispatcherTimer _uiTimer;

        public UCCaisse(Joueur Joueur)
        {
            InitializeComponent();

            this._Joueur = Joueur;

            ConstruireCommande();

            // Timer UI (lecture du _Timer global de la caisse)
            _uiTimer = new DispatcherTimer();
            _uiTimer.Interval = TimeSpan.FromMilliseconds(300);
            _uiTimer.Tick += (s, e) => MettreAJourTimer();
            _uiTimer.Start();
        }

        private void ConstruireCommande()
        {
            var Recette = Caisse.CommandeEnCours;
            if (Recette == null) return;

            CommandePanel.Children.Clear();

            StackPanel stackPanel = new StackPanel();

            Image Image = new Image
            {
                Source = Recette.Nouriture.Image.Source,
                Width = 73,
                Height = 61,
                Margin = new Thickness(0, 0, 0, 15)
            };

            stackPanel.Children.Add(Image);

            stackPanel.Children.Add(new TextBlock
            {
                Text = Recette.Nouriture.Nom,
                FontSize = 24,
                Foreground = Brushes.White
            });

            stackPanel.Children.Add(new TextBlock
            {
                Text = "Ingrédients nécessaires :",
                FontSize = 18,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 10, 0, 5)
            });

            foreach (var ing in Recette.NouritureList)
            {
                stackPanel.Children.Add(new TextBlock
                {
                    Text = "- " + ing.Nom,
                    FontSize = 16,
                    Foreground = Brushes.White
                });
            }

            CommandePanel.Children.Add(stackPanel);
        }

        private void MettreAJourTimer()
        {
            int t = Caisse.TempsRestant;
            if (t < 0) t = 0;

            TxtTimer.Text = $"⏱ {t / 60:D2}:{t % 60:D2}";
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            var Recette = Caisse.CommandeEnCours;
            var Inventaire = _Joueur.Inventaire;

            //On cherche le PLAT dans l'_Inventaire
            var plat = Inventaire.Liste_nourriture
                .FirstOrDefault(n => n.Nom == Recette.Nouriture.Nom);

            if (plat == null)
            {
                //Console.WriteLine("Commande refusée : plat non présent");
                return;
            }

            //Retirer le plat
            Inventaire.Liste_nourriture.Remove(plat);

            //Console.WriteLine($"Commande validée : {Recette.Nouriture.Nom}");

            //Nouvelle commande
            Caisse.NouvelleCommande();
            ConstruireCommande();
        }


        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            _uiTimer.Stop();

            if (Parent is Panel panel)
                panel.Children.Remove(this);
        }
    }
}
