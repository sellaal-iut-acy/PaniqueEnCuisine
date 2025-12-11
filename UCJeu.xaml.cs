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
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private MainWindow main;
        public MapManager mapManager = new MapManager(new Joueur("player",100, 100, 2, 2), new Image(), 3);
        private Image playeur;

        public UCJeu(MainWindow mw)
        {
            InitializeComponent();
            main = mw;

         
        }
    }

}
