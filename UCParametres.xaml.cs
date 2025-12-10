using Microsoft.VisualBasic;
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
using PaniqueEnCuisine;

namespace PaniqueEnCuisine
{
    /// <summary>
    /// Logique d'interaction pour UCParametres.xaml
    /// </summary>
    public partial class UCParametres : UserControl
    {
        public UCParametres()
        {
            InitializeComponent();
        }

        private void ButtonSettingsSon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSettingsSkin_Click(object sender, RoutedEventArgs e)
        {
            UCParametres uc = new UCParametres();
            
        }
    }
}
