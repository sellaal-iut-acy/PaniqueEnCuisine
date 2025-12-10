using System.Windows.Controls;

namespace PaniqueEnCuisine
{
    internal static class EntiterHelpers
    {

        private static Image[,] Charger_images(this)
        {
            Image[,] imgs = new Image[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    imgs[i, j] = new Image();
                    imgs[i, j].Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/Images/{non}_{i}_{j}.png", UriKind.Relative));
                }
            }
            return imgs;
        }
    }
}