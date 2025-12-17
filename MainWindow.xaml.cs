using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PaniqueEnCuisine
{
    public partial class MainWindow : Window
    {
        public MapManager MapManager = new MapManager(new Joueur("player", 100, 100, 2, 2,100,200));

        public MainWindow()
        {
            InitializeComponent();
            ChangerEcran(new UCMainMenu(this));
            Audio.JouerMusique("Sons/son_music_loop.wav", true);
           

        }

        public void ChangerEcran(UserControl NouvelEcrant)
        {
            ZoneJeu.Content = NouvelEcrant;
          
        }
       


        





    }

}