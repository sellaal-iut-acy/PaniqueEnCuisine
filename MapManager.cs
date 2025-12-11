using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;


namespace PaniqueEnCuisine
{
    public class MapManager
    {
       public Joueur playeur;
        private List<PNJ> pnjs;
        public Image fond = new Image();
        private ManagerSettings managerSettings;

        public MapManager(Joueur playeur, Image fond, int nb_PNJs)
        {
            this.playeur = playeur;
            this.fond = fond;
            Liste_PNJs(nb_PNJs);
            this.fond.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri($"/Images/Map/fond_map.png", UriKind.Relative));
        }

        private void Liste_PNJs( int nb_PNJs)
        {
            this.pnjs = new List<PNJ>();
            for (int i = 0; i < nb_PNJs; i++)
            {
                PNJ pnj = new PNJ("PNJ" + i, 100 * i, 100, 2, 100, 1);
                this.pnjs.Add(pnj);
            }
        }
        public void Run()
        {

        }
        public void move_joueur(Key key)
        {
            if (key.ToString() == ManagerSettings.KeyDroite.ToString());
                this.playeur.UP();
            if (key.ToString() == ManagerSettings.KeyGauche.ToString());
                this.playeur.Left();
            if (key.ToString() == ManagerSettings.KeyBas.ToString());
                this.playeur.Down();
            if (key.ToString() == ManagerSettings.KeyHaut.ToString());
                this.playeur.Right();

        }
    }
}

// benoit.dirad@univ-smb.fr
