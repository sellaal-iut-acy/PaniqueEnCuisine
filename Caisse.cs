using System;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    internal class Caisse : OutilsCusine
    {
        public static Recette CommandeEnCours;
        public static int TempsRestant;

        private static DispatcherTimer timer;
        private static ManagerRecette managerRecette = new ManagerRecette();

        public Caisse(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation)
            : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Caisse";

            if (timer == null)
                InitialiserTimer();

            if (CommandeEnCours == null)
                NouvelleCommande();
        }

        private static void InitialiserTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                TempsRestant--;

                if (TempsRestant <= 0)
                {
                    timer.Stop();
                    Console.WriteLine("GAME OVER");
                }
            };
        }


        public static void NouvelleCommande()
        {
            CommandeEnCours = managerRecette.GetRecetteAleatoire();
            TempsRestant = 90; // RESET DU TIMER
            timer.Start();
        }
        public static void Reset()
        {
            CommandeEnCours = null;
            TempsRestant = 0;

            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
        }

    }
}
