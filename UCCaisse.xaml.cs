using System.Windows;
using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    public partial class UCCaisse : UserControl
    {
        public UCCaisse()
        {
            InitializeComponent();
        }

        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Panel panel)
                panel.Children.Remove(this);
        }
    }
}
