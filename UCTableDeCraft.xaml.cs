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
            foreach ( Recette Recette in ManagerRecettes.ListeRecetes)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Height = 137;
                stackPanel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF444343"));
                StackPanel stackPanel1 = new StackPanel();

                Image image = new Image();
                image.Source = Recette.Nouriture.Image.Source;
                image.Margin = new Thickness(0, 0, 20, 0); 
                image.Width = 73;
                image.Height = 61;

                TextBox textBox = new TextBox();
                textBox.FontSize = 24;
                textBox.Foreground = Brushes.White;
                textBox.Text = $"{Recette.Nouriture.Nom}";

                TextBox textBox1 = new TextBox();
                textBox1.FontSize = 18;
                textBox1.Foreground = Brushes.White;
                textBox1.Margin = new Thickness(0, 10, 0, 0);
                textBox1.Text = "Ingrédients nécessaires :";

                TextBox textBox2 = new TextBox();
                textBox2.FontSize = 16;
                textBox2.Foreground = Brushes.White;
                textBox2.Text = $"{Recette.NouritureList[0]}";

                TextBox textBox3 = new TextBox();
                textBox3.FontSize = 16;
                textBox3.Foreground = Brushes.White;
                textBox3.Text = $"{Recette.NouritureList[0]}";

                TextBox textBox4 = new TextBox();
                textBox4.FontSize = 16;
                textBox4.Foreground = Brushes.White;
                textBox4.Text = "";


                stackPanel1.Children.Add(textBox);
                stackPanel1.Children.Add(textBox1);
                stackPanel1.Children.Add(textBox2);
                stackPanel1.Children.Add(textBox3);
                stackPanel1.Children.Add(textBox4);
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(stackPanel1);

                Button button = new Button();
                button.Content = "Cuisiner";
                button.FontSize = 20; 
                button.Foreground = Brushes.Gray;
                button.BorderBrush = Brushes.Black;
                button.Margin = new Thickness(0, 0, 0, 20);
                button.FontWeight = FontWeights.Bold;
                Color maCouleur = (Color)ColorConverter.ConvertFromString("#FF444343");
                button.BorderBrush = new SolidColorBrush(maCouleur);
                button.BorderThickness = new Thickness(5, 5, 5, 5);
                button.Click += ButtonAClick;

                listeRecette.Children.Add(stackPanel);
                listeRecette.Children.Add(button);
            }
        }

        private void ButtonAClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}