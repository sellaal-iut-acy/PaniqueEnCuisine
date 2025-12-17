using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCMenuLevel.xaml
    /// </summary>
    public partial class UCMenuLevel : UserControl
    {
        private MainWindow main;
        int niveauSelectionne = 1;


        public UCMenuLevel(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            main.ChangerEcran(new UCMenuPlus(main));
        }

        private void Button_Niveau1_Click(object sender, RoutedEventArgs e)
        {
            SelectionnerNiveau(1);
        }

        private void Button_Niveau2_Click(object sender, RoutedEventArgs e)
        {
            SelectionnerNiveau(2);
        }

        private void Button_Niveau3_Click(object sender, RoutedEventArgs e)
        {
            SelectionnerNiveau(3);
        }

        private void Button_Niveau4_Click(object sender, RoutedEventArgs e)
        {
            SelectionnerNiveau(4);
        }

        private void B_Select_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            main.MapManager._NiveauActuel = niveauSelectionne;

            main.ChangerEcran(new UCMenuPlus(main));
        }
        private void SelectionnerNiveau(int niveau)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            niveauSelectionne = niveau;

            string path = $"Images/Niveau/image_fond_niveau{niveau}.png";
            ImagePreviewNiveau.Source = new BitmapImage(
                new Uri(path, UriKind.Relative)
            );
        }
    }
}
