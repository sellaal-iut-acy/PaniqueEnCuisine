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
        private MainWindow _Main;
        int _NiveauSelectionne = 1;


        public UCMenuLevel(MainWindow mw)
        {
            InitializeComponent();
            _Main = mw;
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            _Main.ChangerEcran(new UCMenuPlus(_Main));
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

            _Main.MapManager.NiveauActuel = _NiveauSelectionne;

            _Main.ChangerEcran(new UCMenuPlus(_Main));
        }
        private void SelectionnerNiveau(int niveau)
        {
            Audio.PlaySFX("Sons/son_clic.wav");

            _NiveauSelectionne = niveau;

            string path = $"Images/Niveau/image_fond_niveau{niveau}.png";
            ImagePreviewNiveau.Source = new BitmapImage(
                new Uri(path, UriKind.Relative)
            );
        }
    }
}
