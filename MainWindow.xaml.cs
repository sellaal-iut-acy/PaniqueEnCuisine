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
    //public partial class MainWindow : Window
    //{
    //    private readonly DispatcherTimer timer;
    //    public UCMenu uc = new UCMenu();

    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //        AfficheDemarrage();

    //    }
    //    private void AfficheDemarrage() 
    //    {
    //        ZoneJeu.Content = new UCMenu(this); // Passe l'instance de MainWindow à UCMenu
    //    }
    //}

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeScreen(new UCMenu(this));
        }

        public void ChangeScreen(UserControl newScreen)
        {
            ZoneJeu.Content = newScreen;
        }
    }

}