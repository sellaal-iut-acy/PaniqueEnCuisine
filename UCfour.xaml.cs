using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaniqueEnCuisine
{
    public partial class UCfour : UserControl
    {
        private Nouriture Nouriture_a_cuire;
        private Nouriture Nouriture_cuit;

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

        private void FermerFour()
        {
            if (this.Parent is Panel parent)
                parent.Children.Remove(this);
        }
        private void ajouter_Nouriture_a_cuirre(Nouriture nouriture)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(
                new Uri($"{nouriture.Image.Source.ToString()}")
            );
            imageBrush.Stretch = Stretch.UniformToFill;
            objet_a_cuirre.Fill = imageBrush;
            Nouriture_a_cuire = nouriture;
        }
        private void cuirre_Nouriture()
        {
            if (Nouriture_a_cuire.Temps_cuisson!=0)
            {
                Nouriture_cuit = Nouriture_a_cuire;
            }
        }
        private Nouriture Recuperre_Nouriture_cuite()
        {
            return Nouriture_cuit;
        }

        private void B_cuirre(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("cuirre");
            cuirre_Nouriture();
            
        }
    }
}
