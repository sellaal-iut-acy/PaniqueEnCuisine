using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace PaniqueEnCuisine
{
    public class MapManager
    {
        public Joueur playeur;
        public ImageBrush fond = new ImageBrush();
        private ManagerSettings managerSettings = new ManagerSettings();
        private Canvas grille = new Canvas();
        private ManagerClients managerClients = new ManagerClients (new List<PNJ>());
        public int niveau_actuel = 1;
        private ManagerOutilsCuisine managerOutilsCuisine = new ManagerOutilsCuisine (new List<OutilsCusine>());
        private ManagerColision managerColision = new ManagerColision();
        private Table_de_Craft table_De_Crafte = new Table_de_Craft ();

        public MapManager(Joueur playeur)
        {
            this.playeur = playeur;

            this.fond = new ImageBrush(new BitmapImage(new Uri($"Images/Niveau/image_fond_niveau{niveau_actuel}.png", UriKind.Relative)));
        }

        public void afficher_Inventaire_Player(Joueur playeur,Canvas grille,ref Button page_suivante,ref Button Page_arriere)
        {
            this.playeur.Inventaire.Inventaire_player(playeur, grille,ref page_suivante,ref Page_arriere);
        }

        public void Run()
        {

        }
        public Canvas Grille
        {
            get
            {
                return this.grille;
            }

            set
            {
                this.grille = value;
            }
        }

        public ManagerSettings ManagerSettings
        {
            get
            {
                return this.managerSettings;
            }

            set
            {
                this.managerSettings = value;
            }
        }

        internal ManagerClients ManagerClients
        {
            get
            {
                return this.managerClients;
            }

            set
            {
                this.managerClients = value;
            }
        }

        internal ManagerOutilsCuisine ManagerOutilsCuisine
        {
            get
            {
                return this.managerOutilsCuisine;
            }

            set
            {
                this.managerOutilsCuisine = value;
            }
        }

        internal ManagerColision ManagerColision
        {
            get
            {
                return this.managerColision;
            }

            set
            {
                this.managerColision = value;
            }
        }

        internal Table_de_Craft Table_De_Crafte
        {
            get
            {
                return this.table_De_Crafte;
            }

            set
            {
                this.table_De_Crafte = value;
            }
        }
    }
}