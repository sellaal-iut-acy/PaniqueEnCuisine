using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    public partial class UCCaisse : UserControl
    {
        private Joueur joueur;
        private DispatcherTimer uiTimer;

        public UCCaisse(Joueur joueur)
        {
            InitializeComponent();

            this.joueur = joueur;

            ConstruireCommande();

            // Timer UI (lecture du timer global de la caisse)
            uiTimer = new DispatcherTimer();
            uiTimer.Interval = TimeSpan.FromMilliseconds(300);
            uiTimer.Tick += (s, e) => MettreAJourTimer();
            uiTimer.Start();
        }

        private void ConstruireCommande()
        {
            var recette = Caisse.CommandeEnCours;
            if (recette == null) return;

            CommandePanel.Children.Clear();

            StackPanel stackPanel = new StackPanel();

            Image image = new Image
            {
                Source = recette.Nouriture.Image.Source,
                Width = 73,
                Height = 61,
                Margin = new Thickness(0, 0, 0, 15)
            };

            stackPanel.Children.Add(image);

            stackPanel.Children.Add(new TextBlock
            {
                Text = recette.Nouriture.Nom,
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

            foreach (var ing in recette.NouritureList)
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
            var recette = Caisse.CommandeEnCours;
            var inventaire = joueur.Inventaire;

            //On cherche le PLAT dans l'inventaire
            var plat = inventaire.Liste_nourriture
                .FirstOrDefault(n => n.Nom == recette.Nouriture.Nom);

            if (plat == null)
            {
                Console.WriteLine("Commande refusée : plat non présent");
                return;
            }

            //Retirer le plat
            inventaire.Liste_nourriture.Remove(plat);

            Console.WriteLine($"Commande validée : {recette.Nouriture.Nom}");

            //Nouvelle commande
            Caisse.NouvelleCommande();
            ConstruireCommande();
        }


        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            uiTimer.Stop();

            if (Parent is Panel panel)
                panel.Children.Remove(this);
        }
    }
}
