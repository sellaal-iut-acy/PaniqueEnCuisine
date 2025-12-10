using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCMenuSon.xaml
    /// </summary>
    public partial class UCMenuSon : UserControl
    {
        private MainWindow main;
        public UCMenuSon(MainWindow mw)
        {
            InitializeComponent();
            main = mw;
        }

        private void B_Retour_Click(object sender, RoutedEventArgs e)
        {
            main.ChangeScreen(new UCParametres(main));
        }
    }
}
