using System.Windows;

namespace PaniqueEnCuisine
{
    public partial class FenetreParametreSon : Window
    {
        public FenetreParametreSon()
        {
            InitializeComponent();

            // Charger les valeurs existantes
            Sl_General.Value = ManagerSettings.VolumeGeneral;
            Sl_Music.Value = ManagerSettings.VolumeMusique;
            Sl_SFX.Value = ManagerSettings.VolumeEffets;
        }

        private void Sl_General_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ManagerSettings.VolumeGeneral = Sl_General.Value;
            Audio.MiseAjourVolume();
        }

        private void Sl_Music_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ManagerSettings.VolumeMusique = Sl_Music.Value;
            Audio.MiseAjourVolume();
        }

        private void Sl_SFX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ManagerSettings.VolumeEffets = Sl_SFX.Value;
            Audio.MiseAjourVolume();
        }

        private void ButtonFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Audio.MiseAjourVolume();
        }
    }
}
