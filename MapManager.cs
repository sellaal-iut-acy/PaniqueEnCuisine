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
        private Joueur _Playeur;
        private ImageBrush _ImageFond = new ImageBrush();
        private ManagerSettings _ManagerSettings = new ManagerSettings();
        private Canvas _Canvas = new Canvas();
        private int niveauActuel = 1;
        private ManagerOutilsCuisine _ManagerOutilsCuisine = new ManagerOutilsCuisine (new List<OutilsCusine>());
        private ManagerColision _ManagerColision = new ManagerColision();


        public MapManager(Joueur playeur)
        {
            this._Playeur = playeur;
            this._ImageFond = new ImageBrush(new BitmapImage(new Uri($"Images/Niveau/image_fond_niveau{NiveauActuel}.png", UriKind.Relative)));
        }

        public Canvas Grille
        {
            get
            {
                return this._Canvas;
            }

            set
            {
                this._Canvas = value;
            }
        }

        public ManagerSettings ManagerSettings
        {
            get
            {
                return this._ManagerSettings;
            }

            set
            {
                this._ManagerSettings = value;
            }
        }


        internal ManagerOutilsCuisine ManagerOutilsCuisine
        {
            get
            {
                return this._ManagerOutilsCuisine;
            }

            set
            {
                this._ManagerOutilsCuisine = value;
            }
        }

        internal ManagerColision ManagerColision
        {
            get
            {
                return this._ManagerColision;
            }

            set
            {
                this._ManagerColision = value;
            }
        }

        internal ManagerOutilsCuisine ManagerOutilsCuisine1
        {
            get
            {
                return this._ManagerOutilsCuisine;
            }

            set
            {
                this._ManagerOutilsCuisine = value;
            }
        }

        public int NiveauActuel
        {
            get
            {
                return this.niveauActuel;
            }

            set
            {
                this.niveauActuel = value;
            }
        }

        public Canvas Canvas
        {
            get
            {
                return this._Canvas;
            }

            set
            {
                this._Canvas = value;
            }
        }

        public ImageBrush ImageFond
        {
            get
            {
                return this._ImageFond;
            }

            set
            {
                this._ImageFond = value;
            }
        }

        public Joueur Playeur
        {
            get
            {
                return this._Playeur;
            }

            set
            {
                this._Playeur = value;
            }
        }
    }
}