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
        public MapManager mapManager = new MapManager(new Joueur("player", 100, 100, 2, 2,100,200), 3);
        public MainWindow()
        {
            InitializeComponent();
            ChangeScreen(new UCMenu(this));
            Audio.PlayMusic("Sons/son_music_loop.wav", true);
        }

        public void ChangeScreen(UserControl newScreen)
        {
            ZoneJeu.Content = newScreen;
        }
        

        
    }

}