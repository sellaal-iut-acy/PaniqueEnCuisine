using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PaniqueEnCuisine
{
    public partial class UCTableDeCraft : UserControl
    {
        private ManagerRecette  _ManagerRecettes = new ManagerRecette();
        private Inventaire _InventaireJoueur;
        private Recette _RecetteSelectionner;
        private List<Nouriture>  _NouritureAEnlever = new List<Nouriture>();
        private int _IndexActuel = 0;
        private List<StackPanel> _StackPanels = new List<StackPanel>();
        public UCTableDeCraft(Joueur  joueur)
        {

            InitializeComponent();
            this.Focusable = true;
            this.Focus();
            _Gener_Recette();
            _InventaireJoueur = joueur.Inventaire;
            _AfficherInventaireJoueur();
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            _FermerTableDeCraft();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
                _FermerTableDeCraft();
        }

        private void _FermerTableDeCraft()
        {
            if (this.Parent is Panel parent)
                parent.Children.Remove(this);
        }


        private void _Gener_Recette()
        {
            int i = 0;
            foreach (Recette Recette in _ManagerRecettes.ListeRecetes)
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

                _StackPanels.Add(stackPanel);
      
            }
        }

        private void _AfficherInventaireJoueur()
        {
            foreach(Nouriture Ingerdiqnt in _InventaireJoueur.Liste_nourriture )
            {
                Ingerdiqnt.Image.Width = 50;
                Ingerdiqnt.Image.Height = 50;
                InventairePlayer.Children.Add(Ingerdiqnt.Image);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listeRecette.Children.Remove(_StackPanels[_IndexActuel]);
            if (_StackPanels.Count == 0) return;

            _IndexActuel--;
            if (_IndexActuel < 0)
                _IndexActuel = _StackPanels.Count - 1;

            listeRecette.Children.Add(_StackPanels[_IndexActuel]);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listeRecette.Children.Remove(_StackPanels[_IndexActuel]);
            if (_StackPanels.Count == 0) return;

            _IndexActuel++;
            if (_IndexActuel >= _StackPanels.Count) _IndexActuel = 0;

            listeRecette.Children.Add(_StackPanels[_IndexActuel]);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool crafte = false;
            Console.WriteLine("début du test");
            for (int i = 0; i < _ManagerRecettes.ListeRecetes[_IndexActuel].NouritureList.Count; i++)
            {
                for (int j = i; j < _InventaireJoueur.Liste_nourriture.Count; j++)
                {
                    Console.WriteLine($"{_ManagerRecettes.ListeRecetes[_IndexActuel].NouritureList[i].Nom} {_InventaireJoueur.Liste_nourriture[j].Nom}");
                    if (_ManagerRecettes.ListeRecetes[_IndexActuel].NouritureList[i].Nom == _InventaireJoueur.Liste_nourriture[j].Nom)
                        _NouritureAEnlever.Add(_InventaireJoueur.Liste_nourriture[j]);
                    else
                    { Console.WriteLine("tu n'apas touts les ingrédient"); }

                }
            }
            if (_NouritureAEnlever.Count == _ManagerRecettes.ListeRecetes[_IndexActuel].NouritureList.Count)
            {
                foreach (Nouriture ingrediantAEnlever in _NouritureAEnlever)
                {
                    _InventaireJoueur.Liste_nourriture.Remove(ingrediantAEnlever);
                    _InventaireJoueur.Liste_nourriture.Add(_ManagerRecettes.ListeRecetes[_IndexActuel].Nouriture);
                }
                craft.Text = $"vous avez cusiner {_ManagerRecettes.ListeRecetes[_IndexActuel].Nouriture.Nom} ";

            }
            else
            {
                craft.Text = $"vous avez cusiner {_ManagerRecettes.ListeRecetes[_IndexActuel].Nouriture.Nom} il vaus manque des ingrédiants ";
            }
                


            Console.WriteLine("fin de des teste");
            
        }
    }
}