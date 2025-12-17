using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaniqueEnCuisine
{
    public partial class UCTableDeCraft : UserControl
    {
        private ManagerRecette  ManagerRecettes = new ManagerRecette();
        public UCTableDeCraft()
        {
            InitializeComponent();
            this.Focusable = true;
            this.Focus();
            gener_recette();
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerTableDeCraft();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
                FermerTableDeCraft();
        }

        private void FermerTableDeCraft()
        {
            if (this.Parent is Panel parent)
                parent.Children.Remove(this);
        }

        private void Button_Cuisiner_Burger_Click(object sender, RoutedEventArgs e)
        {
            cuisiner("burger");
        }
        
        
        
        
        private void cuisiner(string plat)
        {
            Console.WriteLine("Cuisiner un " + plat + " !");
        }

        private void Button_Cuisiner_Pizza_Click(object sender, RoutedEventArgs e)
        {

            cuisiner("pizza");
        }

        private void gener_recette()
        {
            foreach (Recette Recette in ManagerRecettes.ListeRecetes)
            {
                StackPanel stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Height = 137,
                    Background = new SolidColorBrush(
                        (Color)ColorConverter.ConvertFromString("#FF444343"))
                };

                StackPanel stackPanel1 = new StackPanel();

                Image image = new Image
                {
                    Source = Recette.Nouriture.Image.Source,
                    Margin = new Thickness(0, 0, 20, 0),
                    Width = 73,
                    Height = 61
                };

                TextBlock titre = new TextBlock
                {
                    FontSize = 24,
                    Foreground = Brushes.White,
                    Text = Recette.Nouriture.Nom
                };

                TextBlock sousTitre = new TextBlock
                {
                    FontSize = 18,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 10, 0, 0),
                    Text = "Ingrédients nécessaires :"
                };

                TextBlock ingredient1 = new TextBlock
                {
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Text = Recette.NouritureList.Count > 0
                        ? Recette.NouritureList[0].Nom
                        : ""
                };

                TextBlock ingredient2 = new TextBlock
                {
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Text = Recette.NouritureList.Count > 1
                        ? Recette.NouritureList[1].Nom
                        : ""
                };

                TextBlock ingredient3 = new TextBlock
                {
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Text = Recette.NouritureList.Count > 2
                        ? Recette.NouritureList[2].Nom
                        : ""
                };

                stackPanel1.Children.Add(titre);
                stackPanel1.Children.Add(sousTitre);
                stackPanel1.Children.Add(ingredient1);
                stackPanel1.Children.Add(ingredient2);
                stackPanel1.Children.Add(ingredient3);

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(stackPanel1);

                Button button = new Button
                {
                    Content = "Cuisiner",
                    FontSize = 20,
                    Foreground = Brushes.Gray,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 20),
                    BorderThickness = new Thickness(5)
                };

                Color maCouleur = (Color)ColorConverter.ConvertFromString("#FF444343");
                button.BorderBrush = new SolidColorBrush(maCouleur);
                button.Click += ButtonAClick;

                listeRecette.Children.Add(stackPanel);
                listeRecette.Children.Add(button);
            }
        }


        private void ButtonAClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Bouton Cuisiner cliqué !");
        }
    }
}