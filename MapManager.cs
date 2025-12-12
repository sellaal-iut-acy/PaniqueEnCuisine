using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PaniqueEnCuisine
{
    public class MapManager
    {
       public Joueur playeur;
        private List<PNJ> pnjs;
        public ImageBrush fond ;
        private ManagerSettings managerSettings;
        
       
        

        public MapManager(Joueur playeur, int nb_PNJs)
        {
            this.playeur = playeur;
            Liste_PNJs(nb_PNJs);
            this.fond = new ImageBrush(new BitmapImage(new Uri("P:\\P Perso\\SAE 101 102\\WPF\\Images\\Image_Fond_MainMenu.png", UriKind.Relative)));
        }

        private void Liste_PNJs( int nb_PNJs)
        {
            this.pnjs = new List<PNJ>();
            for (int i = 0; i < nb_PNJs; i++)
            {
                PNJ pnj = new PNJ("PNJ" + i, 100 * i, 100, 2, 100, 1,50,100);
                this.pnjs.Add(pnj);
            }
        }
        public void Run()
        {

        }
        
 
    }
}

// benoit.dirad@univ-smb.fr
