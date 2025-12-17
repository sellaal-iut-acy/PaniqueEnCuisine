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
    /// Logique d'interaction pour UCMenuSkin.xaml
    /// </summary>
    public partial class UCMenuSkin : UserControl
    {
        private MainWindow _Main;
        private int _SelectionSkin = 0;

        public UCMenuSkin(MainWindow mw)
        {
            InitializeComponent();
            _Main = mw;

            UpdatePreview();
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            Audio.PlaySFX("Sons/son_clic.wav");
            _Main.ChangerEcran(new UCMenuPlus(_Main));
        }
        private void SkinPrototype_Click(object sender, RoutedEventArgs e)
        {
            _SelectionSkin = 0;
            UpdatePreview();
        }

        private void SkinChef_Click(object sender, RoutedEventArgs e)
        {
            _SelectionSkin = 1;
            UpdatePreview();
        }

        

        private void UpdatePreview()
        {
            ImagePreview.Source = new BitmapImage(
                new Uri($"pack://application:,,,/Images/Entiter/image_idle0_skin{_SelectionSkin}.png")
            );
        }

        private void SelectSkin_Click(object sender, RoutedEventArgs e)
        {
            var Joueur = _Main.MapManager.Playeur;

            Joueur.IndexSkinActuel = _SelectionSkin;
            Joueur.Charger_images();

            Audio.PlaySFX("Sons/son_clic.wav");
            _Main.ChangerEcran(new UCMenuPlus(_Main));



        }
    }
}
