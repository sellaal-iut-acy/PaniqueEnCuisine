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
       

        private readonly DispatcherTimer timer;
        public UCMenu uc = new UCMenu();
        


        public MainWindow()
        {
            InitializeComponent();
            AfficheDemarrage();
           
        }

        
        private void AfficheDemarrage()
        {
            // crée et charge l'écran de démarrage
            UCMenu uc = new UCMenu();

            // associe l'écran au 
            ZoneJeu.Content = uc;

            

       
        }

    }




}