using System;
using System.Windows.Threading;

namespace PaniqueEnCuisine
{
    internal class Caisse : OutilsCusine
    {
        private static Recette commandeEnCours;
        private static int tempsRestant = 0;
        private static DispatcherTimer _Timer = new DispatcherTimer();
        private static ManagerRecette _ManagerRecette = new ManagerRecette();
        public static bool fini = false;

        public Caisse(string nom, int x, int y, int width, int height, int niveaux, int vitesse_utilisation) : base(nom, x, y, width, height, niveaux, vitesse_utilisation)
        {
            this.Img_outi.Tag = "Caisse";

            if (Timer == null)
                InitialiserTimer();

            if (CommandeEnCours == null)
                NouvelleCommande();
        }

        internal static Recette CommandeEnCours
        {
            get
            {
                return commandeEnCours;
            }

            set
            {
                commandeEnCours = value;
            }
        }

        public static DispatcherTimer Timer
        {
            get
            {
                return _Timer;
            }

            set
            {
                _Timer = value;
            }
        }

        internal static ManagerRecette ManagerRecette
        {
            get
            {
                return _ManagerRecette;
            }

            set
            {
                _ManagerRecette = value;
            }
        }

        public static int TempsRestant
        {
            get
            {
                return tempsRestant;
            }

            set
            {
                tempsRestant = value;
            }
        }

        

        private static void InitialiserTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += (s, e) =>
            {
                TempsRestant--;

                if (TempsRestant <= 0)
                {
                    _Timer.Stop();
                    Console.WriteLine("GAME OVER");
                }
            };
        }


        public static void NouvelleCommande()
        {
            CommandeEnCours = ManagerRecette.GetRecetteAleatoire();
            TempsRestant = 90; // RESET DU TIMER
            _Timer.Start();
        }
        public static void Reset()
        {
            CommandeEnCours = null;
            TempsRestant = 0;

            if (Timer != null)
            {
                Timer.Stop();
                Timer = null;
            }
        }

    }
}
