namespace PaniqueEnCuisine
{
    internal class Caisse : OutilsCusine
    {
        public Caisse(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation)
            : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Caisse";
        }
    }
}
