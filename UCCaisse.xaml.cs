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

        private void ValiderCommande_Click(object sender, RoutedEventArgs e)
        {
            // PLUS TARD :
            // - vérifier inventaire
            // - valider la commande
            // - passer à la suivante

            MessageBox.Show("Commande validée (logique à venir)");
        }

        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Panel panel)
                panel.Children.Remove(this);
        }
    }
}
