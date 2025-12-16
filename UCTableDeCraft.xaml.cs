using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaniqueEnCuisine
{
    public partial class UCTableDeCraft : UserControl
    {
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
    }
}