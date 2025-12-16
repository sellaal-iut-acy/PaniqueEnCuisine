using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaniqueEnCuisine
{
    public partial class UCfour : UserControl
    {
        public UCfour()
        {
            InitializeComponent();
            this.Focusable = true;
            this.Focus();
        }

        private void B_Fermer_Click(object sender, RoutedEventArgs e)
        {
            FermerFour();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
                FermerFour();
        }

        private void FermerFour()
        {
            if (this.Parent is Panel parent)
                parent.Children.Remove(this);
        }

        private void B_cuirre(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("cuirre");
            
            
        }
    }
}
