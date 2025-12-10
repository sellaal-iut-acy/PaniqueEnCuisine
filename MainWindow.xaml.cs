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

        public MainWindow()
        {
            InitializeComponent();

            // Place la boule au départ
            Canvas.SetLeft(Ball, x);
            Canvas.SetTop(Ball, y);

            // Timer 60 FPS
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += MoveBall;
            timer.Start();

            // Lire les touches
            this.Focusable = true;
            this.Focus();
        }
       
    }


}