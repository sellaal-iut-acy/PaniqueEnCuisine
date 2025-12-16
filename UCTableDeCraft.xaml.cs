using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaniqueEnCuisine
{
    public partial class UCTableDeCraft : UserControl
    {
        private ManagerRecette  ManagerRecette = new ManagerRecette();
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
            foreach ( Recette Recette in ManagerRecette)
            {
                StackPanel stackPanel = new StackPanel();
                StackPanel stackPanel1 = new StackPanel();
                Image image = new Image();
                TextBox textBox = new TextBox();
                TextBox textBox1 = new TextBox();
                TextBox textBox2 = new TextBox();
                TextBox textBox3 = new TextBox();
                TextBox textBox4 = new TextBox();

                stackPanel.Children.Add(stackPanel1);


            }
        }
    }
}